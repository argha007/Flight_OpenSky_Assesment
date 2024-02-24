using DAF.Assesment.Flights.BackgroundWorker.DataOperation;
using DAF.Assesment.Flights.BackgroundWorker.Mapper;
using DAF.Assesment.Flights.BackgroundWorker.NotificationService;
using DAF.Assesment.Flights.BackgroundWorker.OpenSkyServices;
using DAF.Assesment.Flights.Core.ServiceEntities;
using DAF.Assesment.Flights.Utilities;

namespace DAF.Assesment.Flights.BackgroundWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly FlightsClient _flightsClient;
        private readonly MailClient _mailClient;
        private readonly IConfiguration _configuration;
        private Timer? _timer1;
        private Timer? _timer2;
        public Worker(ILogger<Worker> logger, FlightsClient flightsClient, IConfiguration configuration, MailClient mailClient)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _flightsClient = flightsClient ?? throw new ArgumentNullException(nameof(flightsClient));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _mailClient = mailClient ?? throw new ArgumentNullException(nameof(mailClient));
        }
        public override Task StartAsync(CancellationToken cancellationToken)
        {
            int schedulingIntervalInMinutes = _configuration.GetValue<int>("SchedulingTimeIntervalInMinutes");
            int mailSchedulerIntervalinMinutes = _configuration.GetValue<int>("SchedulingTimeIntervalInMinutesForNotification");
            _timer1 = new Timer(async (_) => await RunFlightJob(), null, TimeSpan.Zero, TimeSpan.FromMinutes(schedulingIntervalInMinutes));
            _timer2 = new Timer(async (_) => await RunMailJob(), null, TimeSpan.Zero, TimeSpan.FromMinutes(mailSchedulerIntervalinMinutes));
            return base.StartAsync(cancellationToken);
        }

        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _timer1?.Change(Timeout.Infinite, 0);
            _timer2?.Change(Timeout.Infinite, 0);
            await Task.WhenAll(RunFlightJob(), RunMailJob());
            await base.StopAsync(cancellationToken);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }
        /// <summary>
        /// This Job will fetch the flight Details From open API
        /// </summary>
        /// <returns></returns>
        private async Task RunFlightJob()
        {
            try
            {
                //Since Datetime.Now will not fetch the live data from API so we are taking the start Date from App Config settings to complete the Assesment
                var startDate= _configuration.GetValue<DateTime>("StartDate");
                var endDate = startDate.AddDays(_configuration.GetValue<int>("DayInterval"));
                var startDateTimeEpoch = startDate.ToUnixTimestamp();
                var endDateTimeEpoch = endDate.ToUnixTimestamp();
                // Get all values of the Airport enum
                var airportList = (Airport[])Enum.GetValues(typeof(Airport));
                // Loop through each enum value and create whole list first prior insert for better perfomance and avoid deadlock or time out issues
                foreach (var airport in airportList)
                {
                    var airportId = Convert.ToInt32(airport);
                    List<Flight> departureFlights = null;
                    List<Flight> arrivalFlights = null;

                    // Keep retrying until both departure and arrival flights are successfully retrieved
                    while (departureFlights == null || arrivalFlights == null)
                    {
                        // Get departure flights
                        try
                        {
                            departureFlights = await _flightsClient.GetFlightsByAirport(startDateTimeEpoch, endDateTimeEpoch, FlightServiceType.Departure, airport);
                            // Get arrival flights
                            arrivalFlights = await _flightsClient.GetFlightsByAirport(startDateTimeEpoch, endDateTimeEpoch, FlightServiceType.Arrival, airport);
                        }
                       catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error fetching flights from open sky api"); // As this API is very problematic so hacking not to get iterrupted for other airports if one fails
                        }
                        // Delay before retrying to avoid flooding the server with requests
                        await Task.Delay(1000); // Adjust delay time as needed
                    }
                    if(departureFlights != null && arrivalFlights != null)
                    {
                        departureFlights.AddRange(arrivalFlights);
                        var allFlights = FlightMapper.MapToEntityList(departureFlights, airportId);
                        var dbConnectionString = _configuration.GetSection("ConnectionStrings:DAFAssementDb").Value;

                        if (!string.IsNullOrEmpty(dbConnectionString))
                        {
                            if(allFlights!= null && allFlights.Count > 0)
                            {
                                new Datalayer(dbConnectionString).BulkInsertFlights(allFlights); // Bulk Insert data To avoid Connection pooling inside Loop after Constructing List
                            }
                           
                        }
                    }
                }
               
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching flights from open sky api");
            }
        }

        /// <summary>
        /// This Job will Send Email To the Users Subscribed for the notification
        /// </summary>
        /// <returns></returns>
        private async Task RunMailJob()
        {
            try
            {
                 await _mailClient.SendNotification();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error sending email to user");
            }
        }
    }
}

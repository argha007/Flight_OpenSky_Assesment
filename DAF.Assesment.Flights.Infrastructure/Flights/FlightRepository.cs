using DAF.Assesment.Flights.Core.Entities;
using DAF.Assesment.Flights.Core.Flights;
namespace DAF.Assesment.Flights.Infrastructure.Flights
{
    public class FlightRepository: IFlightRepository
    {
        private readonly DafAssesmentContext _dbContext;
        public FlightRepository(DafAssesmentContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        public IEnumerable<Flight> GetAllFlightsWithAirportName()
        {
            var data = from flight in _dbContext.Flights
                     join airport in _dbContext.Airports
                     on flight.AirportId equals airport.Id
                     select new Flight
                     {
                         AirportName=airport.Name,
                         AirportId=airport.Id,
                         Id=flight.Id,
                         FlightName=flight.FlightName,
                         EstDepartureAirportHorizDistance=flight.EstDepartureAirportHorizDistance,
                         EstDepartureAirport=flight.EstDepartureAirport,
                         EstArrivalAirport = flight.EstArrivalAirport,
                         EstDepartureAirportVertDistance = flight.EstDepartureAirportVertDistance,
                         EstArrivalAirportVertDistance = flight.EstArrivalAirportVertDistance,
                         FirstSeen = flight.FirstSeen,
                         LastSeen = flight.LastSeen,
                         EstArrivalAirportHorizDistance = flight.EstArrivalAirportHorizDistance
                     };
            return data;
        }

        public Flight GetFlightInformationByName(string flightName)
        {
            if (string.IsNullOrEmpty(flightName))
            {
                throw new ArgumentNullException(nameof(flightName), "flightName cannot be null.");
            }
            var flightDetails = _dbContext.Flights.FirstOrDefault(f =>
                    f.FlightName.ToLower() == flightName.ToLower());
            return flightDetails ?? new Flight();
        }
    }
}

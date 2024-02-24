using DAF.Assesment.Flights.Core.ServiceEntities;
using DAF.Assesment.Flights.Utilities;
using Newtonsoft.Json;
namespace DAF.Assesment.Flights.BackgroundWorker.OpenSkyServices
{
    public class FlightsClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _openSkyApiConfiguration;

        public FlightsClient(HttpClient httpClient, IConfiguration openSkyApiConfiguration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _openSkyApiConfiguration = openSkyApiConfiguration ?? throw new ArgumentNullException(nameof(openSkyApiConfiguration));
            _httpClient.Timeout = TimeSpan.FromMinutes(10); // Adjust timeout as needed
        }

        public async Task<List<Flight>> GetFlightsByAirport(long beginTime, long endTime, FlightServiceType flightServiceType, Airport airport)
        {
            // Get ICAO For Airort
            string icaoCode = airport.GetIcaoCode();

            var baseUrl = _openSkyApiConfiguration.GetSection(Constants.BackgroundWorker.Configuration.OpenSkyApiBaseUrl).Value;

            var departureByAirportApi = _openSkyApiConfiguration.GetSection(Constants.BackgroundWorker.Configuration.OpenSkyApiGetDeparturesByAirport).Value;

            var arrivalByAirportApi = _openSkyApiConfiguration.GetSection(Constants.BackgroundWorker.Configuration.OpenSkyApiGetArrivalsByAirport).Value;

            var flightServiceApiEndpoint = flightServiceType == FlightServiceType.Departure ?
                departureByAirportApi : arrivalByAirportApi;
            if (string.IsNullOrEmpty(flightServiceApiEndpoint))
            {
                throw new ArgumentNullException(nameof(flightServiceApiEndpoint));
            }
            string routesApiUrl = $"{baseUrl}" +
                $"{flightServiceApiEndpoint
                    .Replace("{airport}", icaoCode)
                    .Replace("{beginTime}", Convert.ToString(beginTime))
                    .Replace("{endTime}", Convert.ToString(endTime))
                    }";
            
            var response = await _httpClient.GetAsync(routesApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var flightList = JsonConvert.DeserializeObject<List<Flight>>(content);
                if(flightList!=null && flightList.Count != 0)
                {
                    // Sanitize the list by filtering out flights where EstDepartureAirport or EstArrivalAirport is not null
                    if (flightServiceType == FlightServiceType.Departure)
                    {
                        flightList = flightList.FindAll(f => f.EstDepartureAirport != null);
                    }
                    else
                    {
                        flightList = flightList.FindAll(f => f.EstArrivalAirport != null);
                    }
                    return flightList;
                }
                else
                {
                    return new List<Flight>();
                }
            }
            else
            {
                throw new HttpRequestException($"Failed to fetch flight details for the {airport} in interval between {beginTime} and {endTime}. Status code: {response.StatusCode}");
            }
        }
    }
}

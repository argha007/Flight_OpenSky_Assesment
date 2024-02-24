using DAF.Assesment.Flights.Core.Entities;
using DAF.Assesment.Flights.Core.Flights;

namespace DAF.Assesment.Flights.Application.Flights
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flightRepository;

        public FlightService(IFlightRepository flightRepository)
        {
            _flightRepository = flightRepository ?? throw new ArgumentNullException(nameof(flightRepository));
        }
        public List<Flight> GetAllFlights()
        {
            var allFlights = _flightRepository.GetAllFlightsWithAirportName().ToList();
            //Logic To Calculate Expected Arival Time and Departurture Time, core logic will be part of DAF.Assesment.Flights.Core Project
            return allFlights.ToList();
        }
    }
}

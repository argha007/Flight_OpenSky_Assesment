using DAF.Assesment.Flights.Core.Entities;

namespace DAF.Assesment.Flights.Core.Flights
{
    public interface IFlightRepository
    {
        IEnumerable<Flight> GetAllFlightsWithAirportName();
        Flight GetFlightInformationByName(string flightName);
    }
}

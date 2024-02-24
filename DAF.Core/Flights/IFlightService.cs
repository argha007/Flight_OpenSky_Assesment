using DAF.Assesment.Flights.Core.Entities;
namespace DAF.Assesment.Flights.Core.Flights
{
    public interface IFlightService
    {
        List<Flight> GetAllFlights();
    }
}

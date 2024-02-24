using DAF.Assesment.Flights.Core.Entities;
using Xunit;

namespace DAF.Assesment.Flights.Core.Tests.Entities;


public class FlightTest
{
    public class The_Class
    {
        [Fact]
        [Trait("Category", "Unit")]
        public void Flight_Properties_Should_Be_Set_Correctly()
        {
            // Arrange
            var flight = new Flight
            {
                Id = 1,
                AirportId = 1001,
                FlightName = "ABC123",
                FirstSeenUnixTimeStamp = 1614566400, // Some Unix timestamp value
                EstDepartureAirport = "DEP",
                LastSeenUnixTimeStamp = 1614577200, // Some Unix timestamp value
                EstArrivalAirport = "ARR",
                Callsign = "XYZ",
                EstDepartureAirportHorizDistance = 500,
                EstDepartureAirportVertDistance = 50,
                EstArrivalAirportHorizDistance = 600,
                EstArrivalAirportVertDistance = 60,
                DepartureAirportCandidatesCount = 3,
                ArrivalAirportCandidatesCount = 4,
                FirstSeen = new DateTime(2022, 02, 28, 10, 0, 0), // Some DateTime value
                LastSeen = new DateTime(2022, 02, 28, 12, 0, 0), // Some DateTime value
                AirportName = "Test Airport"
            };

            // Act (no action needed)

            // Assert
            Assert.Equal(1, flight.Id);
            Assert.Equal(1001, flight.AirportId);
            Assert.Equal("ABC123", flight.FlightName);
            Assert.Equal(1614566400, flight.FirstSeenUnixTimeStamp);
            Assert.Equal("DEP", flight.EstDepartureAirport);
            Assert.Equal(1614577200, flight.LastSeenUnixTimeStamp);
            Assert.Equal("ARR", flight.EstArrivalAirport);
            Assert.Equal("XYZ", flight.Callsign);
            Assert.Equal(500, flight.EstDepartureAirportHorizDistance);
            Assert.Equal(50, flight.EstDepartureAirportVertDistance);
            Assert.Equal(600, flight.EstArrivalAirportHorizDistance);
            Assert.Equal(60, flight.EstArrivalAirportVertDistance);
            Assert.Equal(3, flight.DepartureAirportCandidatesCount);
            Assert.Equal(4, flight.ArrivalAirportCandidatesCount);
            Assert.Equal(new DateTime(2022, 02, 28, 10, 0, 0), flight.FirstSeen);
            Assert.Equal(new DateTime(2022, 02, 28, 12, 0, 0), flight.LastSeen);
            Assert.Equal("Test Airport", flight.AirportName);
        }
    }
}


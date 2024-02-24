using DAF.Assesment.Flights.Core.Entities;
using Xunit;

namespace DAF.Assesment.Flights.Core.Tests.Entities;

public class AirportTest
{
    [Fact]

    [Trait("Category", "Unit")]
    public void Airport_Properties_Should_Be_Set_Correctly()
    {
        // Arrange
        var airport = new Airport
        {
            Id = 1,
            Name = "Test Airport",
            Icao = "TEST",
            Latitude = 40.7128,
            Longitude = -74.0060
        };

        // Act (no action needed)

        // Assert
        Assert.Equal(1, airport.Id);
        Assert.Equal("Test Airport", airport.Name);
        Assert.Equal("TEST", airport.Icao);
        Assert.Equal(40.7128, airport.Latitude);
        Assert.Equal(-74.0060, airport.Longitude);
    }
}

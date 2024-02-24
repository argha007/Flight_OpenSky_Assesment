using DAF.Assesment.Flights.Core.Entities;
using Xunit;

namespace DAF.Assesment.Flights.Core.Tests.Entities;
public class UserEmailTest
{
    [Fact]
    public void UserEmail_Properties_Should_Be_Set_Correctly()
    {
        // Arrange
        var userEmail = new UserEmail
        {
            Id = 1,
            UserEmail1 = "test@example.com",
            FlightId = 123,
            HasNotified = true,
            NotificationTime = new DateTime(2024, 2, 28, 10, 30, 0)
        };

        // Act (no action needed)

        // Assert
        Assert.Equal(1, userEmail.Id);
        Assert.Equal("test@example.com", userEmail.UserEmail1);
        Assert.Equal(123, userEmail.FlightId);
        Assert.True(userEmail.HasNotified);
        Assert.Equal(new DateTime(2024, 2, 28, 10, 30, 0), userEmail.NotificationTime);
    }
}

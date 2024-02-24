namespace DAF.Assesment.Flights.Core.Entities;

public partial class UserEmail
{
    public int Id { get; set; }

    public string UserEmail1 { get; set; } = null!;

    public int FlightId { get; set; }

    public bool? HasNotified { get; set; }

    public DateTime? NotificationTime { get; set; }
}

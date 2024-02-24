namespace DAF.Assesment.Flights.Core.Entities;

public partial class Airport
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Icao { get; set; } = null!;

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }
}

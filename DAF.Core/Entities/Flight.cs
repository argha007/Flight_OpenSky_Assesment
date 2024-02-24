namespace DAF.Assesment.Flights.Core.Entities;

public partial class Flight
{
    public int Id { get; set; }

    public int AirportId { get; set; }

    public string? FlightName { get; set; }

    public long? FirstSeenUnixTimeStamp { get; set; }

    public string? EstDepartureAirport { get; set; }

    public long? LastSeenUnixTimeStamp { get; set; }

    public string? EstArrivalAirport { get; set; }

    public string? Callsign { get; set; }

    public int? EstDepartureAirportHorizDistance { get; set; }

    public int? EstDepartureAirportVertDistance { get; set; }

    public int? EstArrivalAirportHorizDistance { get; set; }

    public int? EstArrivalAirportVertDistance { get; set; }

    public int? DepartureAirportCandidatesCount { get; set; }

    public int? ArrivalAirportCandidatesCount { get; set; }

    public DateTime? FirstSeen { get; set; }

    public DateTime? LastSeen { get; set; }

    public string? AirportName { get; set; }
}

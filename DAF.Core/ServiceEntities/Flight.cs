using DAF.Assesment.Flights.Utilities;
using Newtonsoft.Json;
namespace DAF.Assesment.Flights.Core.ServiceEntities
{
    public class Flight
    {
        [JsonProperty("icao24")]
        public string Callsign { get; set; }

        [JsonProperty("firstSeen")]
        public long? FirstSeenUnixTimeStamp { get; set; }

        [JsonProperty("estDepartureAirport")]
        public string EstDepartureAirport { get; set; }

        [JsonProperty("lastSeen")]
        public long? LastSeenUnixTimeStamp { get; set; }

        [JsonProperty("estArrivalAirport")]
        public string EstArrivalAirport { get; set; }

        [JsonProperty("callsign")]
        public string FlightName { get; set; }

        [JsonProperty("estDepartureAirportHorizDistance")]
        public int? EstDepartureAirportHorizDistance { get; set; }

        [JsonProperty("estDepartureAirportVertDistance")]
        public int? EstDepartureAirportVertDistance { get; set; }

        [JsonProperty("estArrivalAirportHorizDistance")]
        public int? EstArrivalAirportHorizDistance { get; set; }

        [JsonProperty("estArrivalAirportVertDistance")]
        public int? EstArrivalAirportVertDistance { get; set; }

        [JsonProperty("departureAirportCandidatesCount")]
        public int? DepartureAirportCandidatesCount { get; set; }

        [JsonProperty("arrivalAirportCandidatesCount")]
        public int? ArrivalAirportCandidatesCount { get; set; }

        public DateTime? FirstSeen
        {
            get
            {
                if (FirstSeenUnixTimeStamp.HasValue)
                {
                    // Convert Unix timestamp to DateTime
                    return FirstSeenUnixTimeStamp.Value.ToNormalDateTime();
                }
                return null;
            }
        }

        public DateTime? LastSeen
        {
            get
            {
                if (LastSeenUnixTimeStamp.HasValue)
                {
                    // Convert Unix timestamp to DateTime
                    return LastSeenUnixTimeStamp.Value.ToNormalDateTime();
                }
                return null;
            }
        }
    }

}

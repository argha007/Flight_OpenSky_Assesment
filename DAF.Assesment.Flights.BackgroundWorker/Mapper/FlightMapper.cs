namespace DAF.Assesment.Flights.BackgroundWorker.Mapper
{
    public static class FlightMapper
    {
        public static List<Core.Entities.Flight>? MapToEntityList(List<Core.ServiceEntities.Flight> sourceList,int airportId)
        {
            if (sourceList == null)
            {
                return null;
            }

            var resultList = new List<Core.Entities.Flight>();

            foreach (var sourceFlight in sourceList)
            {
                var entity = MapToEntity(sourceFlight, airportId);
                if(entity!=null)
                {
                    resultList.Add(entity);
                }
            }
            return resultList;
        }

        public static Core.Entities.Flight? MapToEntity(Core.ServiceEntities.Flight source,  int airportId)
        {
            if (source == null)
            {
                return null;
            }
                

            return new Core.Entities.Flight
            {
                AirportId = airportId,
                FlightName = source.FlightName,
                FirstSeenUnixTimeStamp = source.FirstSeenUnixTimeStamp,
                EstDepartureAirport = source.EstDepartureAirport,
                LastSeenUnixTimeStamp = source.LastSeenUnixTimeStamp,
                EstArrivalAirport = source.EstArrivalAirport,
                Callsign = source.Callsign,
                EstDepartureAirportHorizDistance = source.EstDepartureAirportHorizDistance,
                EstDepartureAirportVertDistance = source.EstDepartureAirportVertDistance,
                EstArrivalAirportHorizDistance = source.EstArrivalAirportHorizDistance,
                EstArrivalAirportVertDistance = source.EstArrivalAirportVertDistance,
                DepartureAirportCandidatesCount = source.DepartureAirportCandidatesCount,
                ArrivalAirportCandidatesCount = source.ArrivalAirportCandidatesCount,
                FirstSeen = source.FirstSeen,
                LastSeen = source.LastSeen
            };
        }
    }
}

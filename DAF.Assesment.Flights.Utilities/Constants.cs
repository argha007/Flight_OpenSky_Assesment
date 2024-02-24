namespace DAF.Assesment.Flights.Utilities
{
    public static class Constants
    {
        public class Aircraft
        {
            public static int AverageSpeed = 800; // For Sake Of Calculation of estimated Departure Time/ Arrival time Considered Average Speed of Aircraft
        }

        public class BackgroundWorker
        {
            public class FlightDataTable()
            {
                public static string AirportId = "AirportId";
                public static string FlightName = "FlightName";
                public static string FirstSeenUnixTimeStamp = "FirstSeenUnixTimeStamp";
                public static string EstDepartureAirport = "EstDepartureAirport";
                public static string LastSeenUnixTimeStamp = "LastSeenUnixTimeStamp";
                public static string EstArrivalAirport = "EstArrivalAirport";
                public static string Callsign = "Callsign";
                public static string EstDepartureAirportHorizDistance = "EstDepartureAirportHorizDistance";
                public static string EstDepartureAirportVertDistance = "EstDepartureAirportVertDistance";
                public static string EstArrivalAirportHorizDistance = "EstArrivalAirportHorizDistance";
                public static string EstArrivalAirportVertDistance = "EstArrivalAirportVertDistance";
                public static string DepartureAirportCandidatesCount = "DepartureAirportCandidatesCount";
                public static string ArrivalAirportCandidatesCount = "ArrivalAirportCandidatesCount";
                public static string FirstSeen = "FirstSeen";
                public static string LastSeen = "LastSeen";
            }

            public class Configuration()
            {
                public static string OpenSkyApiBaseUrl = "OpenSkyApi:BaseUrl";
                public static string OpenSkyApiGetDeparturesByAirport = "OpenSkyApi:GetDeparturesByAirport";
                public static string OpenSkyApiGetArrivalsByAirport = "OpenSkyApi:GetArrivalsByAirport";
               
            }

            public class EmailTemplate()
            {
                public static string EmailTitle = "Flight About To Arrive {flightNumber}";
                public static string EmailBody = "<b>Flight with {flightNumber} is arriving on {airport} at {estimatedArrivalTime}</b>";

            }

            public static string FlightInsertStoredProcedure = "sp_BulkInsertFlights";
            public static string FlightInsertStoredProcedureParameter = "@Flights";
        }
        
    }
}

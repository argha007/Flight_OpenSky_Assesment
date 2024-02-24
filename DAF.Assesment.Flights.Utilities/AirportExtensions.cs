namespace DAF.Assesment.Flights.Utilities
{
    public static class AirportExtensions
    {
        public static string GetIcaoCode(this Airport airport)
        {
            switch (airport)
            {
                case Airport.Ronald_Reagan_Washington_National_Airport:
                    return "KDCA";
                case Airport.Amsterdam_Airport_Schiphol:
                    return "EHAM";
                case Airport.Indira_Gandhi_International_Airport:
                    return "VIDP";
                default:
                    throw new ArgumentOutOfRangeException(nameof(airport), airport, null);
            }
        }

        public static string GetName(this Airport airport)
        {
            return airport switch
            {
                Airport.Ronald_Reagan_Washington_National_Airport => "Ronald Reagan Washington National Airport",
                Airport.Amsterdam_Airport_Schiphol => "Amsterdam Airport Schiphol",
                Airport.Indira_Gandhi_International_Airport => "Indira Gandhi International Airport",
                _ => throw new ArgumentOutOfRangeException(nameof(airport), airport, null),
            };
        }
    }
}

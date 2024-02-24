namespace DAF.Assesment.Flights.Utilities
{
    public static class DateTimeExtensions
    {
        // Extension method to convert DateTime to Unix timestamp in seconds
        public static long ToUnixTimestamp(this DateTime dateTime)
        {
            return (long)(dateTime.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }

        // Extension method to convert Unix timestamp in seconds to DateTime
        public static DateTime ToNormalDateTime(this long unixTimestamp)
        {
            return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(unixTimestamp).ToLocalTime();
        }
    }
}

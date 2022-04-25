using System;

namespace Izmainas.API.Helpers
{
    public static class DateTimeHelper
    {
        public static long ToTimestamp(this DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeSeconds();
        }

        public static DateTime ToDateTime(this long timestamp)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return dateTimeOffset.DateTime;
        }
    }
}

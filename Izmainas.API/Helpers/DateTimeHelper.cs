using System;

namespace Izmainas.API.Helpers
{
    /// <summary>
    /// Class used for Date manipulations
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Method used for converting to timestamp
        /// </summary>
        /// <param name="date">DateTime to convert</param>
        /// <returns>Timestamp in seconds</returns>
        public static long ToTimestamp(this DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeSeconds();
        }

        /// <summary>
        /// Method used for converting to DateTime
        /// </summary>
        /// <param name="timestamp">Timestamp to convert</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return dateTimeOffset.DateTime;
        }
    }
}

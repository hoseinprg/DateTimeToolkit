using System;

namespace DateTimeToolkit.Library.Extensions
{
    public static class CurrentDateTimeExtension
    {
        /// <summary>
        /// Gets the current local date and time.
        /// </summary>
        /// <returns>The current local date and time.</returns>
        /// <example>
        /// Output: The current local date and time, e.g., new DateTime(2023, 6, 22, 15, 30, 0)
        /// </example>
        public static DateTime GetLocalDateTime()
        {
            return DateTime.Now;
        }

        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        /// <returns>The current UTC date and time.</returns>
        /// <example>
        /// Output: The current UTC date and time, e.g., new DateTime(2023, 6, 22, 22, 30, 0, DateTimeKind.Utc)
        /// </example>
        public static DateTime GetUtcDateTime()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the current UTC time.
        /// </summary>
        /// <returns>The current UTC time.</returns>
        /// <example>
        /// Input: none
        /// Output: The current date and time in UTC.
        /// </example>
        public static DateTime GetCurrentUtcTime()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Gets the current UTC time.
        /// </summary>
        /// <returns>The current UTC time.</returns>
        /// <example>
        /// Input: none
        /// Output: The current date and time in UTC.
        /// </example>
        public static DateTime GetUtcNow()
        {
            return DateTime.UtcNow;
        }

        /// <summary>
        /// Returns the start of the day for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the start of the day for.</param>
        /// <returns>The start of the day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 0, 0, 0)
        /// </example>
        public static DateTime StartOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
        }

        /// <summary>
        /// Returns the end of the day for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the end of the day for.</param>
        /// <returns>The end of the day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 23, 59, 59, 999)
        /// </example>
        public static DateTime EndOfDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 23, 59, 59, 999, dateTime.Kind);
        }

        /// <summary>
        /// Returns the start of the hour for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the start of the hour for.</param>
        /// <returns>The start of the hour.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 10, 0, 0)
        /// </example>
        public static DateTime StartOfHour(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 0, 0, dateTime.Kind);
        }

        /// <summary>
        /// Returns the end of the hour for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the end of the hour for.</param>
        /// <returns>The end of the hour.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 10, 59, 59, 999)
        /// </example>
        public static DateTime EndOfHour(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, 59, 59, 999, dateTime.Kind);
        }

        /// <summary>
        /// Returns the start of the minute for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the start of the minute for.</param>
        /// <returns>The start of the minute.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 10, 30, 0)
        /// </example>
        public static DateTime StartOfMinute(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 0, dateTime.Kind);
        }

        /// <summary>
        /// Returns the end of the minute for the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to get the end of the minute for.</param>
        /// <returns>The end of the minute.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: new DateTime(2023, 12, 24, 10, 30, 59, 999)
        /// </example>
        public static DateTime EndOfMinute(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, 59, 999, dateTime.Kind);
        }
    }
}

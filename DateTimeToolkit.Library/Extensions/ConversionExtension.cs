using System;
using System.Globalization;

namespace DateTimeToolkit.Library.Extensions
{
    public static class ConversionExtension
    {
        /// <summary>
        /// Converts a date string to DateTime using the specified format.
        /// </summary>
        /// <param name="dateString">The date string to convert.</param>
        /// <param name="format">The format of the date string.</param>
        /// <returns>The converted DateTime.</returns>
        /// <example>
        /// Input: dateString="2023-06-01", format="yyyy-MM-dd"
        /// Output: new DateTime(2023, 6, 1)
        /// </example>
        public static DateTime ToDateTime(string dateString, string format)
        {
            return DateTime.ParseExact(dateString, format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a DateTime to string using the specified format.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <param name="format">The format to use for conversion.</param>
        /// <returns>The formatted date string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), format="yyyy-MM-dd"
        /// Output: "2023-06-01"
        /// </example>
        public static string ToString(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// Converts the date to the specified time zone.
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="targetTimeZone">The target time zone.</param>
        /// <returns>The date converted to the specified time zone.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0), targetTimeZone=TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
        /// Output: The corresponding date and time in Pacific Standard Time.
        /// </example>
        public static DateTime ConvertToTimeZone(DateTime dateTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTime(dateTime, targetTimeZone);
        }

        /// <summary>
        /// Converts the UTC date to the specified time zone.
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <param name="targetTimeZone">The target time zone.</param>
        /// <returns>The date converted to the specified time zone.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc), targetTimeZone=TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time")
        /// Output: The corresponding date and time in Pacific Standard Time.
        /// </example>
        public static DateTime ConvertFromUtc(DateTime dateTime, TimeZoneInfo targetTimeZone)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(dateTime, targetTimeZone);
        }

        /// <summary>
        /// Converts the UTC date to local time.
        /// </summary>
        /// <param name="dateTime">The UTC date to convert.</param>
        /// <returns>The date converted to local time.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc)
        /// Output: The corresponding local date and time.
        /// </example>
        public static DateTime ConvertToLocal(DateTime dateTime)
        {
            return dateTime.ToLocalTime();
        }

        /// <summary>
        /// Converts the local date to UTC time.
        /// </summary>
        /// <param name="dateTime">The local date to convert.</param>
        /// <returns>The date converted to UTC time.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Local)
        /// Output: The corresponding date and time in UTC.
        /// </example>
        public static DateTime ConvertToUtc(DateTime dateTime)
        {
            return dateTime.ToUniversalTime();
        }

        /// <summary>
        /// Converts the date to ISO 8601 string format.
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <returns>The date as an ISO 8601 string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc)
        /// Output: "2023-06-01T12:00:00.0000000Z"
        /// </example>
        public static string GetIso8601String(DateTime dateTime)
        {
            return dateTime.ToString("o");
        }

        /// <summary>
        /// Parses the ISO 8601 string to DateTime.
        /// </summary>
        /// <param name="dateString">The ISO 8601 string to parse.</param>
        /// <returns>The parsed DateTime.</returns>
        /// <example>
        /// Input: dateString="2023-06-01T12:00:00.0000000Z"
        /// Output: new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc)
        /// </example>
        public static DateTime ParseIso8601String(string dateString)
        {
            return DateTime.Parse(dateString, null, DateTimeStyles.RoundtripKind);
        }

        /// <summary>
        /// Converts the date to a string with the specified custom format.
        /// </summary>
        /// <param name="dateTime">The date to convert.</param>
        /// <param name="format">The custom format string.</param>
        /// <returns>The date as a formatted string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 12, 0, 0), format="yyyy-MM-dd HH:mm:ss"
        /// Output: "2023-06-01 12:00:00"
        /// </example>
        public static string GetCustomFormattedString(DateTime dateTime, string format)
        {
            return dateTime.ToString(format);
        }

        /// <summary>
        /// Gets the name of the day for the specified date.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The name of the day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "Sunday"
        /// </example>
        public static string GetDayName(this DateTime dateTime)
        {
            return dateTime.ToString("dddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the abbreviated name of the day for the specified date.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The abbreviated name of the day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "Sun"
        /// </example>
        public static string GetAbbreviatedDayName(this DateTime dateTime)
        {
            return dateTime.ToString("ddd", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a formatted string with the day name.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A formatted string with the day name.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "Sunday, 24 December 2023"
        /// </example>
        public static string ToDateStringWithDayName(this DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a short date string with the abbreviated day name.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A short date string with the abbreviated day name.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "Sun, 24 Dec 2023"
        /// </example>
        public static string ToShortDateStringWithDayName(this DateTime dateTime)
        {
            return dateTime.ToString("ddd, dd MMM yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a formatted time string.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A formatted time string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: "10:30:00"
        /// </example>
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a short time string.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A short time string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: "10:30"
        /// </example>
        public static string ToShortTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a full date and time string.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A full date and time string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: "Sunday, 24 December 2023 10:30:00"
        /// </example>
        public static string ToFullDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a short date and time string.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>A short date and time string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: "24/12/2023 10:30"
        /// </example>
        public static string ToShortDateTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the specified date to a custom format string.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <param name="format">The custom format.</param>
        /// <returns>A custom format date string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), format="yyyy-MM-dd"
        /// Output: "2023-12-24"
        /// </example>
        public static string ToCustomFormatString(this DateTime dateTime, string format)
        {
            return dateTime.ToString(format, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the name of the month for the specified date.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The name of the month.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "December"
        /// </example>
        public static string GetMonthName(this DateTime dateTime)
        {
            return dateTime.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the abbreviated name of the month for the specified date.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The abbreviated name of the month.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "Dec"
        /// </example>
        public static string GetAbbreviatedMonthName(this DateTime dateTime)
        {
            return dateTime.ToString("MMM", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the year as a string for the specified date.
        /// </summary>
        /// <param name="dateTime">The date.</param>
        /// <returns>The year as a string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: "2023"
        /// </example>
        public static string GetYearAsString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts the TimeSpan to a string with the format "HH:mm:ss".
        /// </summary>
        /// <param name="timeSpan">The TimeSpan to format.</param>
        /// <returns>The formatted time string.</returns>
        /// <example>
        /// Input: timeSpan=new TimeSpan(10, 30, 0)
        /// Output: "10:30:00"
        /// </example>
        public static string ToTimeString(this TimeSpan timeSpan)
        {
            return timeSpan.ToString(@"hh\:mm\:ss");
        }

        /// <summary>
        /// Returns a DateTime with the same date as the given DateTime, but with the time set to the specified hours, minutes, and seconds.
        /// </summary>
        /// <param name="dateTime">The DateTime to set the time for.</param>
        /// <param name="hours">The hours to set.</param>
        /// <param name="minutes">The minutes to set.</param>
        /// <param name="seconds">The seconds to set.</param>
        /// <returns>The resulting DateTime.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), hours=10, minutes=30, seconds=0
        /// Output: new DateTime(2023, 12, 24, 10, 30, 0)
        /// </example>
        public static DateTime SetTime(this DateTime dateTime, int hours, int minutes, int seconds)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, hours, minutes, seconds, dateTime.Kind);
        }

        /// <summary>
        /// Returns a TimeSpan representing the time elapsed since the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to calculate the time elapsed from.</param>
        /// <returns>The time elapsed since the given DateTime.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: TimeSpan representing elapsed time until now
        /// </example>
        public static TimeSpan TimeElapsedSince(this DateTime dateTime)
        {
            return DateTime.Now - dateTime;
        }

        /// <summary>
        /// Returns a TimeSpan representing the time remaining until the given DateTime.
        /// </summary>
        /// <param name="dateTime">The DateTime to calculate the time remaining until.</param>
        /// <returns>The time remaining until the given DateTime.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: TimeSpan representing remaining time until specified date
        /// </example>
        public static TimeSpan TimeRemainingUntil(this DateTime dateTime)
        {
            return dateTime - DateTime.Now;
        }

        /// <summary>
        /// Converts a DateTime to a DateTimeOffset with the local time zone offset.
        /// </summary>
        /// <param name="dateTime">The DateTime to convert.</param>
        /// <returns>The resulting DateTimeOffset.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0)
        /// Output: DateTimeOffset with local time zone offset
        /// </example>
        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
        {
            return new DateTimeOffset(dateTime);
        }

        /// <summary>
        /// Converts a TimeSpan to a human-readable string format.
        /// </summary>
        /// <param name="timeSpan">The TimeSpan to format.</param>
        /// <returns>The formatted human-readable string.</returns>
        /// <example>
        /// Input: timeSpan=new TimeSpan(2, 10, 30, 0)
        /// Output: "2 days 10 hours"
        /// </example>
        public static string ToHumanReadableString(this TimeSpan timeSpan)
        {
            if (timeSpan.TotalMinutes < 1)
                return $"{timeSpan.Seconds} seconds";
            if (timeSpan.TotalHours < 1)
                return $"{timeSpan.Minutes} minutes {timeSpan.Seconds} seconds";
            if (timeSpan.TotalDays < 1)
                return $"{timeSpan.Hours} hours {timeSpan.Minutes} minutes";

            return $"{timeSpan.Days} days {timeSpan.Hours} hours";
        }

        /// <summary>
        /// Formats a date based on a specific culture.
        /// </summary>
        /// <param name="dateTime">The DateTime to format.</param>
        /// <param name="format">The format string.</param>
        /// <param name="cultureName">The name of the culture.</param>
        /// <returns>The formatted date string.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), format="yyyy-MM-dd", cultureName="en-US"
        /// Output: "2023-12-24"
        /// </example>
        public static string ToStringWithCulture(DateTime dateTime, string format, string cultureName)
        {
            CultureInfo culture = new CultureInfo(cultureName);
            return dateTime.ToString(format, culture);
        }
    }
}

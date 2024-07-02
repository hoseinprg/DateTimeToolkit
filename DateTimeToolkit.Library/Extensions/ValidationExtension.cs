using DateTimeToolkit.Library.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DateTimeToolkit.Library.Extensions
{
    public static class ValidationExtension
    {

        private static readonly CultureInfo _culture = new CultureInfo("en-US");


        /// <summary>
        /// Checks if the date string is valid according to the specified format.
        /// </summary>
        /// <param name="dateString">The date string to validate.</param>
        /// <param name="format">The format to validate against.</param>
        /// <returns>True if the date string is valid; otherwise, false.</returns>
        /// <example>
        /// Input: dateString="2023-06-01", format="yyyy-MM-dd"
        /// Output: true
        /// </example>
        public static bool IsValidDate(string dateString, string format)
        {
            return DateTime.TryParseExact(dateString, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        /// <summary>
        /// Checks if the specified year is a leap year.
        /// </summary>
        /// <param name="year">The year to check.</param>
        /// <returns>True if the year is a leap year; otherwise, false.</returns>
        /// <example>
        /// Input: year=2024
        /// Output: true
        /// </example>
        public static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }

        /// <summary>
        /// Checks if the specified date is a holiday.
        /// </summary>
        /// <param name="dateTime">The date to check.</param>
        /// <param name="holidays">A list of holidays.</param>
        /// <returns>True if the date is a holiday, otherwise false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 25), holidays=new List<DateTime> { new DateTime(2023, 12, 25), new DateTime(2023, 1, 1) }
        /// Output: true
        /// </example>
        public static bool IsHoliday(DateTime dateTime, List<DateTime> holidays)
        {
            return holidays.Contains(dateTime.Date);
        }

        /// <summary>
        /// Checks if the specified date is a public holiday.
        /// </summary>
        /// <param name="dateTime">The date to check.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <returns>True if the date is a public holiday, otherwise false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 25), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: true
        /// </example>
        public static bool IsPublicHoliday(DateTime dateTime, List<DateTime> publicHolidays)
        {
            return publicHolidays.Contains(dateTime.Date);
        }

        /// <summary>
        /// Checks if the specified date is a weekend or public holiday.
        /// </summary>
        /// <param name="dateTime">The date to check.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>True if the date is a weekend or public holiday, otherwise false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 25)
        /// Output: true
        /// </example>
        public static bool IsWeekend(this DateTime dateTime, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            return weekendDays.Contains(dateTime.DayOfWeek);
        }
    }
}

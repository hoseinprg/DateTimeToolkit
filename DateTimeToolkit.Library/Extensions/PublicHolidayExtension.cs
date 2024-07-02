using DateTimeToolkit.Library.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DateTimeToolkit.Library.Extensions
{
    public static class PublicHolidayExtension
    {
        private static readonly CultureInfo _culture = new CultureInfo("en-US");


        /// <summary>
        /// Gets the next public holiday after the specified date.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <returns>The next public holiday date, or null if there are no public holidays after the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: new DateTime(2023, 12, 25)
        /// </example>
        public static DateTime? GetNextPublicHoliday(DateTime dateTime, List<DateTime> publicHolidays)
        {
            return publicHolidays.Where(h => h > dateTime).OrderBy(h => h).FirstOrDefault();
        }

        /// <summary>
        /// Gets the previous public holiday before the specified date.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <returns>The previous public holiday date, or null if there are no public holidays before the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: new DateTime(2023, 12, 25)
        /// </example>
        public static DateTime? GetPreviousPublicHoliday(DateTime dateTime, List<DateTime> publicHolidays)
        {
            return publicHolidays.Where(h => h < dateTime).OrderByDescending(h => h).FirstOrDefault();
        }



        /// <summary>
        /// Checks if the specified date is a weekend or public holiday.
        /// </summary>
        /// <param name="dateTime">The date to check.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>True if the date is a weekend or public holiday, otherwise false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 25), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: true
        /// </example>
        public static bool IsWeekendOrHoliday(this DateTime dateTime, List<DateTime> publicHolidays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            return weekendDays.Contains(dateTime.DayOfWeek) || ValidationExtension.IsPublicHoliday(dateTime, publicHolidays);
        }

        /// <summary>
        /// Gets a list of public holidays between two dates.
        /// </summary>
        /// <param name="start">The starting date (inclusive).</param>
        /// <param name="end">The ending date (inclusive).</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <returns>A list of public holidays within the specified date range.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 24), end=new DateTime(2024, 1, 1), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: { new DateTime(2023, 12, 25) }
        /// </example>
        public static List<DateTime> GetPublicHolidaysInRange(DateTime start, DateTime end, List<DateTime> publicHolidays)
        {
            return publicHolidays.Where(h => h >= start && h <= end).OrderBy(h => h).ToList();
        }

        /// <summary>
        /// Gets the next working day after the specified date, considering public holidays.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The next working day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: new DateTime(2023, 12, 26)
        /// </example>
        public static DateTime GetNextWorkingDayConsideringHolidays(DateTime dateTime, List<DateTime> publicHolidays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            DateTime nextDay = dateTime.AddDays(1);
            while (nextDay.IsWeekendOrHoliday(publicHolidays, culture))
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Gets the number of working days between two dates, considering public holidays.
        /// </summary>
        /// <param name="start">The starting date (inclusive).</param>
        /// <param name="end">The ending date (inclusive).</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The number of working days.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 24), end=new DateTime(2023, 12, 31), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: 5
        /// </example>
        public static int GetWorkingDaysConsideringHolidays(DateTime start, DateTime end, List<DateTime> publicHolidays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            int totalDays = (int)(end - start).TotalDays;
            int workingDays = 0;
            for (int i = 0; i <= totalDays; i++)
            {
                DateTime current = start.AddDays(i);
                if (!current.IsWeekendOrHoliday(publicHolidays, culture))
                {
                    workingDays++;
                }
            }
            return workingDays;
        }

        /// <summary>
        /// Gets the nearest public holiday before or after the specified date.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <returns>The nearest public holiday date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: new DateTime(2023, 12, 25)
        /// </example>
        public static DateTime? GetNearestPublicHoliday(DateTime dateTime, List<DateTime> publicHolidays)
        {
            DateTime? nextHoliday = GetNextPublicHoliday(dateTime, publicHolidays);
            DateTime? previousHoliday = GetPreviousPublicHoliday(dateTime, publicHolidays);

            if (nextHoliday == null) return previousHoliday;
            if (previousHoliday == null) return nextHoliday;

            TimeSpan nextDiff = nextHoliday.Value - dateTime;
            TimeSpan prevDiff = dateTime - previousHoliday.Value;

            return nextDiff < prevDiff ? nextHoliday : previousHoliday;
        }
    }
}

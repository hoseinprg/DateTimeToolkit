using DateTimeToolkit.Library.Common;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DateTimeToolkit.Library.Extensions
{
    public static class BusinessDayExtension
    {
        private static readonly CultureInfo _culture = new CultureInfo("en-US");


        /// <summary>
        /// Adds business days to the specified date.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="businessDays">The number of business days to add (can be negative to subtract business days).</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The date after adding the specified number of business days.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), businessDays=5
        /// Output: new DateTime(2023, 12, 31)
        /// </example>
        public static DateTime AddBusinessDays(this DateTime dateTime, int businessDays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            int direction = businessDays < 0 ? -1 : 1;
            while (businessDays != 0)
            {
                dateTime = dateTime.AddDays(direction);
                if (!weekendDays.Contains(dateTime.DayOfWeek))
                {
                    businessDays -= direction;
                }
            }
            return dateTime;
        }

        /// <summary>
        /// Gets the next business day after the specified date.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The next business day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: new DateTime(2023, 12, 26)
        /// </example>
        public static DateTime GetNextBusinessDay(this DateTime dateTime, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            DateTime nextDay = dateTime.AddDays(1);
            while (weekendDays.Contains(nextDay.DayOfWeek))
            {
                nextDay = nextDay.AddDays(1);
            }
            return nextDay;
        }

        /// <summary>
        /// Adds business days to the specified date, considering public holidays.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="businessDays">The number of business days to add (can be negative to subtract business days).</param>
        /// <param name="publicHolidays">A list of public holidays.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The date after adding the specified number of business days, excluding weekends and public holidays.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), businessDays=5, publicHolidays=new List<DateTime> { new DateTime(2023, 12, 25) }
        /// Output: new DateTime(2023, 12, 31)
        /// </example>
        public static DateTime AddBusinessDaysConsideringHolidays(this DateTime dateTime, int businessDays, List<DateTime> publicHolidays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            int direction = businessDays < 0 ? -1 : 1;
            while (businessDays != 0)
            {
                dateTime = dateTime.AddDays(direction);
                if (!weekendDays.Contains(dateTime.DayOfWeek) && !ValidationExtension.IsPublicHoliday(dateTime, publicHolidays))
                {
                    businessDays -= direction;
                }
            }
            return dateTime;
        }

        /// <summary>
        /// Gets the next working day after the specified date, considering the provided holidays.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="holidays">A list of holidays.</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture (en-US).</param>
        /// <returns>The next working day.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24), holidays=new List<DateTime> { new DateTime(2023, 12, 25) }, culture=new CultureInfo("en-US")
        /// Output: new DateTime(2023, 12, 26)
        /// </example>
        public static DateTime GetNextWorkingDay(this DateTime dateTime, List<DateTime> holidays, CultureInfo culture = null)
        {
            if (culture == null)
                culture = CultureInfo.CurrentCulture; // Use the current culture if none is provided

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            DateTime nextDay = dateTime.AddDays(1);

            while (ValidationExtension.IsHoliday(nextDay, holidays) || Array.IndexOf(weekendDays, nextDay.DayOfWeek) != -1)
            {
                nextDay = nextDay.AddDays(1);
            }

            return nextDay;
        }

        /// <summary>
        /// Checks if a given time falls within business hours.
        /// </summary>
        /// <param name="dateTime">The DateTime to check.</param>
        /// <param name="businessStartTime">The start time of business hours.</param>
        /// <param name="businessEndTime">The end time of business hours.</param>
        /// <returns>True if the time falls within business hours; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 30, 0), businessStartTime=new TimeSpan(8, 0, 0), businessEndTime=new TimeSpan(17, 0, 0)
        /// Output: true
        /// </example>
        public static bool IsWithinBusinessHours(DateTime dateTime, TimeSpan businessStartTime, TimeSpan businessEndTime)
        {
            TimeSpan time = dateTime.TimeOfDay;
            return time >= businessStartTime && time <= businessEndTime;
        }

        /// <summary>
        /// Calculates the number of business hours between two dates.
        /// </summary>
        /// <param name="start">The start DateTime.</param>
        /// <param name="end">The end DateTime.</param>
        /// <param name="businessStartTime">The start time of business hours.</param>
        /// <param name="businessEndTime">The end time of business hours.</param>
        /// <returns>The total number of business hours between the two dates.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 24, 8, 0, 0), end=new DateTime(2023, 12, 24, 17, 0, 0), businessStartTime=new TimeSpan(8, 0, 0), businessEndTime=new TimeSpan(17, 0, 0)
        /// Output: 9 (assuming business hours from 8 AM to 5 PM)
        /// </example>
        public static double GetBusinessHours(DateTime start, DateTime end, TimeSpan businessStartTime, TimeSpan businessEndTime)
        {
            double totalBusinessHours = 0;
            DateTime current = start;

            while (current < end)
            {
                if (IsWithinBusinessHours(current, businessStartTime, businessEndTime))
                {
                    totalBusinessHours += 1;
                }
                current = current.AddHours(1);
            }
            return totalBusinessHours;
        }

        // <summary>
        /// Returns the total number of business days between two dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <param name="culture">The culture to determine weekend days.</param>
        /// <returns>The number of business days between the two dates.</returns>
        /// <exception cref="ArgumentException">Thrown if startDate is after endDate.</exception>
        /// <example>
        /// Input: startDate=new DateTime(2023, 12, 24), endDate=new DateTime(2023, 12, 31)
        /// Output: 5 (assuming default weekend days)
        /// </example>
        public static int BusinessDaysUntil(this DateTime startDate, DateTime endDate, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            if (startDate > endDate)
                throw new ArgumentException("The start date must be before the end date.");

            var totalDays = (endDate - startDate).Days;
            var businessDays = 0;
            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);

            for (var i = 0; i <= totalDays; i++)
            {
                var currentDay = startDate.AddDays(i);
                if (Array.IndexOf(weekendDays, currentDay.DayOfWeek) == -1)
                {
                    businessDays++;
                }
            }

            return businessDays;
        }
    }
}

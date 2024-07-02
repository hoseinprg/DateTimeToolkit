using DateTimeToolkit.Library.Common;
using System;
using System.Globalization;
using System.Linq;

namespace DateTimeToolkit.Library.Extensions
{
    public static class DateTimeCalculationExtension
    {

        private static readonly CultureInfo _culture = new CultureInfo("en-US");


        /// <summary>
        /// Adds the specified number of days to the date.
        /// </summary>
        /// <param name="dateTime">The date to add days to.</param>
        /// <param name="days">The number of days to add.</param>
        /// <returns>The date after adding the specified number of days.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), days=5
        /// Output: new DateTime(2023, 6, 6)
        /// </example>
        public static DateTime AddDays(DateTime dateTime, int days)
        {
            return dateTime.AddDays(days);
        }

        /// <summary>
        /// Adds the specified number of months to the date.
        /// </summary>
        /// <param name="dateTime">The date to add months to.</param>
        /// <param name="months">The number of months to add.</param>
        /// <returns>The date after adding the specified number of months.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), months=2
        /// Output: new DateTime(2023, 8, 1)
        /// </example>
        public static DateTime AddMonths(DateTime dateTime, int months)
        {
            return dateTime.AddMonths(months);
        }

        /// <summary>
        /// Adds the specified number of years to the date.
        /// </summary>
        /// <param name="dateTime">The date to add years to.</param>
        /// <param name="years">The number of years to add.</param>
        /// <returns>The date after adding the specified number of years.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), years=3
        /// Output: new DateTime(2026, 6, 1)
        /// </example>
        public static DateTime AddYears(DateTime dateTime, int years)
        {
            return dateTime.AddYears(years);
        }

        /// <summary>
        /// Subtracts the specified number of days from the date.
        /// </summary>
        /// <param name="dateTime">The date to subtract days from.</param>
        /// <param="days">The number of days to subtract.</param>
        /// <returns>The date after subtracting the specified number of days.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 10), days=5
        /// Output: new DateTime(2023, 6, 5)
        /// </example>
        public static DateTime SubtractDays(DateTime dateTime, int days)
        {
            return dateTime.AddDays(-days);
        }

        /// <summary>
        /// Calculates the difference between two dates.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="end">The end date.</param>
        /// <returns>The difference as a TimeSpan.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 6, 1), end=new DateTime(2023, 6, 10)
        /// Output: TimeSpan representing 9 days
        /// </example>
        public static TimeSpan CalculateDifference(DateTime start, DateTime end)
        {
            return end - start;
        }

        /// <summary>
        /// Gets the week number of the year for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to calculate the week number for.</param>
        /// <param name="culture">Optional. The culture info to determine the week rules. If not provided, uses the current culture.</param>
        /// <returns>The week number of the year.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24)
        /// Output: 52
        /// </example>
        public static int GetWeekOfYear(DateTime dateTime, CultureInfo culture = null)
        {
            if (culture == null)
            {
                culture = CultureInfo.CurrentCulture; // Use the current culture if none is provided
            }

            int weekNum = culture.Calendar.GetWeekOfYear(dateTime, CalendarWeekRule.FirstFourDayWeek, culture.DateTimeFormat.FirstDayOfWeek);
            return weekNum;
        }

        /// <summary>
        /// Gets the fiscal year for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to determine the fiscal year for.</param>
        /// <param name="fiscalYearStartMonth">The starting month of the fiscal year (default is January).</param>
        /// <returns>The fiscal year.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15), fiscalYearStartMonth=4
        /// Output: 2023
        /// </example>
        public static int GetFiscalYear(DateTime dateTime, int fiscalYearStartMonth = 1)
        {
            if (dateTime.Month >= fiscalYearStartMonth)
            {
                return dateTime.Year;
            }
            return dateTime.Year - 1;
        }

        /// <summary>
        /// Checks if the specified date is in daylight saving time.
        /// </summary>
        /// <param name="dateTime">The date to check.</param>
        /// <param name="timeZone">The time zone information.</param>
        /// <returns>True if the date is in daylight saving time, otherwise false.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15), timeZone=TimeZoneInfo.Local
        /// Output: false
        /// </example>
        public static bool IsDaylightSavingTime(DateTime dateTime, TimeZoneInfo timeZone)
        {
            return timeZone.IsDaylightSavingTime(dateTime);
        }

        /// <summary>
        /// Gets the total number of weekdays between two dates.
        /// </summary>
        /// <param name="start">The starting date (inclusive).</param>
        /// <param name="end">The ending date (inclusive).</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The number of weekdays.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 24), end=new DateTime(2023, 12, 31)
        /// Output: 5
        /// </example>
        public static int GetWeekdays(DateTime start, DateTime end, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            int totalDays = (int)(end - start).TotalDays;
            int weekdays = 0;
            for (int i = 0; i <= totalDays; i++)
            {
                DateTime current = start.AddDays(i);
                if (!weekendDays.Contains(current.DayOfWeek))
                {
                    weekdays++;
                }
            }
            return weekdays;
        }

        /// <summary>
        /// Gets the total number of weekend days between two dates.
        /// </summary>
        /// <param name="start">The starting date (inclusive).</param>
        /// <param name="end">The ending date (inclusive).</param>
        /// <param name="culture">Culture info to determine weekend days (optional). If not provided, uses the default culture.</param>
        /// <returns>The number of weekend days.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 24), end=new DateTime(2023, 12, 31)
        /// Output: 2
        /// </example>
        public static int GetWeekendDays(DateTime start, DateTime end, CultureInfo culture = null)
        {
            if (culture == null)
                culture = _culture; // Use the static default culture

            var weekendDays = DateTimeHelper.GetWeekendDaysForCulture(culture);
            int totalDays = (int)(end - start).TotalDays;
            int weekends = 0;
            for (int i = 0; i <= totalDays; i++)
            {
                DateTime current = start.AddDays(i);
                if (weekendDays.Contains(current.DayOfWeek))
                {
                    weekends++;
                }
            }
            return weekends;
        }

        /// <summary>
        /// Gets the start of the quarter for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the start of the quarter for.</param>
        /// <returns>The start of the quarter for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 4, 1)
        /// </example>
        public static DateTime GetStartOfQuarter(DateTime dateTime)
        {
            int currentQuarter = (dateTime.Month - 1) / 3 + 1;
            return new DateTime(dateTime.Year, (currentQuarter - 1) * 3 + 1, 1);
        }

        /// <summary>
        /// Gets the end of the quarter for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the end of the quarter for.</param>
        /// <returns>The end of the quarter for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 6, 30)
        /// </example>
        public static DateTime GetEndOfQuarter(DateTime dateTime)
        {
            return GetStartOfQuarter(dateTime).AddMonths(3).AddDays(-1);
        }

        /// <summary>
        /// Adds the specified number of weeks to the date.
        /// </summary>
        /// <param name="dateTime">The date to add weeks to.</param>
        /// <param name="weeks">The number of weeks to add.</param>
        /// <returns>The date after adding the specified number of weeks.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), weeks=2
        /// Output: new DateTime(2023, 6, 15)
        /// </example>
        public static DateTime AddWeeks(DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(weeks * 7);
        }

        /// <summary>
        /// Subtracts the specified number of weeks from the date.
        /// </summary>
        /// <param name="dateTime">The date to subtract weeks from.</param>
        /// <param name="weeks">The number of weeks to subtract.</param>
        /// <returns>The date after subtracting the specified number of weeks.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15), weeks=2
        /// Output: new DateTime(2023, 6, 1)
        /// </example>
        public static DateTime SubtractWeeks(DateTime dateTime, int weeks)
        {
            return dateTime.AddDays(-weeks * 7);
        }

        /// <summary>
        /// Rounds a time to the nearest specified interval (e.g., minute, hour), with an option to round up or down.
        /// </summary>
        /// <param name="dateTime">The DateTime to round.</param>
        /// <param name="interval">The time interval to round to.</param>
        /// <param name="roundUp">Specifies whether to round up (true) or down (false).</param>
        /// <returns>The DateTime rounded to the nearest interval.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 12, 24, 10, 35, 0), interval=new TimeSpan(0, 30, 0), roundUp=false
        /// Output: new DateTime(2023, 12, 24, 10, 30, 0)
        /// </example>
        public static DateTime RoundToNearestInterval(DateTime dateTime, TimeSpan interval, bool roundUp)
        {
            long intervalTicks = interval.Ticks;
            if (roundUp)
            {
                long ticks = (dateTime.Ticks + intervalTicks - 1) / intervalTicks;
                return new DateTime(ticks * intervalTicks);
            }
            else
            {
                long ticks = dateTime.Ticks / intervalTicks;
                return new DateTime(ticks * intervalTicks);
            }
        }


        /// <summary>
        /// Gets the start time of the current quarter.
        /// </summary>
        public static DateTime GetStartOfCurrentQuarter()
        {
            DateTime now = DateTime.Now;
            int currentQuarter = (now.Month - 1) / 3 + 1;
            return new DateTime(now.Year, (currentQuarter - 1) * 3 + 1, 1);
        }

        /// <summary>
        /// Gets the end time of the current quarter.
        /// </summary>
        /// <returns>The end time of the current quarter.</returns>
        /// <example>
        /// Output: End date of the current quarter
        /// </example>
        public static DateTime GetEndOfCurrentQuarter()
        {
            DateTime startOfQuarter = GetStartOfCurrentQuarter();
            return startOfQuarter.AddMonths(3).AddDays(-1).Date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Gets a TimeSpan from hours.
        /// </summary>
        /// <param name="hours">The number of hours.</param>
        /// <returns>A TimeSpan representing the specified number of hours.</returns>
        /// <example>
        /// Input: hours=1.5
        /// Output: new TimeSpan(1, 30, 0)
        /// </example>
        public static TimeSpan GetTimeSpanFromHours(double hours)
        {
            return TimeSpan.FromHours(hours);
        }

        /// <summary>
        /// Gets a TimeSpan from minutes.
        /// </summary>
        /// <param name="minutes">The number of minutes.</param>
        /// <returns>A TimeSpan representing the specified number of minutes.</returns>
        /// <example>
        /// Input: minutes=90
        /// Output: new TimeSpan(1, 30, 0)
        /// </example>
        public static TimeSpan GetTimeSpanFromMinutes(double minutes)
        {
            return TimeSpan.FromMinutes(minutes);
        }

        /// <summary>
        /// Gets a TimeSpan from seconds.
        /// </summary>
        /// <param name="seconds">The number of seconds.</param>
        /// <returns>A TimeSpan representing the specified number of seconds.</returns>
        /// <example>
        /// Input: seconds=3600
        /// Output: new TimeSpan(1, 0, 0)
        /// </example>
        public static TimeSpan GetTimeSpanFromSeconds(double seconds)
        {
            return TimeSpan.FromSeconds(seconds);
        }
    }
}

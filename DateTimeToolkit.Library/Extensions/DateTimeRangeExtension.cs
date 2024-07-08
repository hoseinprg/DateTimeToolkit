using System;
using System.Collections.Generic;

namespace DateTimeToolkit.Library.Extensions
{
    public static class DateTimeRangeExtension
    {
        /// <summary>
        /// Gets the start of the day (00:00:00) for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the start of the day for.</param>
        /// <returns>The start of the day for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 15, 30, 0)
        /// Output: new DateTime(2023, 6, 1, 0, 0, 0)
        /// </example>
        public static DateTime GetStartOfDay(DateTime dateTime)
        {
            return dateTime.Date;
        }

        /// <summary>
        /// Gets the end of the day (23:59:59) for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the end of the day for.</param>
        /// <returns>The end of the day for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1, 15, 30, 0)
        /// Output: new DateTime(2023, 6, 1, 23, 59, 59)
        /// </example>
        public static DateTime GetEndOfDay(DateTime dateTime)
        {
            return dateTime.Date.AddDays(1).AddTicks(-1);
        }

        /// <summary>
        /// Gets the start of the month for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the start of the month for.</param>
        /// <returns>The start of the month for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 6, 1)
        /// </example>
        public static DateTime GetStartOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// Gets the end of the month for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the end of the month for.</param>
        /// <returns>The end of the month for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 6, 30)
        /// </example>
        public static DateTime GetEndOfMonth(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// Gets the start of the year for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the start of the year for.</param>
        /// <returns>The start of the year for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 1, 1)
        /// </example>
        public static DateTime GetStartOfYear(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1);
        }

        /// <summary>
        /// Gets the end of the year for the specified date.
        /// </summary>
        /// <param name="dateTime">The date to get the end of the year for.</param>
        /// <returns>The end of the year for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15)
        /// Output: new DateTime(2023, 12, 31)
        /// </example>
        public static DateTime GetEndOfYear(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31);
        }

        /// <summary>
        /// Gets the start of the week for the specified date with the specified start day.
        /// </summary>
        /// <param name="dateTime">The date to get the start of the week for.</param>
        /// <param name="startOfWeek">The day considered as the start of the week.</param>
        /// <returns>The start of the week for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15), startOfWeek=DayOfWeek.Monday
        /// Output: new DateTime(2023, 6, 12)
        /// </example>
        public static DateTime GetStartOfWeek(DateTime dateTime, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dateTime.DayOfWeek - startOfWeek)) % 7;
            return dateTime.AddDays(-1 * diff).Date;
        }

        /// <summary>
        /// Gets the end of the week for the specified date with the specified start day.
        /// </summary>
        /// <param name="dateTime">The date to get the end of the week for.</param>
        /// <param name="startOfWeek">The day considered as the start of the week.</param>
        /// <returns>The end of the week for the specified date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 15), startOfWeek=DayOfWeek.Monday
        /// Output: new DateTime(2023, 6, 18)
        /// </example>
        public static DateTime GetEndOfWeek(DateTime dateTime, DayOfWeek startOfWeek)
        {
            return GetStartOfWeek(dateTime, startOfWeek).AddDays(6);
        }

        /// <summary>
        /// Gets a list of occurrences between the specified start and end dates according to the specified interval.
        /// </summary>
        /// <param name="start">The starting date.</param>
        /// <param name="end">The ending date.</param>
        /// <param name="interval">The interval between occurrences.</param>
        /// <returns>A list of occurrences between the specified dates.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 6, 1), end=new DateTime(2023, 6, 5), interval=new TimeSpan(1, 0, 0, 0)
        /// Output: List of DateTime { new DateTime(2023, 6, 1), new DateTime(2023, 6, 2), new DateTime(2023, 6, 3), new DateTime(2023, 6, 4), new DateTime(2023, 6, 5) }
        /// </example>
        public static List<DateTime> GetOccurrences(DateTime start, DateTime end, TimeSpan interval)
        {
            List<DateTime> occurrences = new List<DateTime>();
            DateTime current = start;
            while (current <= end)
            {
                occurrences.Add(current);
                current = current.Add(interval);
            }
            return occurrences;
        }

        /// <summary>
        /// Checks if a date falls within a specific range.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="startDate">The start of the range.</param>
        /// <param name="endDate">The end of the range.</param>
        /// <returns>True if the date is within the range; otherwise, false.</returns>
        /// <example>
        /// Input: date=new DateTime(2023, 12, 24), startDate=new DateTime(2023, 12, 20), endDate=new DateTime(2023, 12, 31)
        /// Output: true
        /// </example>
        public static bool IsDateInRange(DateTime date, DateTime startDate, DateTime endDate)
        {
            return date >= startDate && date <= endDate;
        }

        /// <summary>
        /// Generates a list of dates within a specific range.
        /// </summary>
        /// <param name="startDate">The start date of the range.</param>
        /// <param name="endDate">The end date of the range.</param>
        /// <returns>A list of DateTime objects representing the dates within the range.</returns>
        /// <example>
        /// Input: startDate=new DateTime(2023, 12, 20), endDate=new DateTime(2023, 12, 24)
        /// Output: List containing DateTime objects for each date in the range
        /// </example>
        public static List<DateTime> GetDatesInRange(DateTime startDate, DateTime endDate)
        {
            List<DateTime> dates = new List<DateTime>();
            for (DateTime date = startDate; date <= endDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }
            return dates;
        }

        /// <summary>
        /// Gets the overlap between two date ranges.
        /// </summary>
        /// <param name="start1">The start of the first date range.</param>
        /// <param name="end1">The end of the first date range.</param>
        /// <param name="start2">The start of the second date range.</param>
        /// <param name="end2">The end of the second date range.</param>
        /// <returns>A tuple containing the start and end of the overlapping date range, or null if there is no overlap.</returns>
        /// <example>
        /// Input: start1=new DateTime(2023, 12, 25), end1=new DateTime(2023, 12, 30), start2=new DateTime(2023, 12, 28), end2=new DateTime(2024, 1, 2)
        /// Output: (new DateTime(2023, 12, 28), new DateTime(2023, 12, 30))
        /// </example>
        public static (DateTime? Start, DateTime? End) GetOverlap(DateTime start1, DateTime end1, DateTime start2, DateTime end2)
        {
            if (end1 < start2 || end2 < start1)
                return (null, null);

            DateTime overlapStart = start1 > start2 ? start1 : start2;
            DateTime overlapEnd = end1 < end2 ? end1 : end2;
            return (overlapStart, overlapEnd);
        }

    }
}

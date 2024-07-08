using System;

namespace DateTimeToolkit.Library.Extensions
{
    public static class OccurrenceExtension
    {
        /// <summary>
        /// Gets the next occurrence of the specified date according to the specified interval.
        /// </summary>
        /// <param name="dateTime">The starting date.</param>
        /// <param name="interval">The interval to add to the date.</param>
        /// <returns>The next occurrence of the date.</returns>
        /// <example>
        /// Input: dateTime=new DateTime(2023, 6, 1), interval=new TimeSpan(1, 0, 0, 0)
        /// Output: new DateTime(2023, 6, 2)
        /// </example>
        public static DateTime GetNextOccurrence(DateTime dateTime, TimeSpan interval)
        {
            return dateTime.Add(interval);
        }

        /// <summary>
        /// Gets the previous occurrence of a specified day of the week.
        /// </summary>
        /// <param name="start">The start date.</param>
        /// <param name="dayOfWeek">The day of the week.</param>
        /// <returns>The previous occurrence of the specified day of the week.</returns>
        /// <example>
        /// Input: start=new DateTime(2023, 12, 25), dayOfWeek=DayOfWeek.Friday
        /// Output: new DateTime(2023, 12, 22)
        /// </example>
        public static DateTime GetPreviousOccurrence(this DateTime start, DayOfWeek dayOfWeek)
        {
            int daysToSubtract = ((int)start.DayOfWeek - (int)dayOfWeek + 7) % 7;
            return start.AddDays(daysToSubtract == 0 ? -7 : -daysToSubtract);
        }

    }
}

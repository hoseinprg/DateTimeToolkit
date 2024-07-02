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
    }
}

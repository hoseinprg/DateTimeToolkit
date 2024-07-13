using System;

namespace DateTimeToolkit.Library.Extensions
{
    public static class ComparisonExtension
    {
        /// <summary>
        /// Checks if the first date is before the second date.
        /// </summary>
        /// <param name="dateTime1">The first date.</param>
        /// <param name="dateTime2">The second date.</param>
        /// <returns>True if the first date is before the second date; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime1=new DateTime(2023, 6, 1), dateTime2=new DateTime(2023, 6, 10)
        /// Output: true
        /// </example>
        public static bool IsBefore(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1 < dateTime2;
        }

        /// <summary>
        /// Checks if the first date is after the second date.
        /// </summary>
        /// <param name="dateTime1">The first date.</param>
        /// <param name="dateTime2">The second date.</param>
        /// <returns>True if the first date is after the second date; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime1=new DateTime(2023, 6, 10), dateTime2=new DateTime(2023, 6, 1)
        /// Output: true
        /// </example>
        public static bool IsAfter(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1 > dateTime2;
        }

        /// <summary>
        /// Checks if the two dates are on the same day.
        /// </summary>
        /// <param name="dateTime1">The first date.</param>
        /// <param name="dateTime2">The second date.</param>
        /// <returns>True if the two dates are on the same day; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime1=new DateTime(2023, 6, 1), dateTime2=new DateTime(2023, 6, 1, 23, 59, 59)
        /// Output: true
        /// </example>
        public static bool IsSameDay(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1.Date == dateTime2.Date;
        }

        /// <summary>
        /// Checks if the first date is on or before the second date.
        /// </summary>
        /// <param name="dateTime1">The first date.</param>
        /// <param name="dateTime2">The second date.</param>
        /// <returns>True if the first date is on or before the second date; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime1=new DateTime(2023, 6, 1), dateTime2=new DateTime(2023, 6, 10)
        /// Output: true
        /// </example>
        public static bool IsOnOrBefore(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1 <= dateTime2;
        }

        /// <summary>
        /// Checks if the first date is on or after the second date.
        /// </summary>
        /// <param name="dateTime1">The first date.</param>
        /// <param name="dateTime2">The second date.</param>
        /// <returns>True if the first date is on or after the second date; otherwise, false.</returns>
        /// <example>
        /// Input: dateTime1=new DateTime(2023, 6, 10), dateTime2=new DateTime(2023, 6, 1)
        /// Output: true
        /// </example>
        public static bool IsOnOrAfter(DateTime dateTime1, DateTime dateTime2)
        {
            return dateTime1 >= dateTime2;
        }

    }
}

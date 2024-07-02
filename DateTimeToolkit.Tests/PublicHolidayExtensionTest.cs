using DateTimeToolkit.Library.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class PublicHolidayExtensionTest
    {
        [Fact]
        public void GetNextPublicHoliday_ReturnsNextHoliday()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            DateTime? result = PublicHolidayExtension.GetNextPublicHoliday(dateTime, publicHolidays);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 25), result);
        }

        [Fact]
        public void GetPreviousPublicHoliday_ReturnsPreviousHoliday()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 23) };

            // Act
            DateTime? result = PublicHolidayExtension.GetPreviousPublicHoliday(dateTime, publicHolidays);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 23), result);
        }

        [Theory]
        [InlineData("2023-12-25", true)]
        [InlineData("2023-12-28", false)]
        public void IsWeekendOrHoliday_ChecksIfWeekendOrHoliday(string dateStr, bool expected)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateStr);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            bool result = dateTime.IsWeekendOrHoliday(publicHolidays);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetPublicHolidaysInRange_ReturnsHolidaysInRange()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 24);
            DateTime end = new DateTime(2024, 1, 1);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            List<DateTime> result = PublicHolidayExtension.GetPublicHolidaysInRange(start, end, publicHolidays);

            // Assert
            Assert.Single(result); // Expecting only one holiday (Christmas on Dec 25, 2023)
            Assert.Equal(new DateTime(2023, 12, 25), result[0]);
        }

        [Fact]
        public void GetNextWorkingDayConsideringHolidays_ReturnsNextWorkingDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            DateTime result = PublicHolidayExtension.GetNextWorkingDayConsideringHolidays(dateTime, publicHolidays);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 26), result);
        }

        [Fact]
        public void GetWorkingDaysConsideringHolidays_ReturnsWorkingDays()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 24);
            DateTime end = new DateTime(2023, 12, 31);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            int result = PublicHolidayExtension.GetWorkingDaysConsideringHolidays(start, end, publicHolidays);

            // Assert
            Assert.Equal(4, result);
        }

        [Fact]
        public void GetNearestPublicHoliday_ReturnsNearestHoliday()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            DateTime? result = PublicHolidayExtension.GetNearestPublicHoliday(dateTime, publicHolidays);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 25), result);
        }
    }
}
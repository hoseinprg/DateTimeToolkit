using DateTimeToolkit.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class ValidationExtensionTest
    {
        private readonly CultureInfo _enUsCulture = new CultureInfo("en-US");

        [Theory]
        [InlineData("2023-06-01", "yyyy-MM-dd", true)]
        [InlineData("2023/06/01", "yyyy-MM-dd", false)] // Invalid format
        [InlineData("2023-02-29", "yyyy-MM-dd", false)] // Not a valid date
        public void IsValidDate_ValidatesDateString(string dateString, string format, bool expected)
        {
            // Act
            bool result = ValidationExtension.IsValidDate(dateString, format);

            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(2024, true)]
        [InlineData(2023, false)]
        [InlineData(2100, false)] // Not a leap year
        [InlineData(2000, true)] // Leap year
        public void IsLeapYear_ChecksLeapYear(int year, bool expected)
        {
            // Act
            bool result = ValidationExtension.IsLeapYear(year);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsHoliday_ChecksIfDateIsHoliday()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 25);
            List<DateTime> holidays = new List<DateTime> { new DateTime(2023, 12, 25), new DateTime(2023, 1, 1) };

            // Act
            bool result = ValidationExtension.IsHoliday(dateTime, holidays);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsPublicHoliday_ChecksIfDateIsPublicHoliday()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 25);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            bool result = ValidationExtension.IsPublicHoliday(dateTime, publicHolidays);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("2023-12-25", false)] // Monday (default en-US culture)
        [InlineData("2023-12-24", true)] // Sunday (default en-US culture)
        public void IsWeekend_ChecksIfDateIsWeekend(string dateString, bool expected)
        {
            // Arrange
            DateTime dateTime = DateTime.Parse(dateString);

            // Act
            bool result = dateTime.IsWeekend();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsBusinessDay_ValidInput_ReturnsTrueOrFalse()
        {
            // Arrange
            DateTime date = new DateTime(2023, 12, 25);
            List<DateTime> publicHolidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act & Assert
            Assert.False(date.IsBusinessDay(publicHolidays, _enUsCulture));
        }
    }
}
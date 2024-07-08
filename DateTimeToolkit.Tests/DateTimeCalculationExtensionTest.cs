using DateTimeToolkit.Library.Extensions;
using System;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class DateTimeCalculationExtensionTests
    {
        [Fact]
        public void AddDays_AddsSpecifiedNumberOfDays()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            int days = 5;

            // Act
            DateTime result = DateTimeCalculationExtension.AddDays(dateTime, days);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 6), result);
        }

        [Fact]
        public void AddMonths_AddsSpecifiedNumberOfMonths()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            int months = 2;

            // Act
            DateTime result = DateTimeCalculationExtension.AddMonths(dateTime, months);

            // Assert
            Assert.Equal(new DateTime(2023, 8, 1), result);
        }

        [Fact]
        public void AddYears_AddsSpecifiedNumberOfYears()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            int years = 3;

            // Act
            DateTime result = DateTimeCalculationExtension.AddYears(dateTime, years);

            // Assert
            Assert.Equal(new DateTime(2026, 6, 1), result);
        }

        [Fact]
        public void SubtractDays_SubtractsSpecifiedNumberOfDays()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 10);
            int days = 5;

            // Act
            DateTime result = DateTimeCalculationExtension.SubtractDays(dateTime, days);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 5), result);
        }

        [Fact]
        public void CalculateDifference_ReturnsCorrectTimeSpan()
        {
            // Arrange
            DateTime start = new DateTime(2023, 6, 1);
            DateTime end = new DateTime(2023, 6, 10);

            // Act
            TimeSpan result = DateTimeCalculationExtension.CalculateDifference(start, end);

            // Assert
            Assert.Equal(TimeSpan.FromDays(9), result);
        }

        [Fact]
        public void GetWeekOfYear_ReturnsCorrectWeekNumber()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            int result = DateTimeCalculationExtension.GetWeekOfYear(dateTime);

            // Assert
            Assert.Equal(52, result);
        }

        [Fact]
        public void GetFiscalYear_ReturnsCorrectFiscalYear()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            int result = DateTimeCalculationExtension.GetFiscalYear(dateTime, 4);

            // Assert
            Assert.Equal(2023, result);
        }

        [Fact]
        public void IsDaylightSavingTime_ReturnsCorrectResult()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);
            TimeZoneInfo timeZone = TimeZoneInfo.Local;

            // Act
            bool result = DateTimeCalculationExtension.IsDaylightSavingTime(dateTime, timeZone);

            // Assert
            Assert.Equal(timeZone.IsDaylightSavingTime(dateTime), result);
        }

        [Fact]
        public void GetWeekdays_ReturnsCorrectWeekdayCount()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 24);
            DateTime end = new DateTime(2023, 12, 31);

            // Act
            int result = DateTimeCalculationExtension.GetWeekdays(start, end);

            // Assert
            Assert.Equal(5, result);
        }

        [Fact]
        public void GetWeekendDays_ReturnsCorrectWeekendDayCount()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 24);
            DateTime end = new DateTime(2023, 12, 31);

            // Act
            int result = DateTimeCalculationExtension.GetWeekendDays(start, end);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void GetStartOfQuarter_ReturnsCorrectStartOfQuarter()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeCalculationExtension.GetStartOfQuarter(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 4, 1), result);
        }

        [Fact]
        public void GetEndOfQuarter_ReturnsCorrectEndOfQuarter()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeCalculationExtension.GetEndOfQuarter(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 30), result);
        }

        [Fact]
        public void AddWeeks_AddsSpecifiedNumberOfWeeks()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            int weeks = 2;

            // Act
            DateTime result = DateTimeCalculationExtension.AddWeeks(dateTime, weeks);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 15), result);
        }

        [Fact]
        public void SubtractWeeks_SubtractsSpecifiedNumberOfWeeks()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);
            int weeks = 2;

            // Act
            DateTime result = DateTimeCalculationExtension.SubtractWeeks(dateTime, weeks);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 1), result);
        }

        [Fact]
        public void RoundToNearestInterval_RoundsToNearestInterval_RoundDown()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 35, 0);
            TimeSpan interval = new TimeSpan(0, 30, 0);
            bool roundUp = false;

            // Act
            DateTime result = DateTimeCalculationExtension.RoundToNearestInterval(dateTime, interval, roundUp);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 24, 10, 30, 0), result);
        }

        [Fact]
        public void RoundToNearestInterval_RoundsToNearestInterval_RoundUp()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 35, 0);
            TimeSpan interval = new TimeSpan(0, 30, 0);
            bool roundUp = true;

            // Act
            DateTime result = DateTimeCalculationExtension.RoundToNearestInterval(dateTime, interval, roundUp);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 24, 11, 0, 0), result);
        }

        [Fact]
        public void GetStartOfCurrentQuarter_ReturnsCorrectStartOfQuarter()
        {
            // Act
            DateTime result = DateTimeCalculationExtension.GetStartOfCurrentQuarter();
            DateTime now = DateTime.Now;
            int currentQuarter = (now.Month - 1) / 3 + 1;
            DateTime expected = new DateTime(now.Year, (currentQuarter - 1) * 3 + 1, 1);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetEndOfCurrentQuarter_ReturnsCorrectEndOfQuarter()
        {
            // Act
            DateTime result = DateTimeCalculationExtension.GetEndOfCurrentQuarter();
            DateTime startOfQuarter = DateTimeCalculationExtension.GetStartOfCurrentQuarter();
            DateTime expected = startOfQuarter.AddMonths(3).AddDays(-1).Date.AddDays(1).AddTicks(-1);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetTimeSpanFromHours_ReturnsCorrectTimeSpan()
        {
            // Arrange
            double hours = 1.5;

            // Act
            TimeSpan result = DateTimeCalculationExtension.GetTimeSpanFromHours(hours);

            // Assert
            Assert.Equal(TimeSpan.FromHours(hours), result);
        }

        [Fact]
        public void GetTimeSpanFromMinutes_ReturnsCorrectTimeSpan()
        {
            // Arrange
            double minutes = 90;

            // Act
            TimeSpan result = DateTimeCalculationExtension.GetTimeSpanFromMinutes(minutes);

            // Assert
            Assert.Equal(TimeSpan.FromMinutes(minutes), result);
        }

        [Fact]
        public void GetTimeSpanFromSeconds_ReturnsCorrectTimeSpan()
        {
            // Arrange
            double seconds = 3600;

            // Act
            TimeSpan result = DateTimeCalculationExtension.GetTimeSpanFromSeconds(seconds);

            // Assert
            Assert.Equal(TimeSpan.FromSeconds(seconds), result);
        }

        [Fact]
        public void GetDaysBetween_ValidInput_ReturnsNumberOfDays()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 12, 25);
            DateTime endDate = new DateTime(2023, 12, 30);

            // Act
            int result = startDate.GetDaysBetween(endDate);

            // Assert
            Assert.Equal(5, result);
        }
    }

}
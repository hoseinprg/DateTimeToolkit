using DateTimeToolkit.Library.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class BusinessDayExtensionTest
    {
        private CultureInfo _enUsCulture = new CultureInfo("en-US");

        [Fact]
        public void AddBusinessDays_ValidInput_ReturnsCorrectDate()
        {
            // Arrange
            DateTime inputDate = new DateTime(2023, 12, 24);

            // Act
            DateTime result = inputDate.AddBusinessDays(5, _enUsCulture);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 29), result);
        }

        [Fact]
        public void GetNextBusinessDay_ValidInput_ReturnsCorrectDate()
        {
            // Arrange
            DateTime inputDate = new DateTime(2023, 12, 24);

            // Act
            DateTime result = inputDate.GetNextBusinessDay(_enUsCulture);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 25), result);
        }

        [Fact]
        public void AddBusinessDaysConsideringHolidays_ValidInput_ReturnsCorrectDate()
        {
            // Arrange
            DateTime inputDate = new DateTime(2023, 12, 24);
            List<DateTime> holidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            DateTime result = inputDate.AddBusinessDaysConsideringHolidays(5, holidays, _enUsCulture);

            // Assert
            Assert.Equal(new DateTime(2024, 1, 1), result);
        }

        [Fact]
        public void GetNextWorkingDay_ValidInput_ReturnsCorrectDate()
        {
            // Arrange
            DateTime inputDate = new DateTime(2023, 12, 24);
            List<DateTime> holidays = new List<DateTime> { new DateTime(2023, 12, 25) };

            // Act
            DateTime result = inputDate.GetNextWorkingDay(holidays, _enUsCulture);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 26), result);
        }

        [Fact]
        public void IsWithinBusinessHours_ValidInput_ReturnsTrue()
        {
            // Arrange
            DateTime inputDateTime = new DateTime(2023, 12, 24, 10, 30, 0);
            TimeSpan businessStartTime = new TimeSpan(8, 0, 0);
            TimeSpan businessEndTime = new TimeSpan(17, 0, 0);

            // Act
            bool result = BusinessDayExtension.IsWithinBusinessHours(inputDateTime, businessStartTime, businessEndTime);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void GetBusinessHours_ValidInput_ReturnsCorrectHours()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 24, 8, 0, 0);
            DateTime end = new DateTime(2023, 12, 24, 17, 0, 0);
            TimeSpan businessStartTime = new TimeSpan(8, 0, 0);
            TimeSpan businessEndTime = new TimeSpan(17, 0, 0);

            // Act
            double result = BusinessDayExtension.GetBusinessHours(start, end, businessStartTime, businessEndTime);

            // Assert
            Assert.Equal(9, result);
        }

        [Fact]
        public void BusinessDaysUntil_ValidInput_ReturnsCorrectCount()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 12, 24);
            DateTime endDate = new DateTime(2023, 12, 31);

            // Act
            int result = startDate.BusinessDaysUntil(endDate, _enUsCulture);

            // Assert
            Assert.Equal(5, result);
        }
    }
}

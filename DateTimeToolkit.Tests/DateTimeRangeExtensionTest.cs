using DateTimeToolkit.Library.Extensions;
using System;
using System.Collections.Generic;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class DateTimeRangeExtensionTests
    {
        [Fact]
        public void GetStartOfDay_ReturnsStartOfDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 15, 30, 0);

            // Act
            DateTime result = DateTimeRangeExtension.GetStartOfDay(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 1, 0, 0, 0), result);
        }

        [Fact]
        public void GetEndOfDay_ReturnsEndOfDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 15, 30, 0);
            DateTime expectedEndOfDay = new DateTime(2023, 6, 1, 23, 59, 59, 999);

            // Act
            DateTime result = DateTimeRangeExtension.GetEndOfDay(dateTime);

            // Assert
            Assert.True((result - expectedEndOfDay).Duration() < TimeSpan.FromMilliseconds(1),
                $"Expected: {expectedEndOfDay}, Actual: {result}");
        }

        [Fact]
        public void GetStartOfMonth_ReturnsStartOfMonth()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeRangeExtension.GetStartOfMonth(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 1), result);
        }

        [Fact]
        public void GetEndOfMonth_ReturnsEndOfMonth()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeRangeExtension.GetEndOfMonth(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 30), result);
        }

        [Fact]
        public void GetStartOfYear_ReturnsStartOfYear()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeRangeExtension.GetStartOfYear(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 1, 1), result);
        }

        [Fact]
        public void GetEndOfYear_ReturnsEndOfYear()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);

            // Act
            DateTime result = DateTimeRangeExtension.GetEndOfYear(dateTime);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 31), result);
        }

        [Fact]
        public void GetStartOfWeek_ReturnsStartOfWeek()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);
            DayOfWeek startOfWeek = DayOfWeek.Monday;

            // Act
            DateTime result = DateTimeRangeExtension.GetStartOfWeek(dateTime, startOfWeek);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 12), result);
        }

        [Fact]
        public void GetEndOfWeek_ReturnsEndOfWeek()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 15);
            DayOfWeek startOfWeek = DayOfWeek.Monday;

            // Act
            DateTime result = DateTimeRangeExtension.GetEndOfWeek(dateTime, startOfWeek);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 18), result);
        }

        [Fact]
        public void GetOccurrences_ReturnsCorrectOccurrences()
        {
            // Arrange
            DateTime start = new DateTime(2023, 6, 1);
            DateTime end = new DateTime(2023, 6, 5);
            TimeSpan interval = new TimeSpan(1, 0, 0, 0);

            // Act
            List<DateTime> result = DateTimeRangeExtension.GetOccurrences(start, end, interval);

            // Assert
            List<DateTime> expected = new List<DateTime>
        {
            new DateTime(2023, 6, 1),
            new DateTime(2023, 6, 2),
            new DateTime(2023, 6, 3),
            new DateTime(2023, 6, 4),
            new DateTime(2023, 6, 5)
        };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void IsDateInRange_ReturnsTrueIfDateInRange()
        {
            // Arrange
            DateTime date = new DateTime(2023, 12, 24);
            DateTime startDate = new DateTime(2023, 12, 20);
            DateTime endDate = new DateTime(2023, 12, 31);

            // Act
            bool result = DateTimeRangeExtension.IsDateInRange(date, startDate, endDate);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsDateInRange_ReturnsFalseIfDateNotInRange()
        {
            // Arrange
            DateTime date = new DateTime(2023, 12, 19);
            DateTime startDate = new DateTime(2023, 12, 20);
            DateTime endDate = new DateTime(2023, 12, 31);

            // Act
            bool result = DateTimeRangeExtension.IsDateInRange(date, startDate, endDate);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void GetDatesInRange_ReturnsCorrectDatesInRange()
        {
            // Arrange
            DateTime startDate = new DateTime(2023, 12, 20);
            DateTime endDate = new DateTime(2023, 12, 24);

            // Act
            List<DateTime> result = DateTimeRangeExtension.GetDatesInRange(startDate, endDate);

            // Assert
            List<DateTime> expected = new List<DateTime>
            {
                new DateTime(2023, 12, 20),
                new DateTime(2023, 12, 21),
                new DateTime(2023, 12, 22),
                new DateTime(2023, 12, 23),
                new DateTime(2023, 12, 24)
            };
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetOverlap_OverlappingRanges_ReturnsOverlap()
        {
            // Arrange
            DateTime start1 = new DateTime(2023, 12, 25);
            DateTime end1 = new DateTime(2023, 12, 30);
            DateTime start2 = new DateTime(2023, 12, 28);
            DateTime end2 = new DateTime(2024, 1, 2);

            // Act
            var result = DateTimeRangeExtension.GetOverlap(start1, end1, start2, end2);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 28), result.Start);
            Assert.Equal(new DateTime(2023, 12, 30), result.End);
        }
    }

}
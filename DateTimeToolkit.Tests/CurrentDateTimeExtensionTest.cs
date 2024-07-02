using DateTimeToolkit.Library.Extensions;
using System;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class CurrentDateTimeExtensionTests
    {
        [Fact]
        public void GetLocalDateTime_ReturnsCurrentLocalDateTime()
        {
            // Arrange
            DateTime before = DateTime.Now;

            // Act
            DateTime result = CurrentDateTimeExtension.GetLocalDateTime();

            // Assert
            DateTime after = DateTime.Now;
            Assert.True(result >= before && result <= after);
        }

        [Fact]
        public void GetUtcDateTime_ReturnsCurrentUtcDateTime()
        {
            // Arrange
            DateTime before = DateTime.UtcNow;

            // Act
            DateTime result = CurrentDateTimeExtension.GetUtcDateTime();

            // Assert
            DateTime after = DateTime.UtcNow;
            Assert.True(result >= before && result <= after);
        }

        [Fact]
        public void GetCurrentUtcTime_ReturnsCurrentUtcTime()
        {
            // Arrange
            DateTime before = DateTime.UtcNow;

            // Act
            DateTime result = CurrentDateTimeExtension.GetCurrentUtcTime();

            // Assert
            DateTime after = DateTime.UtcNow;
            Assert.True(result >= before && result <= after);
        }

        [Fact]
        public void GetUtcNow_ReturnsCurrentUtcNow()
        {
            // Arrange
            DateTime before = DateTime.UtcNow;

            // Act
            DateTime result = CurrentDateTimeExtension.GetUtcNow();

            // Assert
            DateTime after = DateTime.UtcNow;
            Assert.True(result >= before && result <= after);
        }

        [Fact]
        public void StartOfDay_ReturnsStartOfDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.StartOfDay(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 0, 0, 0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EndOfDay_ReturnsEndOfDay()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.EndOfDay(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 23, 59, 59, 999);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StartOfHour_ReturnsStartOfHour()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.StartOfHour(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 10, 0, 0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EndOfHour_ReturnsEndOfHour()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.EndOfHour(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 10, 59, 59, 999);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void StartOfMinute_ReturnsStartOfMinute()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.StartOfMinute(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 10, 30, 0);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void EndOfMinute_ReturnsEndOfMinute()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTime result = CurrentDateTimeExtension.EndOfMinute(dateTime);

            // Assert
            DateTime expected = new DateTime(2023, 12, 24, 10, 30, 59, 999);
            Assert.Equal(expected, result);
        }
    }

}
using DateTimeToolkit.Library.Extensions;
using System;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class ComparisonExtensionTest
    {
        [Fact]
        public void IsBefore_FirstDateBeforeSecond_ReturnsTrue()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 10);

            // Act
            bool result = ComparisonExtension.IsBefore(dateTime1, dateTime2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsBefore_FirstDateAfterSecond_ReturnsFalse()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 10);
            DateTime dateTime2 = new DateTime(2023, 6, 1);

            // Act
            bool result = ComparisonExtension.IsBefore(dateTime1, dateTime2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsAfter_FirstDateAfterSecond_ReturnsTrue()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 10);
            DateTime dateTime2 = new DateTime(2023, 6, 1);

            // Act
            bool result = ComparisonExtension.IsAfter(dateTime1, dateTime2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAfter_FirstDateBeforeSecond_ReturnsFalse()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 10);

            // Act
            bool result = ComparisonExtension.IsAfter(dateTime1, dateTime2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsOnOrBefore_FirstDateBeforeSecond_ReturnsTrue()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 10);

            // Act
            bool result = ComparisonExtension.IsOnOrBefore(dateTime1, dateTime2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOnOrBefore_FirstDateAfterSecond_ReturnsFalse()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 10);
            DateTime dateTime2 = new DateTime(2023, 6, 1);

            // Act
            bool result = ComparisonExtension.IsOnOrBefore(dateTime1, dateTime2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsOnOrAfter_FirstDateAfterSecond_ReturnsTrue()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 10);
            DateTime dateTime2 = new DateTime(2023, 6, 1);

            // Act
            bool result = ComparisonExtension.IsOnOrAfter(dateTime1, dateTime2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOnOrAfter_FirstDateBeforeSecond_ReturnsFalse()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 10);

            // Act
            bool result = ComparisonExtension.IsOnOrAfter(dateTime1, dateTime2);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsSameDay_SameDay_ReturnsTrue()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 1, 23, 59, 59);

            // Act
            bool result = ComparisonExtension.IsSameDay(dateTime1, dateTime2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsSameDay_DifferentDays_ReturnsFalse()
        {
            // Arrange
            DateTime dateTime1 = new DateTime(2023, 6, 1);
            DateTime dateTime2 = new DateTime(2023, 6, 2);

            // Act
            bool result = ComparisonExtension.IsSameDay(dateTime1, dateTime2);

            // Assert
            Assert.False(result);
        }
    }

}

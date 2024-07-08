using DateTimeToolkit.Library.Extensions;
using System;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class OccurrenceExtensionTest
    {
        [Fact]
        public void GetNextOccurrence_ReturnsNextOccurrence()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            TimeSpan interval = new TimeSpan(1, 0, 0, 0); // 1 day interval

            // Act
            DateTime result = OccurrenceExtension.GetNextOccurrence(dateTime, interval);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 2), result);
        }

        [Fact]
        public void GetPreviousOccurrence_ValidInput_ReturnsPreviousOccurrence()
        {
            // Arrange
            DateTime start = new DateTime(2023, 12, 25);
            DayOfWeek dayOfWeek = DayOfWeek.Friday;

            // Act
            DateTime result = start.GetPreviousOccurrence(dayOfWeek);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 22), result);
        }
    }
}
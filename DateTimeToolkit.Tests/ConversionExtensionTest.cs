using DateTimeToolkit.Library.Extensions;
using System;
using System.Globalization;
using Xunit;

namespace DateTimeToolkit.Tests
{
    public class ConversionExtensionTest
    {
        private readonly CultureInfo _enUsCulture = new CultureInfo("en-US");

        [Fact]
        public void ToDateTime_ValidDateStringAndFormat_ReturnsCorrectDateTime()
        {
            // Arrange
            string dateString = "2023-06-01";
            string format = "yyyy-MM-dd";

            // Act
            DateTime result = ConversionExtension.ToDateTime(dateString, format);

            // Assert
            Assert.Equal(new DateTime(2023, 6, 1), result);
        }

        [Fact]
        public void ToString_ValidDateTimeAndFormat_ReturnsCorrectString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1);
            string format = "yyyy-MM-dd";

            // Act
            string result = ConversionExtension.ToString(dateTime, format);

            // Assert
            Assert.Equal("2023-06-01", result);
        }

        [Fact]
        public void ConvertToTimeZone_ValidDateTimeAndTimeZone_ReturnsCorrectDateTime()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Unspecified);
            TimeZoneInfo sourceTimeZone = TimeZoneInfo.Local;
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            DateTime expectedDateTime = TimeZoneInfo.ConvertTime(dateTime, sourceTimeZone, targetTimeZone);

            // Act
            DateTime result = ConversionExtension.ConvertToTimeZone(dateTime, targetTimeZone);

            // Assert
            Assert.Equal(expectedDateTime, result);
        }

        [Fact]
        public void ConvertFromUtc_ValidUtcDateTimeAndTimeZone_ReturnsCorrectDateTime()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc);
            TimeZoneInfo targetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

            // Act
            DateTime result = ConversionExtension.ConvertFromUtc(dateTime, targetTimeZone);

            // Assert
            Assert.Equal(DateTime.Parse("2023-06-01 05:00:00", _enUsCulture), result); // Pacific Standard Time offset is -7 hours
        }

        [Fact]
        public void ConvertToLocal_ValidUtcDateTime_ReturnsCorrectLocalDateTime()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc);

            // Act
            DateTime result = ConversionExtension.ConvertToLocal(dateTime);

            // Get the local time zone and convert the UTC dateTime to local time
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime expectedLocalTime = TimeZoneInfo.ConvertTimeFromUtc(dateTime, localZone);

            // Assert
            Assert.Equal(expectedLocalTime, result);
        }

        [Fact]
        public void ConvertToUtc_ValidLocalDateTime_ReturnsCorrectUtcDateTime()
        {
            // Arrange
            DateTime localDateTime = new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Local);
            TimeZoneInfo localZone = TimeZoneInfo.Local;

            DateTime expectedUtcDateTime = TimeZoneInfo.ConvertTimeToUtc(localDateTime, localZone);

            // Act
            DateTime result = ConversionExtension.ConvertToUtc(localDateTime);

            // Assert
            Assert.Equal(expectedUtcDateTime, result);
        }

        [Fact]
        public void GetIso8601String_ValidDateTime_ReturnsCorrectString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 12, 0, 0, DateTimeKind.Utc);

            // Act
            string result = ConversionExtension.GetIso8601String(dateTime);

            // Assert
            Assert.Equal("2023-06-01T12:00:00.0000000Z", result);
        }

        [Fact]
        public void ParseIso8601String_ValidIso8601String_ReturnsCorrectDateTime()
        {
            // Arrange
            string dateString = "2023-06-01T12:00:00.0000000Z";

            // Act
            DateTime result = ConversionExtension.ParseIso8601String(dateString);

            // Assert
            DateTime expected = DateTime.ParseExact(dateString, "yyyy-MM-ddTHH:mm:ss.fffffffZ", null, DateTimeStyles.RoundtripKind);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetCustomFormattedString_ValidDateTimeAndFormat_ReturnsCorrectString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 6, 1, 12, 0, 0);
            string format = "yyyy-MM-dd HH:mm:ss";

            // Act
            string result = ConversionExtension.GetCustomFormattedString(dateTime, format);

            // Assert
            Assert.Equal("2023-06-01 12:00:00", result);
        }

        [Fact]
        public void GetDayName_ValidDateTime_ReturnsCorrectDayName()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.GetDayName();

            // Assert
            Assert.Equal("Sunday", result);
        }

        [Fact]
        public void GetAbbreviatedDayName_ValidDateTime_ReturnsCorrectAbbreviatedDayName()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.GetAbbreviatedDayName();

            // Assert
            Assert.Equal("Sun", result);
        }

        [Fact]
        public void ToDateStringWithDayName_ValidDateTime_ReturnsCorrectFormattedString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.ToDateStringWithDayName();

            // Assert
            Assert.Equal("Sunday, 24 December 2023", result);
        }

        [Fact]
        public void ToShortDateStringWithDayName_ValidDateTime_ReturnsCorrectShortFormattedString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.ToShortDateStringWithDayName();

            // Assert
            Assert.Equal("Sun, 24 Dec 2023", result);
        }

        [Fact]
        public void ToTimeString_ValidDateTime_ReturnsCorrectTimeString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            string result = dateTime.ToTimeString();

            // Assert
            Assert.Equal("10:30:00", result);
        }

        [Fact]
        public void ToShortTimeString_ValidDateTime_ReturnsCorrectShortTimeString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            string result = ConversionExtension.ToShortTimeString(dateTime);

            // Assert
            Assert.Equal("10:30", result);
        }

        [Fact]
        public void ToFullDateTimeString_ValidDateTime_ReturnsCorrectFullDateTimeString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            string result = dateTime.ToFullDateTimeString();

            // Assert
            Assert.Equal("Sunday, 24 December 2023 10:30:00", result);
        }

        [Fact]
        public void ToShortDateTimeString_ValidDateTime_ReturnsCorrectShortDateTimeString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            string result = dateTime.ToShortDateTimeString();

            // Assert
            Assert.Equal("24/12/2023 10:30", result);
        }

        [Fact]
        public void ToCustomFormatString_ValidDateTimeAndFormat_ReturnsCorrectCustomFormattedString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            string format = "yyyy-MM-dd";

            // Act
            string result = dateTime.ToCustomFormatString(format);

            // Assert
            Assert.Equal("2023-12-24", result);
        }

        [Fact]
        public void GetMonthName_ValidDateTime_ReturnsCorrectMonthName()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.GetMonthName();

            // Assert
            Assert.Equal("December", result);
        }

        [Fact]
        public void GetAbbreviatedMonthName_ValidDateTime_ReturnsCorrectAbbreviatedMonthName()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.GetAbbreviatedMonthName();

            // Assert
            Assert.Equal("Dec", result);
        }

        [Fact]
        public void GetYearAsString_ValidDateTime_ReturnsCorrectYearAsString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);

            // Act
            string result = dateTime.GetYearAsString();

            // Assert
            Assert.Equal("2023", result);
        }

        [Fact]
        public void ToTimeString_TimeSpan_ReturnsCorrectTimeString()
        {
            // Arrange
            TimeSpan timeSpan = new TimeSpan(10, 30, 0);

            // Act
            string result = timeSpan.ToTimeString();

            // Assert
            Assert.Equal("10:30:00", result);
        }

        [Fact]
        public void SetTime_ValidDateTimeAndTime_ReturnsDateTimeWithSetTime()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            int hours = 10;
            int minutes = 30;
            int seconds = 0;

            // Act
            DateTime result = dateTime.SetTime(hours, minutes, seconds);

            // Assert
            Assert.Equal(new DateTime(2023, 12, 24, 10, 30, 0), result);
        }

        [Fact]
        public void TimeElapsedSince_ValidDateTime_ReturnsTimeSpan()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            TimeSpan result = dateTime.TimeElapsedSince();

            // Assert
            Assert.Equal(DateTime.Now - dateTime, result);
        }

        [Fact]
        public void TimeRemainingUntil_ValidDateTime_ReturnsTimeSpan()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            TimeSpan result = dateTime.TimeRemainingUntil();

            // Assert
            Assert.Equal(dateTime - DateTime.Now, result);
        }

        [Fact]
        public void ToDateTimeOffset_ValidDateTime_ReturnsDateTimeOffset()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24, 10, 30, 0);

            // Act
            DateTimeOffset result = dateTime.ToDateTimeOffset();

            // Assert
            Assert.Equal(new DateTimeOffset(dateTime), result);
        }

        [Fact]
        public void ToHumanReadableString_ValidTimeSpan_ReturnsHumanReadableString()
        {
            // Arrange
            TimeSpan timeSpan = new TimeSpan(2, 10, 30, 0);

            // Act
            string result = timeSpan.ToHumanReadableString();

            // Assert
            Assert.Equal("2 days 10 hours", result);
        }

        [Fact]
        public void ToStringWithCulture_ValidDateTimeAndFormatAndCulture_ReturnsFormattedString()
        {
            // Arrange
            DateTime dateTime = new DateTime(2023, 12, 24);
            string format = "yyyy-MM-dd";
            string cultureName = "en-US";

            // Act
            string result = ConversionExtension.ToStringWithCulture(dateTime, format, cultureName);

            // Assert
            Assert.Equal("2023-12-24", result);
        }
    }

}
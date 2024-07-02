<p align="center">
  <img width="128" align="center" src="/assets/logo/calendar-icon.png">
</p>
<h1 align="center">
  DateTimeToolkit
</h1>
<p align="center">
  Comprehensive DateTime utilities for developers.
</p>

# Overview
The DateTime Extension Library provides a comprehensive set of approximately <b>100 extension</b> methods for the DateTime structure, enhancing its functionality for 
a wide range of date and time operations. This library includes methods for calculating the start and end of different date ranges (days, weeks, months, years), 
rounding dates to the nearest interval, checking if dates fall within specific ranges, generating lists of dates, and much more.

# Installation
This project is available as a [NuGet package](https://www.nuget.org/packages/DateTimeToolkit).

```sh
PM> Install-Package DateTimeToolkit
```

# Features
* <b>Start and End of Date Ranges:</b> Methods to get the start and end of days, weeks, months, and years.
* <b>Rounding:</b> Methods to round dates to the nearest specified interval.
* <b>Range Checking:</b> Methods to check if a date falls within a specified range.
* <b>Date Generation:</b> Methods to generate lists of dates within a specific range.
* <b>Occurrences:</b> Methods to get occurrences between two dates according to a specified interval.
* <b>Week Number Calculation:</b> Methods to calculate the week number of a year for a given date.
* <b>Custom Week Start:</b> Methods to get the start and end of weeks with a customizable start day.

# Usage Examples
Here are some usage examples for the extension methods provided in this library:

* <b>Start and End of Date Ranges</b>
```csharp
DateTime now = new DateTime(2023, 6, 1, 15, 30, 0);

// Get the start and end of the day
DateTime startOfDay = DateTimeRangeExtension.GetStartOfDay(now);
DateTime endOfDay = DateTimeRangeExtension.GetEndOfDay(now);

// Output: startOfDay = 2023-06-01 00:00:00
// Output: endOfDay = 2023-06-01 23:59:59.9999999


// Get the start and end of the month
DateTime startOfMonth = DateTimeRangeExtension.GetStartOfMonth(now);
DateTime endOfMonth = DateTimeRangeExtension.GetEndOfMonth(now);

// Output: startOfMonth = 2023-06-01 00:00:00
// Output: endOfMonth = 2023-06-30 00:00:00


// Get the start and end of the year
DateTime startOfYear = DateTimeRangeExtension.GetStartOfYear(now);
DateTime endOfYear = DateTimeRangeExtension.GetEndOfYear(now);

// Output: startOfYear = 2023-01-01 00:00:00
// Output: endOfYear = 2023-12-31 00:00:00


// Get the start and end of the week (assuming week starts on Monday)
DateTime startOfWeek = DateTimeRangeExtension.GetStartOfWeek(now, DayOfWeek.Monday);
DateTime endOfWeek = DateTimeRangeExtension.GetEndOfWeek(now, DayOfWeek.Monday);

// Output: startOfWeek = 2023-05-29 00:00:00
// Output: endOfWeek = 2023-06-04 00:00:00
```

* <b>Rounding Dates</b>
```csharp
DateTime dateTime = new DateTime(2023, 12, 24, 10, 35, 0);
TimeSpan interval = new TimeSpan(0, 30, 0);
bool roundUp = false;

// Round to nearest interval (e.g., 30 minutes)
DateTime rounded = DateTimeCalculationExtension.RoundToNearestInterval(dateTime, interval, roundUp);

// Output: rounded = 2023-12-24 10:30:00
```

* <b>Range Checking</b>

```csharp
DateTime date = new DateTime(2023, 12, 24);
DateTime startDate = new DateTime(2023, 12, 20);
DateTime endDate = new DateTime(2023, 12, 31);

// Check if date falls within the range
bool isInRange = DateTimeRangeExtension.IsDateInRange(date, startDate, endDate);

// Output: isInRange = true
```

* <b>Date Generation</b>

```csharp
DateTime startDate = new DateTime(2023, 12, 20);
DateTime endDate = new DateTime(2023, 12, 24);

// Generate a list of dates within the specified range
List<DateTime> datesInRange = DateTimeRangeExtension.GetDatesInRange(startDate, endDate);

// Output: datesInRange = [2023-12-20 00:00:00,
2023-12-21 00:00:00,
2023-12-22 00:00:00,
2023-12-23 00:00:00,
2023-12-24 00:00:00]
```

* <b>Occurrences</b>

```csharp
DateTime start = new DateTime(2023, 6, 1);
DateTime end = new DateTime(2023, 6, 5);
TimeSpan interval = new TimeSpan(1, 0, 0, 0);

// Get occurrences between the start and end dates
List<DateTime> occurrences = DateTimeRangeExtension.GetOccurrences(start, end, interval);

// Output: occurrences = [2023-06-01 00:00:00, 
2023-06-02 00:00:00,
2023-06-03 00:00:00, 
2023-06-04 00:00:00,
2023-06-05 00:00:00]
```

* <b>Week Number Calculation</b>

```csharp
DateTime dateTime = new DateTime(2023, 12, 24);
CultureInfo culture = new CultureInfo("en-US");

// Get the week number of the year for the specified date
int weekNumber = DateTimeCalculationExtension.GetWeekOfYear(dateTime, culture);

// Output: weekNumber = 52
```


*<b>See [Unit Tests](https://github.com/hoseinprg/DateTimeToolkit/tree/master/test/DateTimeToolkit.Tests) in the project for more details and examples of all extensions.</b>*


## Contributing

Contributions are welcome! Please fork this repository and submit a pull request for any features, bug fixes, or improvements.

## License

This project is licensed under the MIT License - see the [LICENSE](https://github.com/hoseinprg/DateTimeToolkit/blob/master/LICENSE) file for details.
---
title: SWQL Functions
---

SolarWinds Query Language supports a number of built-in functions that can be used in queries.

## General Functions

* `IsNull(a, b)` - Returns `a` unless it is `NULL`, else returns `b`.
* `Case when c then a else b end` - Returns `a` if `c` is true else returns `b`.

## Numeric Functions

* `Abs(n)` - Returns the absolute value of `n`.
* `Ceiling(n)` - Returns the smallest integer that is not less than `n`.
* `Floor(n)` - Returns the largest integer that is not greater than `n`.
* `Round(n, p)` - Returns `n` rounded to the `p` decimal places.

## Date/time Functions

* `AddDate(u, n, d)` - Returns a date `n` units after `d`, where the unit is specified by the first parameter `u`, which must be one of: `'millisecond'`, `'second'`, `'minute'`, `'hour'`, `'day'`, `'week'`, `'month'`, or `'year'`. The `u` argument must be a string literal. It can't be a query parameter or value derived from the data.
* `AddDay(n, d)` - Returns a date `n` days after `d`.
* `AddHour(n, d)` - Returns a date `n` hours after `d`.
* `AddMillisecond(n, d)` - Returns a date `n` milliseconds after `d`.
* `AddMinute(n, d)` - Returns a date `n` minutes after `d`.
* `AddMonth(n, d)` - Returns a date `n` months after `d`.
* `AddSecond(n, d)` - Returns a date `n` seconds after `d`.
* `AddWeek(n, d)` - Returns a date `n` weeks after `d`.
* `AddYear(n, d)` - Returns a date `n` years after `d`.
* `DateTime` - Converts a string to a date. In most scenarios this conversion will happen automatically when needed by usage.
* `DateTrunc('datepart', 'd')` - Where `'datepart'` is one of the following strings: `'minute'`, `'hour'`, `'day'`, `'week'`, `'month'`, `'quarter'`, `'year'`. Returns a date like `d`, but with all components more granular than `'datepart'` set to zero.
* `Day(d)` - Returns the day of the month of `d`.
* `DayDiff(a, b)` - Returns the number of days (rounded to the nearest integer) that `b` is later than `a`.
* `DayOfYear(d)` - Returns the day of year of `d`. January 1 is 1, February 1 is 32, etc.
* `Downsample(d, p)` - Rounds the supplied timestamp `d` to the defined time period `p`.  For example, a period of `'00:15:00'` would round to the nearest 15 minute time increment. Requires Orion 2018.3 or later.
* `GetDate()` - Returns the current date in local time at the Orion server.
* `GetUtcDate()` - Returns the current date and time in UTC.
* `Hour(d)` - Returns the hour part of `d` (in 24 hour format).
* `HourDiff(a, b)` - Returns the number of hours (rounded to the nearest integer) that `b` is later than `a`.
* `Millisecond(d)` - Returns the millisecond part of `d`.
* `MillisecondDiff(a, b)` - Returns the number of milliseconds (rounded to the nearest integer) that `b` is later than `a`.
* `Minute` - Returns the minute part of `d`.
* `MinuteDiff(a, b)` - Returns the number of minutes (rounded to the nearest integer) that `b` is later than `a`.
* `Month` - Returns the month part of `d`. January is 1.
* `MonthDiff(a, b)` - Returns the number of months (rounded to the nearest integer) that `b` is later than `a`.
* `QuarterOfYear(d)` - Returns the quarter of the year that contains `d`. January, February, and March are 1; April, May, and June are 2; etc.
* `Second(d)` - Returns the second part of `d`.
* `SecondDiff(a, b)` - Returns the number of seconds (rounded to the nearest integer) that `b` is later than `a`.
* `ToLocal(d)` - Converts `d` to local time on the Orion server.
* `ToUtc` - Converts `d` to UTC time.
* `Week(d)` - Returns the week number of `d`.
* `WeekDay(d)` - Returns the day of the week of `d` as a number, with Sunday = 0, Monday = 1, ..., Saturday = 6. _Available in Orion Platform 2016.1 and later._
* `WeekDiff(a, b)` - Returns the number of weeks (rounded to the nearest integer) that `b` is later than `a`.
* `Year(d)` - Returns the year of `d`.
* `YearDiff(a, b)` - Returns the number of years (rounded to the nearest integer) that `b` is later than `a`.

## Aggregate Functions

Aggregate functions operate on a whole group of values at once. If a `GROUP BY` clause is present in the query, the aggregate function will operate on all values for each set of `GROUP BY` keys. If no `GROUP BY` clause is present, the aggregate function will operate on all values returned by the query.

* `Avg(n)` - Returns the average (arithmetic mean) of the values in the group.
* `Count(n)` - Returns the number of non-`NULL` values in the group.
* `Max(n)` - Returns the largest value in the group.
* `Min(n)` - Returns the smallest value in the group.
* `Sum(n)` - Returns the arithmetic sum of the values in the group.

## Array functions

* `ArrayContains(a, v)` - Returns true if array `a` contains value `v`.
* `ArrayLength(a)` - Returns the number of elements in array `a`.
* `ArrayValueAt(a, i)` - Returns the array element at position `i` in array `a`, counting from zero.

## String Functions

* `Concat(a, b, c, ...)` - Takes one or more arguments and returns a single string that is the concatenation of the values of the arguments.
* `EscapeSWISUriValue(a)` - Returns `a` with certain characters escaped. Intended for internal use only.
* `Length(s)` - Returns the length of string `s`.
* `CharIndex(toFind, toSearch [, start])` - Returns the position at which `toFind` occurs within `toSearch` (starting at position `start`, if provided) or zero if `toFind` is not found. Supported since Orion Platform 2018.2 (NPM 12.3) and later.
* `SubString(s, start, length)` - Returns a substring of `length` characters starting at position `start` (the first character is position 1).
* `Replace(expression, pattern, replacement)` - Replaces all occurrences of a specified string (`pattern`) value in `expression` with another string value (`replacement`). Supported since Orion Platform 2017.3 (NPM 12.2) and later.
* `ToLower(a)` - Converts `a` to all lowercase.
* `ToUpper(a)` - Converts `a` to all uppercase.
* `ToString(a)` - Converts `a` to a string. In most scenarios this conversion will happen automatically when needed by usage.
* `UriEquals(a, b)` - Returns true if SWIS Uri `a` refers to the same entity instance as SWIS Uri `b`.

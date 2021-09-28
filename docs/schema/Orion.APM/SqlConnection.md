---
id: SqlConnection
slug: SqlConnection
---

# Orion.APM.SqlConnection

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL connection.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ServerSessionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of server session. | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SQL database. | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains server IP address. | everyone |
| Login | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains login user name. | everyone |
| ConnectTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of database connection. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an connection. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for connection information. | everyone |
| TransferredBytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of transferred bytes during connection. | everyone |
| ConnectionDurationInSecs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the connection duration in seconds. | everyone |
| ConnectionDurationHourPart | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the hour part of connection duration. | everyone |
| ConnectionDurationMinutePart | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the minutes part of connection duration. | everyone |
| IdleTimeInSecs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the connection idle time in seconds. | everyone |
| IdleTimeHourPart | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the hour part of connection idle time. | everyone |
| IdleTimeMinutePart | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the minutes part of connection idle time. | everyone |


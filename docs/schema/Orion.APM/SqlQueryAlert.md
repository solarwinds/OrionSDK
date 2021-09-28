---
id: SqlQueryAlert
slug: SqlQueryAlert
---

# Orion.APM.SqlQueryAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL query information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of SQL query. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| SqlBbDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| ServerQueryHash | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The SQL query GUID. | everyone |
| QueryText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL query text. | everyone |
| LastExecutionTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last SQL query execution. | everyone |
| LastPollTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for SQL query. | everyone |
| PlanCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the SQL query plan count. | everyone |
| ExecutionCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains the SQL query execution count. | everyone |
| CpuTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the SQL query CPU count. | everyone |
| PhysicalReadCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the physical reads count. | everyone |
| LogicalReadCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the logical reads count. | everyone |
| LogicalWriteCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the logical writes count. | everyone |
| AvgDuration | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the average query duration. | everyone |
| Spid | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the SQL server process ID. | everyone |
| Login | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains login user name. | everyone |
| Host | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains SQL server name. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an SQL query. | everyone |
| DisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The status of an SQL query. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlApplicationAlert | [Orion.APM.SqlServerApplicationAlert](./../Orion.APM/SqlServerApplicationAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlQueryAlert (System.Hosting) |
| SqlQuery | [Orion.APM.SqlQuery](./../Orion.APM/SqlQuery) | Defined by relationship Orion.APM.SqlQueryAlertReferencesSqlQuery (System.Reference) |


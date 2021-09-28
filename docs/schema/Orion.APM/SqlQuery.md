---
id: SqlQuery
slug: SqlQuery
---

# Orion.APM.SqlQuery

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL query information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| QueryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL query. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ServerQueryHash | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The SQL query GUID. | everyone |
| ServerQueryHandle | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | Original SQL query handle (needed for DPOA module integration). | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| QueryText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL query text. | everyone |
| LastExecutionTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last SQL query execution. | everyone |
| Spid | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the SQL server process ID. | everyone |
| PlanCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the SQL query plan count. | everyone |
| ExecutionCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains the SQL query execution count. | everyone |
| CpuTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the SQL query CPU count. | everyone |
| PhysicalReadCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the physical reads count. | everyone |
| LogicalReadCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the logical reads count. | everyone |
| LogicalWriteCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the logical writes count. | everyone |
| AvgDuration | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the average query duration. | everyone |
| Login | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains login user name. | everyone |
| Host | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains SQL server name. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an SQL query. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for SQL query. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to SQL query details page. Used in alerting. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string representation of query name. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlQueryAlert | [Orion.APM.SqlQueryAlert](./../Orion.APM/SqlQueryAlert) | Defined by relationship Orion.APM.SqlQueryAlertReferencesSqlQuery (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseQueries (System.Hosting) |


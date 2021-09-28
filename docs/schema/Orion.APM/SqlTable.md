---
id: SqlTable
slug: SqlTable
---

# Orion.APM.SqlTable

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL table information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TableID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL table. | everyone |
| SqlDatabaseFileGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file group. | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| ServerObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL table. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the table name. | everyone |
| RowCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains the SQL table rows count. | everyone |
| TotalSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database table total space. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an SQL table. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for SQL table. | everyone |
| IndexSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The bytes value that contains table index used space. | everyone |
| PercentUsageByIndex | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) | The percentage representation of SQL table index space usage. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseTables (System.Hosting) |


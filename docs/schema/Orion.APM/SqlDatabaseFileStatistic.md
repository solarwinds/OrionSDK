---
id: SqlDatabaseFileStatistic
slug: SqlDatabaseFileStatistic
---

# Orion.APM.SqlDatabaseFileStatistic

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database file statistic.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database file information. | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file used space. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file size. | everyone |
| AvailableAutoGrowSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the available auto growth space. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| File | [Orion.APM.SqlDatabaseFile](./../Orion.APM/SqlDatabaseFile) | Defined by relationship Orion.APM.SqlDatabaseFileHostsSqlDatabaseFileStatistic (System.Hosting) |


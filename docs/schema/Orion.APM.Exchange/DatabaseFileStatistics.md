---
id: DatabaseFileStatistics
slug: DatabaseFileStatistics
---

# Orion.APM.Exchange.DatabaseFileStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the database file statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database file data. | everyone |
| DatabaseFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database file status. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file size. | everyone |
| AvailableSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the database file available space. | everyone |
| AvailableWhiteSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the database file available white space. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseFile | [Orion.APM.Exchange.DatabaseFile](./../Orion.APM.Exchange/DatabaseFile) | Defined by relationship Orion.APM.Exchange.DatabaseFileHostsDatabaseFileStatistics (System.Hosting) |


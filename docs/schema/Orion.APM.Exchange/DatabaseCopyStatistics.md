---
id: DatabaseCopyStatistics
slug: DatabaseCopyStatistics
---

# Orion.APM.Exchange.DatabaseCopyStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the database copy statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database copy. | everyone |
| DatabaseCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database copy. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy status. | everyone |
| CopyState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy state. | everyone |
| CopyQueueLength | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Indicates the number of log files waiting to be copied and inspected. | everyone |
| ReplayQueueLength | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Indicates the number of log files waiting to be replayed into this copy of the database. | everyone |
| ContentIndexState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the content index state. | everyone |
| IsActive | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if database copy is active. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseCopy | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.DatabaseCopyHostsDatabaseCopyStatistics (System.Hosting) |


---
id: DatabaseStatistics
slug: DatabaseStatistics
---

# Orion.APM.Exchange.DatabaseStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the database statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database data. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database status. | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database availability. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.Database](./../Orion.APM.Exchange/Database) | Defined by relationship Orion.APM.Exchange.DatabaseHostsDatabaseStatistics (System.Hosting) |


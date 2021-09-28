---
id: SqlDatabaseStatus
slug: SqlDatabaseStatus
---

# Orion.APM.SqlDatabaseStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database status.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database. | everyone |
| OperationalState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The integer value that contains the database operational state (Online, Restoring, Recovering,Recovery pending, Suspect, Emergency, Offline and Copying). | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseHostsStatus (System.Hosting) |


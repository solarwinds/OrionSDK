---
id: SqlDatabaseAlert
slug: SqlDatabaseAlert
---

# Orion.APM.SqlDatabaseAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| DatabaseName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database name. | everyone |
| Collation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database collation. | everyone |
| OperationalState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database operational state (Online, Restoring, Recovering,Recovery pending, Suspect, Emergency, Offline and Copying). | everyone |
| RecoveryModel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The integer value that contains the database recovery model. | everyone |
| CompatibilityLevel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The integer value that contains the database compatibility level. | everyone |
| LastBackup | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last database backup. | everyone |
| DatabaseSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database size. | everyone |
| DatabaseFreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database free space. | everyone |
| DatabaseFreeSpaceInPercents | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The percentage representation of free database space. | everyone |
| TransactionLogSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database log size. | everyone |
| TransactionLogFreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the transaction log free space. | everyone |
| TransactionLogFreeSpaceInPercents | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The percentage representation of free transaction log space. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database. | everyone |
| DisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The status of an database. | everyone |
| DatabaseTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for database. | everyone |
| MirroringState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The mirroring state of an database. | everyone |
| DaysFromLastBackup | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of days passed since last database backup. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlApplicationAlert | [Orion.APM.SqlServerApplicationAlert](./../Orion.APM/SqlServerApplicationAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlDatabaseAlert (System.Hosting) |
| SqlDatabase | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseAlertReferencesSqlDatabase (System.Reference) |


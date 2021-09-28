---
id: SqlDatabase
slug: SqlDatabase
---

# Orion.APM.SqlDatabase

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| ServerDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL server database. | everyone |
| OperationalState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database operational state (Online, Restoring, Recovering,Recovery pending, Suspect, Emergency, Offline and Copying). | everyone |
| Collation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database collation. | everyone |
| RecoveryModel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database recovery model. | everyone |
| CompatibilityLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database compatibility level. | everyone |
| LastBackup | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last database backup. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for database. | everyone |
| DatabaseSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database size. | everyone |
| TransactionLogSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database log size. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates database entity description. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The database status description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to database details page. Used in alerting. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the database details page URL. It is used by Network Atlas. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of application item. | everyone |
| AutoCloseOn | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The flag reflecting the value of database is_auto_close_on option. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FileGroups | [Orion.APM.SqlDatabaseFileGroup](./../Orion.APM/SqlDatabaseFileGroup) | Defined by relationship Orion.APM.SqlDatabaseFileGroups (System.Hosting) |
| Files | [Orion.APM.SqlDatabaseFile](./../Orion.APM/SqlDatabaseFile) | Defined by relationship Orion.APM.SqlDatabaseFileDatabase (System.Hosting) |
| DatabaseStatus | [Orion.APM.SqlDatabaseStatus](./../Orion.APM/SqlDatabaseStatus) | Defined by relationship Orion.APM.SqlDatabaseHostsStatus (System.Hosting) |
| Indexes | [Orion.APM.SqlIndex](./../Orion.APM/SqlIndex) | Defined by relationship Orion.APM.SqlDatabaseIndexes (System.Hosting) |
| Queries | [Orion.APM.SqlQuery](./../Orion.APM/SqlQuery) | Defined by relationship Orion.APM.SqlDatabaseQueries (System.Hosting) |
| Tables | [Orion.APM.SqlTable](./../Orion.APM/SqlTable) | Defined by relationship Orion.APM.SqlDatabaseTables (System.Hosting) |
| SqlDatabaseMirroring | [Orion.APM.SqlDatabaseMirroring](./../Orion.APM/SqlDatabaseMirroring) | Defined by relationship Orion.APM.SqlDatabaseHostsSqlDatabaseMirroring (System.Hosting) |
| SqlDatabaseAlert | [Orion.APM.SqlDatabaseAlert](./../Orion.APM/SqlDatabaseAlert) | Defined by relationship Orion.APM.SqlDatabaseAlertReferencesSqlDatabase (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlServer | [Orion.APM.SqlServerApplication](./../Orion.APM/SqlServerApplication) | Defined by relationship Orion.APM.SqlServerHostsSqlDatabase (System.Hosting) |
| SqlApplicationAlert | [Orion.APM.SqlServerApplicationAlert](./../Orion.APM/SqlServerApplicationAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertReferencesSqlDatabase (System.Reference) |


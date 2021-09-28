---
id: SqlDatabaseFile
slug: SqlDatabaseFile
---

# Orion.APM.SqlDatabaseFile

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database file information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file. | everyone |
| SqlDatabaseFileGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent database file group. | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SQL database. | everyone |
| ServerFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of server database file. | everyone |
| FileType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The byte value that contains the database file type. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database file name. | everyone |
| PhysicalName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database file physical name. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file size. | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file used space. | everyone |
| MaxSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file maximum size. | everyone |
| Growth | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database file growth. | everyone |
| IsPercentGrowth | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The integer value that contains the database file growth in percent. | everyone |
| AutoGrowth | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The integer value that contains the database file auto growth. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file volume. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database file. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for database file information. | everyone |
| AvailableAutoGrowSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the available auto growth space. | everyone |
| UsedSpacePercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of database file space usage. | everyone |
| WhiteSpaceFreePercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of free database file whitespace. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to database file details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FileStatistic | [Orion.APM.SqlDatabaseFileStatistic](./../Orion.APM/SqlDatabaseFileStatistic) | Defined by relationship Orion.APM.SqlDatabaseFileHostsSqlDatabaseFileStatistic (System.Hosting) |
| SqlDatabaseFileAlert | [Orion.APM.SqlDatabaseFileAlert](./../Orion.APM/SqlDatabaseFileAlert) | Defined by relationship Orion.APM.SqlDatabaseFileAlertReferencesSqlDatabaseFile (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseFileDatabase (System.Hosting) |


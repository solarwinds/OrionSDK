---
id: SqlDatabaseFileAlert
slug: SqlDatabaseFileAlert
---

# Orion.APM.SqlDatabaseFileAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database file. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SQL database. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file volume. | everyone |
| VolumeCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database file volume caption. | everyone |
| VolumeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database file volume. | everyone |
| VolumeDisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The status of an database file volume. | everyone |
| VolumeQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The long value that contains the database file volume queue length. | everyone |
| VolumeLatency | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The long value that contains the database file volume latency. | everyone |
| VolumeLatencyInMilliseconds | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The long value that contains the database file volume latency in milliseconds. | everyone |
| VolumeTotalDiskIOPS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The long value that contains the database file volume total disk input output operations. | everyone |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file. | everyone |
| FileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database file name. | everyone |
| PhysicalName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database file physical name. | everyone |
| FileType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The byte value that contains the database file type. | everyone |
| DatabaseFileStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an database file. | everyone |
| DatabaseFileDisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The status of an database file. | everyone |
| DatabaseFileTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for database file information. | everyone |
| AutoGrowth | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The integer value that contains the database file auto growth. | everyone |
| AvailableAutoGrowSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the available auto growth space. | everyone |
| Growth | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database file growth. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file size. | everyone |
| MaxSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file maximum size. | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file used space. | everyone |
| DatabaseFileFreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the database file free space. | everyone |
| DatabaseFileFreeSpaceInPercents | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The percentage representation of free database file space. | everyone |
| IsPercentGrowth | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The integer value that contains the database file growth in percent. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlApplicationAlert | [Orion.APM.SqlServerApplicationAlert](./../Orion.APM/SqlServerApplicationAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlDatabaseFileAlert (System.Hosting) |
| SqlDatabaseFile | [Orion.APM.SqlDatabaseFile](./../Orion.APM/SqlDatabaseFile) | Defined by relationship Orion.APM.SqlDatabaseFileAlertReferencesSqlDatabaseFile (System.Reference) |


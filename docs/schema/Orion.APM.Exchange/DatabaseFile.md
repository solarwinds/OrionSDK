---
id: DatabaseFile
slug: DatabaseFile
---

# Orion.APM.Exchange.DatabaseFile

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the database file information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file. | everyone |
| DatabaseCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent database copy. | everyone |
| PhysicalName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the name of the directory where database file is stored. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the database file size. | everyone |
| AvailableSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the database file available space. | everyone |
| AvailableWhiteSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the database file available white space. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file volume. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database file status. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for database file data. | everyone |
| UsedSpacePercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of database file disk space usage. | everyone |
| WhiteSpaceFreePercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of free database file white space. | everyone |
| StatusDbUsage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database file usage status. | everyone |
| StatusDbWhitespaceSize | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database file white space usage status. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseFileStatistics | [Orion.APM.Exchange.DatabaseFileStatistics](./../Orion.APM.Exchange/DatabaseFileStatistics) | Defined by relationship Orion.APM.Exchange.DatabaseFileHostsDatabaseFileStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.DatabaseFileDatabase (System.Hosting) |


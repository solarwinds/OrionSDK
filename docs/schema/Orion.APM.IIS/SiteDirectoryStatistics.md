---
id: SiteDirectoryStatistics
slug: SiteDirectoryStatistics
---

# Orion.APM.IIS.SiteDirectoryStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents historical statistics of site's directory.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of target site. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for site's directory statistics. | everyone |
| Path | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the name of the directory where files are stored. | everyone |
| FilesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the count of web site files. | everyone |
| FilesSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the size of web site files. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of web site file's volume. | everyone |
| VolumeSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that specifies size of web site file's volume. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SiteDirectory | [Orion.APM.IIS.SiteDirectory](./../Orion.APM.IIS/SiteDirectory) | Defined by relationship Orion.APM.IIS.SiteDirectoryStatisticsReferencesSiteDirectory (System.Reference) |


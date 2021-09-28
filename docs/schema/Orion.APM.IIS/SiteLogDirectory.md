---
id: SiteLogDirectory
slug: SiteLogDirectory
---

# Orion.APM.IIS.SiteLogDirectory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of site's log file's.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of target site. | everyone |
| SiteName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the unique name of the web site. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the site log directory and site name. | everyone |
| Directory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the name of the directory where log files are stored. | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifices if logging is enabled for site. | everyone |
| FilesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the count of web site log files. | everyone |
| FilesCountStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies status of the count of web site log files. | everyone |
| FilesSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the size of web site log files. | everyone |
| FilesSizeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies status of the size of web site log files. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of web site log file's volume. | everyone |
| VolumeSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that specifies size of web site log file's volume. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to site details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SiteLogDirectoryStatistics | [Orion.APM.IIS.SiteLogDirectoryStatistics](./../Orion.APM.IIS/SiteLogDirectoryStatistics) | Defined by relationship Orion.APM.IIS.SiteLogDirectoryStatisticsReferencesSiteLogDirectory (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteHostsSiteLogFile (System.Hosting) |


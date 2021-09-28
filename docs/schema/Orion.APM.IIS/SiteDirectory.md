---
id: SiteDirectory
slug: SiteDirectory
---

# Orion.APM.IIS.SiteDirectory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of site's file's.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of target site. | everyone |
| SiteName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the unique name of the web site. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the site directory and site name. | everyone |
| PhysicalPath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the name of the directory where files are stored. | everyone |
| FilesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the count of web site files. | everyone |
| FilesCountStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies status of the count of web site files. | everyone |
| FilesSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the size of web site files. | everyone |
| FilesSizeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies status of the size of web site files. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of web site file's volume. | everyone |
| VolumeSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that specifies size of web site file's volume. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to site details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SiteDirectoryStatistics | [Orion.APM.IIS.SiteDirectoryStatistics](./../Orion.APM.IIS/SiteDirectoryStatistics) | Defined by relationship Orion.APM.IIS.SiteDirectoryStatisticsReferencesSiteDirectory (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteHostsSiteDirectory (System.Hosting) |


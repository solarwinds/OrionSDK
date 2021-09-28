---
id: Site
slug: Site
---

# Orion.APM.IIS.Site

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents IIS site.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IISSiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the web site ID. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the unique name of the web site. | everyone |
| State | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of web site state. | everyone |
| ApplicationPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application pool. | everyone |
| ServerAutoStart | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean representation of web site auto start setting. | everyone |
| PhysicalPath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates the physical path that is associated with the virtual directory. | everyone |
| ConnectionTimeoutSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies connection timeout for a web site. | everyone |
| MaxBandwidth | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that specifies the maximum network bandwidth, in bytes per second. | everyone |
| MaxConnections | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that specifies the maximum number of simultaneous connections to a server. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates web site entity description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the WEB site details page URL. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the WEB site details page URL. It is used by Network Atlas. | everyone |
| AverageResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value representing average duration of Web site requests. | everyone |
| AverageResponseTimeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value representing average site response time status based on site request thresholds. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The ErrorCode value, assigning the category of an issue happened during polling the site. If pool was successful, value is 0. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The detail message explaining, why the ErrorCode is not OK. This value is empty in case no error happened. | everyone |
| CurrentConnections | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the current number of site connections. | everyone |
| DisplayState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string representation of web site state. | everyone |
| CurrentHttpBindingsUrls | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The last urls checked up by Http Bindings Monitor. | everyone |
| CurrentHttpsBindingsUrls | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The last urls checked up by Https Bindings Monitor. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of a site. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The description of the status of a site. | everyone |
| IsUnmanaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that indicates if site is unmanaged. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of application item. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Requests | [Orion.APM.IIS.Request](./../Orion.APM.IIS/Request) | Defined by relationship Orion.APM.IIS.SiteHostsRequest (System.Hosting) |
| SiteBinding | [Orion.APM.IIS.SiteBinding](./../Orion.APM.IIS/SiteBinding) | Defined by relationship Orion.APM.IIS.SiteHostsSiteBinding (System.Hosting) |
| SiteLogDirectory | [Orion.APM.IIS.SiteLogDirectory](./../Orion.APM.IIS/SiteLogDirectory) | Defined by relationship Orion.APM.IIS.SiteHostsSiteLogFile (System.Hosting) |
| SiteDirectory | [Orion.APM.IIS.SiteDirectory](./../Orion.APM.IIS/SiteDirectory) | Defined by relationship Orion.APM.IIS.SiteHostsSiteDirectory (System.Hosting) |
| SiteConnectionStatistics | [Orion.APM.IIS.SiteConnectionStatistics](./../Orion.APM.IIS/SiteConnectionStatistics) | Defined by relationship Orion.APM.IIS.SiteConnectionStatisticsReferencesSite (System.Reference) |
| SiteStatus | [Orion.APM.IIS.SiteStatus](./../Orion.APM.IIS/SiteStatus) | Defined by relationship Orion.APM.IIS.SiteHostsStatus (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.IIS.Application](./../Orion.APM.IIS/Application) | Defined by relationship Orion.APM.IIS.ApplicationHostsSite (System.Hosting) |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship Orion.APM.IIS.SiteReferencesApplicationPool (System.Reference) |

## Verbs

### Start

Start IIS site.

#### Access control

everyone

### Stop

Stop IIS site.

#### Access control

everyone

### Restart

Restart IIS site.

#### Access control

everyone


---
id: SiteConnectionStatistics
slug: SiteConnectionStatistics
---

# Orion.APM.IIS.SiteConnectionStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents historical statistics of site connections.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of target site. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for site connections statistics. | everyone |
| MinSiteConnectionsValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the minimum number of site connections. | everyone |
| MaxSiteConnectionsValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the maximum number of site connections. | everyone |
| AvgSiteConnectionsValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that specifies the average number of site connections. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteConnectionStatisticsReferencesSite (System.Reference) |


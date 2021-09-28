---
id: SiteStatus
slug: SiteStatus
---

# Orion.APM.IIS.SiteStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of site's status.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of request target site. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The time stamp. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The site status. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteHostsStatus (System.Hosting) |


---
id: SiteStatus
slug: SiteStatus
---

# Orion.APM.ActiveDirectory.SiteStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of Active Directory site's status.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of the Site. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Status Time Stamp. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Status of the site | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application status description. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.ActiveDirectory.Site](./../Orion.APM.ActiveDirectory/Site) | Defined by relationship Orion.APM.ActiveDirectory.SiteHostsStatus (System.Hosting) |


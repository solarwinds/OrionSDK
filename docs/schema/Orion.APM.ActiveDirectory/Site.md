---
id: Site
slug: Site
---

# Orion.APM.ActiveDirectory.Site

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory site.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of the site. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the site. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the application pool details page URL. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the WEB site details page URL. It is used by Network Atlas. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of application item. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Status of the site | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status of the site | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Site name displayed on resource. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SiteStatus | [Orion.APM.ActiveDirectory.SiteStatus](./../Orion.APM.ActiveDirectory/SiteStatus) | Defined by relationship Orion.APM.ActiveDirectory.SiteHostsStatus (System.Hosting) |
| Subnet | [Orion.APM.ActiveDirectory.Subnet](./../Orion.APM.ActiveDirectory/Subnet) | Defined by relationship Orion.APM.ActiveDirectory.SiteSubnets (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.ActiveDirectory.Application](./../Orion.APM.ActiveDirectory/Application) | Defined by relationship Orion.APM.ActiveDirectory.ApplicationHostsSite (System.Hosting) |
| Links | [Orion.APM.ActiveDirectory.Link](./../Orion.APM.ActiveDirectory/Link) | Defined by relationship Orion.APM.ActiveDirectory.LinkToSite (System.Reference) |


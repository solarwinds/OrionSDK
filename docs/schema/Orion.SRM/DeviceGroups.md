---
id: DeviceGroups
slug: DeviceGroups
---

# Orion.SRM.DeviceGroups

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains info about supported device groups

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DeviceGroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FlowTypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TipPicture | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LinkName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LinkURL | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Providers | [Orion.SRM.Providers](./../Orion.SRM/Providers) | Defined by relationship Orion.SRM.DeviceGroupsReferencesProviders (System.Reference) |
| RESTConfiguration | [Orion.SRM.RESTConfigurations](./../Orion.SRM/RESTConfigurations) | Defined by relationship Orion.SRM.DeviceGroupsReferencesRESTConfigurations (System.Reference) |
| Templates | [Orion.SRM.Templates](./../Orion.SRM/Templates) | Defined by relationship Orion.SRM.DeviceGroupsReferencesTemplates (System.Reference) |


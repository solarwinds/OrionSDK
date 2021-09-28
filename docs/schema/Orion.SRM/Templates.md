---
id: Templates
slug: Templates
---

# Orion.SRM.Templates

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains all supported device polling templates and associated info

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TemplateID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Template | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeviceGroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Priority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DeviceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Version | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageArrays | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.SRM.TemplatesReferencesStorageArrays (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DeviceGroup | [Orion.SRM.DeviceGroups](./../Orion.SRM/DeviceGroups) | Defined by relationship Orion.SRM.DeviceGroupsReferencesTemplates (System.Reference) |


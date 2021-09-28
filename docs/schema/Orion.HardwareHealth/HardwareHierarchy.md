---
id: HardwareHierarchy
slug: HardwareHierarchy
---

# Orion.HardwareHealth.HardwareHierarchy

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Hierarchy.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| HardwareInfoID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Info Base. | everyone |
| ItemID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Item Base. | everyone |
| ParentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent. | everyone |
| HardwareCategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Category. | everyone |
| HasItem | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean information indicates if entity has items. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value representation of the name. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategory | [Orion.HardwareHealth.HardwareCategory](./../Orion.HardwareHealth/HardwareCategory) | Defined by relationship Orion.HardwareHealth.HardwareHierarchysReferenceHardwareCategory (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Children | [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareHierarchy (System.Hosting) |


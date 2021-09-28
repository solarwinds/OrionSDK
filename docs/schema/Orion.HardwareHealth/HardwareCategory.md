---
id: HardwareCategory
slug: HardwareCategory
---

# Orion.HardwareHealth.HardwareCategory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Category.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Category. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a category name. | everyone |
| IsDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value containing a information if entity is disabled. | everyone |
| CategoryOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value describing order of categories. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareCategoryStatusBase](./../Orion.HardwareHealth/HardwareCategoryStatusBase) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusBaseReferenceHardwareCategory (System.Reference) |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseReferenceHardwareCategory (System.Reference) |
| HardwareHierarchy | [Orion.HardwareHealth.HardwareHierarchy](./../Orion.HardwareHealth/HardwareHierarchy) | Defined by relationship Orion.HardwareHealth.HardwareHierarchysReferenceHardwareCategory (System.Reference) |


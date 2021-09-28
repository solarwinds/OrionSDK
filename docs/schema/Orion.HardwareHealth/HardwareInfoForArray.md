---
id: HardwareInfoForArray
slug: HardwareInfoForArray
---

# Orion.HardwareHealth.HardwareInfoForArray

SolarWinds Information Service 2020.2 Schema Documentation Index

HardwareInfo entity for Storage arrays

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareInfoBase](./../Orion.HardwareHealth/HardwareInfoBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategoryStatuses | [Orion.HardwareHealth.HardwareCategoryStatusForArray](./../Orion.HardwareHealth/HardwareCategoryStatusForArray) | Defined by relationship Orion.HardwareHealth.HardwareInfoForArrayHostsHardwareCategoryStatusForArray (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageArray | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.HardwareHealth.StorageArrayHostsHardwareInfoForArray (System.Hosting) |


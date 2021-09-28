---
id: HardwareCategoryStatusForChassis
slug: HardwareCategoryStatusForChassis
---

# Orion.HardwareHealth.HardwareCategoryStatusForChassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareCategoryStatusBase](./../Orion.HardwareHealth/HardwareCategoryStatusBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ChassisID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItemsForChassis | [Orion.HardwareHealth.HardwareItemForChassis](./../Orion.HardwareHealth/HardwareItemForChassis) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusForChassisHostsHardwareItemForChassis (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareInfo | [Orion.HardwareHealth.HardwareInfoForChassis](./../Orion.HardwareHealth/HardwareInfoForChassis) | Defined by relationship Orion.HardwareHealth.HardwareInfoForChassisReferencesHardwareCategoryStatusForChassis (System.Reliance) |
| Chassis | [Orion.HardwareHealth.BMC.Chassis](./../Orion.HardwareHealth.BMC/Chassis) | Defined by relationship Orion.HardwareHealth.ChassisReferenceHardwareCategoryStatusForChassis (System.Reference) |


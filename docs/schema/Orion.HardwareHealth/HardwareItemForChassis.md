---
id: HardwareItemForChassis
slug: HardwareItemForChassis
---

# Orion.HardwareHealth.HardwareItemForChassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ChassisID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareInfoForChassis | [Orion.HardwareHealth.HardwareInfoForChassis](./../Orion.HardwareHealth/HardwareInfoForChassis) | Defined by relationship Orion.HardwareHealth.HardwareItemForChassisReferencesHardwareInfoForChassis (System.Reference) |
| Chassis | [Orion.HardwareHealth.BMC.Chassis](./../Orion.HardwareHealth.BMC/Chassis) | Defined by relationship Orion.HardwareHealth.ChassisHostsHardwareItemForChassis (System.Hosting) |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareCategoryStatusForChassis](./../Orion.HardwareHealth/HardwareCategoryStatusForChassis) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusForChassisHostsHardwareItemForChassis (System.Reference) |


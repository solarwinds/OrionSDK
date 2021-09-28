---
id: HardwareInfoForChassis
slug: HardwareInfoForChassis
---

# Orion.HardwareHealth.HardwareInfoForChassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareInfoBase](./../Orion.HardwareHealth/HardwareInfoBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ChassisID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIconUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ParentObjectVendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItemForChassis | [Orion.HardwareHealth.HardwareItemForChassis](./../Orion.HardwareHealth/HardwareItemForChassis) | Defined by relationship Orion.HardwareHealth.HardwareItemForChassisReferencesHardwareInfoForChassis (System.Reference) |
| HardwareCategoryStatuses | [Orion.HardwareHealth.HardwareCategoryStatusForChassis](./../Orion.HardwareHealth/HardwareCategoryStatusForChassis) | Defined by relationship Orion.HardwareHealth.HardwareInfoForChassisReferencesHardwareCategoryStatusForChassis (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Chassis | [Orion.HardwareHealth.BMC.Chassis](./../Orion.HardwareHealth.BMC/Chassis) | Defined by relationship Orion.HardwareHealth.ChassisHostsHardwareInfoForChassis (System.Hosting) |


---
id: Chassis
slug: Chassis
---

# Orion.HardwareHealth.BMC.Chassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ParentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ControllerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DistinguishedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OriginalStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareInfoForChassis | [Orion.HardwareHealth.HardwareInfoForChassis](./../Orion.HardwareHealth/HardwareInfoForChassis) | Defined by relationship Orion.HardwareHealth.ChassisHostsHardwareInfoForChassis (System.Hosting) |
| HardwareItemForChassis | [Orion.HardwareHealth.HardwareItemForChassis](./../Orion.HardwareHealth/HardwareItemForChassis) | Defined by relationship Orion.HardwareHealth.ChassisHostsHardwareItemForChassis (System.Hosting) |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareCategoryStatusForChassis](./../Orion.HardwareHealth/HardwareCategoryStatusForChassis) | Defined by relationship Orion.HardwareHealth.ChassisReferenceHardwareCategoryStatusForChassis (System.Reference) |
| PSUs | [Orion.HardwareHealth.BMC.PSUsOnChassis](./../Orion.HardwareHealth.BMC/PSUsOnChassis) | Defined by relationship Orion.HardwareHealth.BMC.ChassisHostsPSUs (System.Hosting) |
| Fans | [Orion.HardwareHealth.BMC.FansOnChassis](./../Orion.HardwareHealth.BMC/FansOnChassis) | Defined by relationship Orion.HardwareHealth.BMC.ChassisHostsFans (System.Hosting) |
| Controller | [Orion.HardwareHealth.BMC.Controllers](./../Orion.HardwareHealth.BMC/Controllers) | Defined by relationship Orion.HardwareHealth.BMC.ChassisReferencesController (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Blades | [Orion.HardwareHealth.BMC.Blades](./../Orion.HardwareHealth.BMC/Blades) | Defined by relationship Orion.HardwareHealth.BMC.BladesReferenceChassis (System.Reference) |


---
id: VirtualMachineVolumes
slug: VirtualMachineVolumes
---

# Orion.VIM.VirtualMachineVolumes

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Machine Volume

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine ID | everyone |
| MountPoint | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Mount Point | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Capacity | everyone |
| FreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Free Space | everyone |
| SpaceUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Space Utilization | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualVolumesMappingReference (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualVolumesMappingReference (System.Reference) |


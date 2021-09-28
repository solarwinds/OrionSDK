---
id: VirtualMachineMediaDevices
slug: VirtualMachineMediaDevices
---

# Orion.VIM.VirtualMachineMediaDevices

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Media Device

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Connected | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Connected | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualMediaDeviceMappingReference (System.Hosting) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualMediaDeviceMappingReference (System.Hosting) |


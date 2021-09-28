---
id: VirtualMachineIPAddresses
slug: VirtualMachineIPAddresses
---

# Orion.VIM.VirtualMachineIPAddresses

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Machine IP Addresses

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Version | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesToIPAddressesMappingReference (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesToIPAddressesMappingReference (System.Reference) |


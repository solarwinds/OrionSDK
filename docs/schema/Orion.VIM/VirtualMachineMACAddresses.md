---
id: VirtualMachineMACAddresses
slug: VirtualMachineMACAddresses
---

# Orion.VIM.VirtualMachineMACAddresses

SolarWinds Information Service 2020.2 Schema Documentation Index

MAC Addresses of Virtual Machine

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine ID | everyone |
| MACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | MAC Address | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesToMACAddressesHosting (System.Hosting) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesToMACAddressesHosting (System.Hosting) |


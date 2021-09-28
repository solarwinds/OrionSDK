---
id: VirtualMachinesCustomProperties
slug: VirtualMachinesCustomProperties
---

# Orion.VIM.VirtualMachinesCustomProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

Custom Properties

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.CustomPropertiesEntity](./../System/CustomPropertiesEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesHostCustomProperties (System.Hosting) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachinesHostCustomProperties (System.Hosting) |

## Verbs

### CreateCustomProperty

#### Access control

everyone

### CreateCustomPropertyWithValues

#### Access control

everyone

### ModifyCustomProperty

#### Access control

everyone

### DeleteCustomProperty

#### Access control

everyone


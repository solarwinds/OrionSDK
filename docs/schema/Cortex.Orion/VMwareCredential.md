---
id: VMwareCredential
slug: VMwareCredential
---

# Cortex.Orion.VMwareCredential

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

↳ [Cortex.Orion.Credential](./../Cortex.Orion/Credential)

↳ [Cortex.Orion.UsernamePasswordCredential](./../Cortex.Orion/UsernamePasswordCredential)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Host | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.HostToVMwareCredential (System.Reference) |
| VCenter | [Cortex.Orion.Virtualization.VCenter](./../Cortex.Orion.Virtualization/VCenter) | Defined by relationship Cortex.Orion.Virtualization.VCenterToVMwareCredential (System.Reference) |


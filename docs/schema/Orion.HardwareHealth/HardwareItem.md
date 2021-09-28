---
id: HardwareItem
slug: HardwareItem
---

# Orion.HardwareHealth.HardwareItem

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Item For Nodes.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WebUri | [Orion.HardwareHealth.HardwareItemWebUri](./../Orion.HardwareHealth/HardwareItemWebUri) | Defined by relationship Orion.HardwareHealth.HardwareItemHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareCategoryStatus](./../Orion.HardwareHealth/HardwareCategoryStatus) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusHostsHardwareItem (System.Hosting) |
| HardwareInfo | [Orion.HardwareHealth.HardwareInfo](./../Orion.HardwareHealth/HardwareInfo) | Defined by relationship Orion.HardwareHealth.HardwareItemReferencesHardwareInfo (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.HardwareHealth.NodeReferencesHardwareItem (System.Reference) |


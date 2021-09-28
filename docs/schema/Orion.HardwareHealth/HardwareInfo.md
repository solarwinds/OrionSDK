---
id: HardwareInfo
slug: HardwareInfo
---

# Orion.HardwareHealth.HardwareInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Info For Nodes.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareInfoBase](./../Orion.HardwareHealth/HardwareInfoBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategoryStatuses | [Orion.HardwareHealth.HardwareCategoryStatus](./../Orion.HardwareHealth/HardwareCategoryStatus) | Defined by relationship Orion.HardwareHealth.HardwareInfoReferencesHardwareCategoryStatus (System.Hosting) |
| HardwareItem | [Orion.HardwareHealth.HardwareItem](./../Orion.HardwareHealth/HardwareItem) | Defined by relationship Orion.HardwareHealth.HardwareItemReferencesHardwareInfo (System.Reference) |
| WebUri | [Orion.HardwareHealth.HardwareInfoWebUri](./../Orion.HardwareHealth/HardwareInfoWebUri) | Defined by relationship Orion.HardwareHealth.HardwareInfoHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.HardwareHealth.NodeHostsHardwareInfo (System.Hosting) |


---
id: HardwareCategoryStatus
slug: HardwareCategoryStatus
---

# Orion.HardwareHealth.HardwareCategoryStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Category Status For Nodes.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.HardwareCategoryStatusBase](./../Orion.HardwareHealth/HardwareCategoryStatusBase)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItems | [Orion.HardwareHealth.HardwareItem](./../Orion.HardwareHealth/HardwareItem) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusHostsHardwareItem (System.Hosting) |
| WebUri | [Orion.HardwareHealth.HardwareCategoryStatusWebUri](./../Orion.HardwareHealth/HardwareCategoryStatusWebUri) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareInfo | [Orion.HardwareHealth.HardwareInfo](./../Orion.HardwareHealth/HardwareInfo) | Defined by relationship Orion.HardwareHealth.HardwareInfoReferencesHardwareCategoryStatus (System.Hosting) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.HardwareHealth.NodeReferenceHardwareCategoryStatus (System.Reference) |


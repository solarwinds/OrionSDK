---
id: NodesCustomProperties
slug: NodesCustomProperties
---

# IPAM.NodesCustomProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.CustomPropertiesEntity](./../System/CustomPropertiesEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IPNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPNodeWithHistory | [IPAM.IPNodeWithHistory](./../IPAM/IPNodeWithHistory) | Defined by relationship IPAM.IPNodeWithHistoryHostsNodesCustomProperties (System.Reference) |
| Node | [IPAM.IPNodeDisplayCustomProperties](./../IPAM/IPNodeDisplayCustomProperties) | Defined by relationship IPAM.NodesHostCustomProperties (System.Hosting) |
| IPNode | [IPAM.IPNode](./../IPAM/IPNode) | Defined by relationship IPAM.IPNodeReferenceCustomProperties (System.Reference) |
| IPNodeGrid | [IPAM.IPNodeGrid](./../IPAM/IPNodeGrid) | Defined by relationship IPAM.IpNodeGridRefCustomProperties (System.Reference) |

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


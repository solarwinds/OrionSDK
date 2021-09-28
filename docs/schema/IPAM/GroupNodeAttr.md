---
id: GroupNodeAttr
slug: GroupNodeAttr
---

# IPAM.GroupNodeAttr

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GroupId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNode | [IPAM.GroupReport](./../IPAM/GroupReport) | Defined by relationship IPAM.GroupNodeAttrGroupReport (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNode | [IPAM.GroupNode](./../IPAM/GroupNode) | Defined by relationship IPAM.GroupNodeHostsGroupNodeAttr (System.Hosting) |


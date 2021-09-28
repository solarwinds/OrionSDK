---
id: GroupsCustomProperties
slug: GroupsCustomProperties
---

# IPAM.GroupsCustomProperties

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
| GroupId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ManageSubnetsAndIps | [IPAM.ManageSubnetsAndIps](./../IPAM/ManageSubnetsAndIps) | Defined by relationship IPAM.ManageSubnetsAndIpsCustomProperties (System.Reference) |
| GroupNode | [IPAM.GroupReport](./../IPAM/GroupReport) | Defined by relationship IPAM.GroupsCustomPropertiesGroupReport (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DHCPView | [IPAM.DHCPView](./../IPAM/DHCPView) | Defined by relationship IPAM.DHCPViewRefCustomProperties (System.Reference) |
| Group | [IPAM.GroupNodeDisplayCustomProperties](./../IPAM/GroupNodeDisplayCustomProperties) | Defined by relationship IPAM.GroupsHostCustomProperties (System.Hosting) |
| GroupNode | [IPAM.GroupNode](./../IPAM/GroupNode) | Defined by relationship IPAM.GroupNodeRefCustomProperties (System.Reference) |

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


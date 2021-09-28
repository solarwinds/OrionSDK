---
id: CustomPollerAssignmentOnNode
slug: CustomPollerAssignmentOnNode
---

# Orion.NPM.CustomPollerAssignmentOnNode

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.NPM.CustomPollerAssignment](./../Orion.NPM/CustomPollerAssignment)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CustomPollerAssignmentID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CustomPollerStatus | [Orion.NPM.CustomPollerStatusOnNode](./../Orion.NPM/CustomPollerStatusOnNode) | Defined by relationship Orion.CustomPollerAssignmentOnNodeHostsCustomPollerStatusOnNode (System.Hosting) |
| CustomPollerStatusScalar | [Orion.NPM.CustomPollerStatusOnNodeScalar](./../Orion.NPM/CustomPollerStatusOnNodeScalar) | Defined by relationship Orion.CustomPollerAssignmentOnNodeHostsCustomPollerStatusOnNodeScalar (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsCustomPollerAssignmentOnNode (System.Hosting) |
| CustomPoller | [Orion.NPM.NodeCustomPollers](./../Orion.NPM/NodeCustomPollers) | Defined by relationship Orion.NodeCustomPollerReferencesCustomPollerAssignmentOnNode (System.Reference) |


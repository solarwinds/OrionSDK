---
id: Nodes
slug: Nodes
---

# Orion.OLM.Nodes

SolarWinds Information Service 2020.2 Schema Documentation Index

Orion nodes licensed for gathering messages and events. If there is more message sources with the same NodeID, they still count as one Orion node.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Orion node. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number defining license status of the message source. | everyone |
| LicenseStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of license status. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.OLMNodesOrionNodes (System.Reference) |


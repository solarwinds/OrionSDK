---
id: NodeToNodeLink
slug: NodeToNodeLink
---

# Orion.APM.NodeToNodeLink

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChildNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Latency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LatencyStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLossStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LatencyStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PacketLossStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DependencyTcpStatistics | [Orion.APM.DependencyTcpStatistics](./../Orion.APM/DependencyTcpStatistics) | Defined by relationship Orion.APM.NodeToNodeLinkHostsDependencyTcpStatistics (System.Hosting) |
| LatencyThreshold | [Orion.APM.NodeToNodeLinkLatencyThreshold](./../Orion.APM/NodeToNodeLinkLatencyThreshold) | Defined by relationship Orion.APM.NodeToNodeLinkHostsNodeToNodeLinkLatencyThreshold (System.Hosting) |
| PacketLossThreshold | [Orion.APM.NodeToNodeLinkPacketLossThreshold](./../Orion.APM/NodeToNodeLinkPacketLossThreshold) | Defined by relationship Orion.APM.NodeToNodeLinkHostsNodeToNodeLinkPacketLossThreshold (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ChildNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.NodeToNodeLinkReferencesChildNode (System.Reference) |
| ParentNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.NodeToNodeLinkReferencesParentNode (System.Reference) |


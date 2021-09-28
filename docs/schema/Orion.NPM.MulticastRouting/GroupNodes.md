---
id: GroupNodes
slug: GroupNodes
---

# Orion.NPM.MulticastRouting.GroupNodes

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastGroupNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MulticastGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusReason | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupNodeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePPS | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SourceBPS | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MulticastRoutingTables | [Orion.NPM.MulticastRouting.RoutingTable](./../Orion.NPM.MulticastRouting/RoutingTable) | Defined by relationship Orion.NPM.MulticastRouting.GroupNodesHostsRoutingTable (System.Hosting) |
| MulticastRoutingTablesReport | [Orion.NPM.MulticastRouting.MulticastRoutingTableReport](./../Orion.NPM.MulticastRouting/MulticastRoutingTableReport) | Defined by relationship Orion.NPM.MulticastRouting.GroupNodesHostsMulticastRoutingTableReport (System.Hosting) |
| RendezvousPoint | [Orion.NPM.MulticastRouting.RendezvousPoints](./../Orion.NPM.MulticastRouting/RendezvousPoints) | Defined by relationship Orion.NPM.MulticastRouting.GroupNodesReferencesRendezvousPoints (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NPM.MulticastRouting.NodesHostsGroupNodes (System.Hosting) |
| MulticastGroup | [Orion.NPM.MulticastRouting.Groups](./../Orion.NPM.MulticastRouting/Groups) | Defined by relationship Orion.NPM.MulticastRouting.GroupReferencesGroupNodes (System.Reference) |


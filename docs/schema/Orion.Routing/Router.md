---
id: Router
slug: Router
---

# Orion.Routing.Router

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RoutingTable | [Orion.Routing.RoutingTable](./../Orion.Routing/RoutingTable) | Defined by relationship Orion.Routing.RouterHostsRoutingTable (System.Reference) |
| RoutingDetails | [Orion.Routing.RoutingDetails](./../Orion.Routing/RoutingDetails) | Defined by relationship Orion.RouterHostsRoutingDetails (System.Hosting) |
| Neighbors | [Orion.Routing.Neighbors](./../Orion.Routing/Neighbors) | Defined by relationship Orion.RouterHostsNeighbors (System.Hosting) |
| RoutingTableFlap | [Orion.Routing.RoutingTableFlap](./../Orion.Routing/RoutingTableFlap) | Defined by relationship Orion.RouterHostsRoutingTableFlap (System.Hosting) |
| DefaultRouteChange | [Orion.Routing.DefaultRouteChange](./../Orion.Routing/DefaultRouteChange) | Defined by relationship Orion.RouterHostsDefaultRouteChange (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsRouter (System.Hosting) |


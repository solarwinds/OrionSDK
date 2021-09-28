---
id: VRF
slug: VRF
---

# Orion.Routing.VRF

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VrfIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RouteDistinguisher | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CompleteValues | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interfaces | [Orion.Routing.VRFInterface](./../Orion.Routing/VRFInterface) | Defined by relationship Orion.VRFHostsVRFInterfaces (System.Hosting) |
| RoutingTable | [Orion.Routing.RoutingTable](./../Orion.Routing/RoutingTable) | Defined by relationship Orion.VRFHostsRoutingTable (System.Hosting) |
| DefaultRouteChange | [Orion.Routing.DefaultRouteChange](./../Orion.Routing/DefaultRouteChange) | Defined by relationship Orion.VRFReferencesRoutingDefaultRouteChange (System.Reference) |
| RoutingTableFlap | [Orion.Routing.RoutingTableFlap](./../Orion.Routing/RoutingTableFlap) | Defined by relationship Orion.VRFReferencesRoutingTableFlap (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsVRFs (System.Hosting) |


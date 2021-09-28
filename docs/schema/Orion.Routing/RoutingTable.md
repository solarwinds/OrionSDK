---
id: RoutingTable
slug: RoutingTable
---

# Orion.Routing.RoutingTable

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RouteID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| LastChange | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RouteDestination | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RouteDestinationGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| RouteNextHop | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RouteNextHopGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| RouteMaskLen | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProtocolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Metric | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Ip_Address_Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IP_Version | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ProtocolName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VrfIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Router | [Orion.Routing.Router](./../Orion.Routing/Router) | Defined by relationship Orion.Routing.RouterHostsRoutingTable (System.Reference) |
| VRF | [Orion.Routing.VRF](./../Orion.Routing/VRF) | Defined by relationship Orion.VRFHostsRoutingTable (System.Hosting) |


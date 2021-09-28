---
id: RoutingTableFlap
slug: RoutingTableFlap
---

# Orion.Routing.RoutingTableFlap

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FlapId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RouteDestinationGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| RouteDestination | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CIDR | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Ip_Address_Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Ip_Version | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| RouteNextHop | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VrfIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Router | [Orion.Routing.Router](./../Orion.Routing/Router) | Defined by relationship Orion.RouterHostsRoutingTableFlap (System.Hosting) |
| VRF | [Orion.Routing.VRF](./../Orion.Routing/VRF) | Defined by relationship Orion.VRFReferencesRoutingTableFlap (System.Reference) |


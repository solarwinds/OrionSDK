---
id: VoipGatewayEndpoints
slug: VoipGatewayEndpoints
---

# Orion.IpSla.VoipGatewayEndpoints

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VoipGatewayEndpointID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VoipGatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IfName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EndPointType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IfIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WebUri | [Orion.IpSla.VoipGatewayEndpointWebUri](./../Orion.IpSla/VoipGatewayEndpointWebUri) | Defined by relationship Orion.IpSla.VoipGatewayEndpointsHostsWebUri (System.Hosting) |
| VoipGatewayEndpointStats | [Orion.IpSla.VoipGatewayEndpointStats](./../Orion.IpSla/VoipGatewayEndpointStats) | Defined by relationship Orion.Ipsla.VoipGatewayEndpointsHostsVoipGatewayEndpointStats (System.Hosting) |
| VoipGatewayEndpointCurrentStats | [Orion.IpSla.VoipGatewayEndpointCurrentStats](./../Orion.IpSla/VoipGatewayEndpointCurrentStats) | Defined by relationship Orion.Ipsla.VoipGatewayEndpointsHostsVoipGatewayEndpointCurrentStats (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VoipGateways | [Orion.IpSla.VoipGateways](./../Orion.IpSla/VoipGateways) | Defined by relationship Orion.Ipsla.VoipGatewayHostsVoipGatewayEndpoints (System.Hosting) |


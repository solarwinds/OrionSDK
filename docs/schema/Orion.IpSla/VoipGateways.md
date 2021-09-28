---
id: VoipGateways
slug: VoipGateways
---

# Orion.IpSla.VoipGateways

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VoipGatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastResultRecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| StatusName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxConcurrentSipCalls | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkMonitoringEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WebUri | [Orion.IpSla.VoipGatewayWebUri](./../Orion.IpSla/VoipGatewayWebUri) | Defined by relationship Orion.IpSla.VoipGatewayHostsWebUri (System.Hosting) |
| VoipGatewaySipTrunk | [Orion.IpSla.VoipGatewaySipTrunks](./../Orion.IpSla/VoipGatewaySipTrunks) | Defined by relationship Orion.VoipGatewaysHostsVoipGatewaySipTrunks (System.Hosting) |
| VoipGatewaySipStats | [Orion.IpSla.VoipGatewaySipStats](./../Orion.IpSla/VoipGatewaySipStats) | Defined by relationship Orion.IpSla.VoipGatewayHostsSipStats (System.Hosting) |
| PRIGatewayUtilization | [Orion.IpSla.PRIGatewayUtilization](./../Orion.IpSla/PRIGatewayUtilization) | Defined by relationship Orion.Ipsla.VoipGatewaysHostsPRIGatewayUtilization (System.Hosting) |
| VoipGatewaysEndpoints | [Orion.IpSla.VoipGatewayEndpoints](./../Orion.IpSla/VoipGatewayEndpoints) | Defined by relationship Orion.Ipsla.VoipGatewayHostsVoipGatewayEndpoints (System.Hosting) |
| VoipGatewayDetailStats | [Orion.IpSla.VoipGatewayDetailStats](./../Orion.IpSla/VoipGatewayDetailStats) | Defined by relationship Orion.Ipsla.VoipGatewayHostsVoipGatewayDetailStats (System.Hosting) |
| VoipGatewayDetailCurrentStats | [Orion.IpSla.VoipGatewayDetailCurrentStats](./../Orion.IpSla/VoipGatewayDetailCurrentStats) | Defined by relationship Orion.Ipsla.VoipGatewayDetailCurrentStats (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsVoipGateways (System.Hosting) |


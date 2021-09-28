---
id: VoipGatewaySipTrunks
slug: VoipGatewaySipTrunks
---

# Orion.IpSla.VoipGatewaySipTrunks

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SipTrunkID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VoipGatewayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DialPeer | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RecordTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VoipGatewaySipTrunkStatusStats | [Orion.IpSla.VoipGatewaySipTrunkStatusStats](./../Orion.IpSla/VoipGatewaySipTrunkStatusStats) | Defined by relationship Orion.IpSla.VoipGatewaySipTrunkHostsVoipGatewaySipTrunkStatusStats (System.Hosting) |
| VoipGatewaySipTrunkCallActivity | [Orion.IpSla.VoipGatewaySipTrunkCallActivity](./../Orion.IpSla/VoipGatewaySipTrunkCallActivity) | Defined by relationship Orion.IpSla.VoipGatewaySipTrunkHostsSipTrunkCallActivity (System.Hosting) |
| VoipGatewaySipTrunkUtilization | [Orion.IpSla.VoipGatewaySipTrunkUtilization](./../Orion.IpSla/VoipGatewaySipTrunkUtilization) | Defined by relationship Orion.IpSla.VoipGatewaySipTrunkHostsSipTrunkUtilization (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VoipGateway | [Orion.IpSla.VoipGateways](./../Orion.IpSla/VoipGateways) | Defined by relationship Orion.VoipGatewaysHostsVoipGatewaySipTrunks (System.Hosting) |


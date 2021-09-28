---
id: CCMMonitoring
slug: CCMMonitoring
---

# Orion.IpSla.CCMMonitoring

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CCMMonitoringTypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Deleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CcmName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClusterName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClusterNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Version | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UtcOffsetMinutes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MonitoringEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollingFrequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkPollingFrequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkMonitoringEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Region | [Orion.IpSla.CCMRegions](./../Orion.IpSla/CCMRegions) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMRegions (System.Hosting) |
| CCMGateways | [Orion.IpSla.CCMGateways](./../Orion.IpSla/CCMGateways) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMGateways (System.Hosting) |
| WebUri | [Orion.IpSla.CCMMonitoringWebUri](./../Orion.IpSla/CCMMonitoringWebUri) | Defined by relationship Orion.IpSla.CCMMonitoringHostsWebUri (System.Hosting) |
| CCMSipTrunk | [Orion.IpSla.CCMSipTrunk](./../Orion.IpSla/CCMSipTrunk) | Defined by relationship Orion.CCMMonitoringHostsCCMSipTrunk (System.Hosting) |
| CCMPhones | [Orion.IpSla.CCMPhones](./../Orion.IpSla/CCMPhones) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsCCMPhones (System.Hosting) |
| CurrentStats | [Orion.IpSla.CallManagerCurrentStats](./../Orion.IpSla/CallManagerCurrentStats) | Defined by relationship Orion.IpSla.CCMMonitoringHostsCallManagerCurrentStats (System.Hosting) |
| Stats | [Orion.IpSla.CallManagerStats](./../Orion.IpSla/CallManagerStats) | Defined by relationship Orion.IpSla.CCMMonitoringHostsCallManagerStats (System.Hosting) |
| VoipSuccessFailedCalls | [Orion.IpSla.VoipSuccessFailedCalls](./../Orion.IpSla/VoipSuccessFailedCalls) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipSuccessFailedCalls (System.Hosting) |
| VoipCallLatencyMMA | [Orion.IpSla.VoipCallLatencyMMA](./../Orion.IpSla/VoipCallLatencyMMA) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallLatencyMMA (System.Hosting) |
| VoipCallPacketLossMMA | [Orion.IpSla.VoipCallPacketLossMMA](./../Orion.IpSla/VoipCallPacketLossMMA) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallPacketLossMMA (System.Hosting) |
| VoipCallJitterMMA | [Orion.IpSla.VoipCallJitterMMA](./../Orion.IpSla/VoipCallJitterMMA) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallJitterMMA (System.Hosting) |
| VoipCallMosMMA | [Orion.IpSla.VoipCallMosMMA](./../Orion.IpSla/VoipCallMosMMA) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallMosMMA (System.Hosting) |
| VoipCallDetails | [Orion.IpSla.VoipCallDetails](./../Orion.IpSla/VoipCallDetails) | Defined by relationship Orion.Ipsla.CCMMonitoringHostsVoipCallDetails (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsCCMMonitoring (System.Hosting) |
| MonitoringType | [Orion.IpSla.CCMMonitoringType](./../Orion.IpSla/CCMMonitoringType) | Defined by relationship Orion.IpSla.CCMMonitoringReferencesCCMMonitoringType (System.Reference) |
| NPMinterfaces | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.Ipsla.CCMMonitoringReferencesInterfaces (System.Reference) |


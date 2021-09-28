---
id: CCMSipTrunk
slug: CCMSipTrunk
---

# Orion.IpSla.CCMSipTrunk

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SipTrunkId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VoipCCMMonitoringId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MTPOrigCodec | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DefaultDtmfCapability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DevicePool | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SipProfile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SecurityProfile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RecordTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMSipTrunkAvailability | [Orion.IpSla.CCMSipTrunkAvailability](./../Orion.IpSla/CCMSipTrunkAvailability) | Defined by relationship Orion.IpSla.CCMSipTrunkHostsCCMSipTrunkAvailability (System.Hosting) |
| CCMSipTrunkCurrentCallActivity | [Orion.IpSla.CCMSipTrunkCurrentCallActivity](./../Orion.IpSla/CCMSipTrunkCurrentCallActivity) | Defined by relationship Orion.IpSla.CCMSipTrunkHostsCCMSipTrunkCurrentCallActivity (System.Hosting) |
| CCMSipTrunkCallActivity | [Orion.IpSla.CCMSipTrunkCallActivity](./../Orion.IpSla/CCMSipTrunkCallActivity) | Defined by relationship Orion.IpSla.CCMSipTrunkHostsCCMSipTrunkCallActivity (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.CCMMonitoringHostsCCMSipTrunk (System.Hosting) |


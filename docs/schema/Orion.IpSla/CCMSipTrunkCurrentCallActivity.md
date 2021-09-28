---
id: CCMSipTrunkCurrentCallActivity
slug: CCMSipTrunkCurrentCallActivity
---

# Orion.IpSla.CCMSipTrunkCurrentCallActivity

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SipTrunkId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipTrunkName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VoipCCMMonitoringName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastPollRecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CallsActive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallsAttempted | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallsCompleted | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CallsInProgress | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VCallsActive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VCallsCompleted | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CCMSipTrunk | [Orion.IpSla.CCMSipTrunk](./../Orion.IpSla/CCMSipTrunk) | Defined by relationship Orion.IpSla.CCMSipTrunkHostsCCMSipTrunkCurrentCallActivity (System.Hosting) |


---
id: PoolMember
slug: PoolMember
---

# Orion.F5.LTM.PoolMember

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| update | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemberID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemberIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PoolIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| F5ServerIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5StatusReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| PPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Connections | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ConnectionsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RequestsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Sessions | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| F5StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnabledDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisableReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Monitors | [Orion.F5.LTM.Monitor](./../Orion.F5.LTM/Monitor) | Defined by relationship Orion.PoolMemberReferenceF5Monitor (System.Reference) |
| Stats | [Orion.F5.LTM.PoolMemberStats](./../Orion.F5.LTM/PoolMemberStats) | Defined by relationship Orion.F5.LTM.PoolMemberHostsPoolMemberStats (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Pool | [Orion.F5.LTM.Pool](./../Orion.F5.LTM/Pool) | Defined by relationship Orion.F5PoolReferencePoolMember (System.Reference) |
| F5Server | [Orion.F5.LTM.Server](./../Orion.F5.LTM/Server) | Defined by relationship Orion.F5ServerReferencePoolMember (System.Reference) |


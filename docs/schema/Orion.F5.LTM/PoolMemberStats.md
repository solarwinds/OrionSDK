---
id: PoolMemberStats
slug: PoolMemberStats
---

# Orion.F5.LTM.PoolMemberStats

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MemberID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Connections | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ConnectionsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RequestsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Sessions | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Availability | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Weight | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMember | [Orion.F5.LTM.PoolMember](./../Orion.F5.LTM/PoolMember) | Defined by relationship Orion.F5.LTM.PoolMemberHostsPoolMemberStats (System.Hosting) |


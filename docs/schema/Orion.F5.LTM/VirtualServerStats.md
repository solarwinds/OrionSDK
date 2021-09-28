---
id: VirtualServerStats
slug: VirtualServerStats
---

# Orion.F5.LTM.VirtualServerStats

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| VirtualServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Connections | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RequestsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Availability | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Weight | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualServer | [Orion.F5.LTM.VirtualServer](./../Orion.F5.LTM/VirtualServer) | Defined by relationship Orion.F5.LTM.VirtualServerHostsVirtualServerStats (System.Hosting) |


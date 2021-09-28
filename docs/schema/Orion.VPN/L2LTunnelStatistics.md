---
id: L2LTunnelStatistics
slug: L2LTunnelStatistics
---

# Orion.VPN.L2LTunnelStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TunnelID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InBitsPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutBitsPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Availability | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Weight | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Tunnel | [Orion.VPN.L2LTunnel](./../Orion.VPN/L2LTunnel) | Defined by relationship Orion.VPN.L2LTunnelStatistics (System.Hosting) |


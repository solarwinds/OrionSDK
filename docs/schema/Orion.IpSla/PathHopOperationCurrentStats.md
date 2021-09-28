---
id: PathHopOperationCurrentStats
slug: PathHopOperationCurrentStats
---

# Orion.IpSla.PathHopOperationCurrentStats

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| OperationInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| PathID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HopIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HopIpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HopIpAddressV4 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RoundTripTime | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Jitter | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Latency | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Operations | [Orion.IpSla.Operations](./../Orion.IpSla/Operations) | Defined by relationship Orion.IpSla.OperationsReferencesPathHopOperationCurrentStats (System.Hosting) |
| PathHop | [Orion.IpSla.PathHops](./../Orion.IpSla/PathHops) | Defined by relationship Orion.IpSla.PathHopsReferencesCurrentStats (System.Reference) |


---
id: OperationCurrentStats
slug: OperationCurrentStats
---

# Orion.IpSla.OperationCurrentStats

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
| OperationInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationResultID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RoundTripTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| JitterSD | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| JitterDS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Jitter | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Latency | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLossSD | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLossDS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MOS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| HttpRtt | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DnsRtt | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TcpConnectRtt | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TransactionRtt | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OneWayDelayDS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OneWayDelaySD | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Operation | [Orion.IpSla.Operations](./../Orion.IpSla/Operations) | Defined by relationship Orion.IpSla.OperationsHostsCurrentStats (System.Hosting) |


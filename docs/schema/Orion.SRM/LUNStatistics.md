---
id: LUNStatistics
slug: LUNStatistics
---

# Orion.SRM.LUNStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Stores LUNs statistics.
		
					Namely:
							IO
							IO Size
							IO Latency							
							IOPS							
							IOPS R/W Ratio
							Hit IO
							Bytes
							Cache Hit Ratio
							R/W Ratio
							Throughput
							Queue Length

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LUNID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOTotal | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IORead | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOWrite | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOOther | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSOther | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSReadWriteRatio | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesTotal | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BytesRead | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BytesWrite | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BytesPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyOther | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOSizeTotal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeRead | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeWrite | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HitIORead | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| HitIOWrite | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CacheHitRatio | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RatioRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RatioWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| QueueLength | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Weight | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LUN | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.SRM.LUNsReferencesLUNStatistics (System.Hosting) |


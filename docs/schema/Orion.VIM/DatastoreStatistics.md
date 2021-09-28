---
id: DatastoreStatistics
slug: DatastoreStatistics
---

# Orion.VIM.DatastoreStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Datastore Statistics History

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Datastore ID | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Time | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Used Space | everyone |
| FreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Free Space | everyone |
| ProvisionedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Provisioned Space | everyone |
| SpaceUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Space Utilization | everyone |
| MinIOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum IOPS Total | everyone |
| MaxIOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum IOPS Total | everyone |
| AvgIOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average IOPS Total | everyone |
| MinIOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum IOPS Read | everyone |
| MaxIOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum IOPS Read | everyone |
| AvgIOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average IOPS Read | everyone |
| MinIOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum IOPS Write | everyone |
| MaxIOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum IOPS Write | everyone |
| AvgIOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average IOPS Write | everyone |
| MinLatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Latency Total | everyone |
| MaxLatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Latency Total | everyone |
| AvgLatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Latency Total | everyone |
| MinLatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Latency Read | everyone |
| MaxLatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Latency Read | everyone |
| AvgLatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Latency Read | everyone |
| MinLatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Latency Write | everyone |
| MaxLatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Latency Write | everyone |
| AvgLatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Latency Write | everyone |
| MinThroughputTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Throughput Total | everyone |
| MaxThroughputTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Throughput Total | everyone |
| AvgThroughputTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Throughput Total | everyone |
| MinThroughputRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Throughput Read | everyone |
| MaxThroughputRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Throughput Read | everyone |
| AvgThroughputRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Throughput Read | everyone |
| MinThroughputWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Throughput Write | everyone |
| MaxThroughputWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Throughput Write | everyone |
| AvgThroughputWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Throughput Write | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataStore | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.DatastoresToDatastoreStatistics (System.Hosting) |
| DataStore | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.DatastoresToDatastoreStatistics (System.Hosting) |


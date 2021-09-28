---
id: VirtualDisksStatistics
slug: VirtualDisksStatistics
---

# Orion.VIM.VirtualDisksStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Disks Statistics History

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualDiskID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Disk ID | everyone |
| MinIOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum IOPS Total | everyone |
| MaxIOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum IOPS Total | everyone |
| AvgIOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average IOPS Total | everyone |
| MinIOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum IOPS Read | everyone |
| MaxIOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum IOPS Read | everyone |
| AvgIOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average IOPS Read | everyone |
| MinIOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum IOPS Write | everyone |
| MaxIOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum IOPS Write | everyone |
| AvgIOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average IOPS Write | everyone |
| MinLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Latency Total | everyone |
| MaxLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Latency Total | everyone |
| AvgLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Latency Total | everyone |
| MinLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Latency Read | everyone |
| MaxLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Latency Read | everyone |
| AvgLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Latency Read | everyone |
| MinLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Latency Write | everyone |
| MaxLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Latency Write | everyone |
| AvgLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Latency Write | everyone |
| MinThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Throughput Total | everyone |
| MaxThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Throughput Total | everyone |
| AvgThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Throughput Total | everyone |
| MinThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Throughput Read | everyone |
| MaxThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Throughput Read | everyone |
| AvgThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Throughput Read | everyone |
| MinThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Minimum Throughput Write | everyone |
| MaxThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Maximum Throughput Write | everyone |
| AvgThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average Throughput Write | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualDisk | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualDisksToVirtualDisksStatistics (System.Hosting) |
| VirtualDisk | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualDisksToVirtualDisksStatistics (System.Hosting) |


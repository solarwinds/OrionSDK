---
id: HostStatistics
slug: HostStatistics
---

# Orion.VIM.HostStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Host Statistics History

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| HostID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | VMHost ID | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Time | everyone |
| VmCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machines | everyone |
| VmRunningCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machines Running | everyone |
| MinNetworkUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Network Utilization | everyone |
| MaxNetworkUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Network Utilization | everyone |
| AvgNetworkUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Network Utilization | everyone |
| MinNetworkUsageRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Network Usage Rate | everyone |
| MaxNetworkUsageRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Network Usage Rate | everyone |
| AvgNetworkUsageRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Network Usage Rate | everyone |
| MinNetworkTransmitRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Network Transmit Rate | everyone |
| MaxNetworkTransmitRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Network Transmit Rate | everyone |
| AvgNetworkTransmitRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Network Transmit Rate | everyone |
| MinNetworkReceiveRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Network Receive Rate | everyone |
| MaxNetworkReceiveRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Network Receive Rate | everyone |
| AvgNetworkReceiveRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Network Receive Rate | everyone |
| MinCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemSwapIn | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemSwapIn | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemSwapIn | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemSwapOut | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemSwapOut | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemSwapOut | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemBallooning | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemBallooning | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemBallooning | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemPagesSwapRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemPagesSwapRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemPagesSwapRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemoryGranted | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemoryGranted | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemoryGranted | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostsHostStatistics (System.Hosting) |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostsHostStatistics (System.Hosting) |


---
id: ClusterStatistics
slug: ClusterStatistics
---

# Orion.VIM.ClusterStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Cluster Statistics History

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ClusterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Cluster ID | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Time | everyone |
| PercentAvailability | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Percent Availability | everyone |
| MinCPULoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum CPU Load | everyone |
| MaxCPULoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum CPU Load | everyone |
| AvgCPULoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average CPU Load | everyone |
| MinCPUUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Minimum CPU Usage | everyone |
| MaxCPUUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Maximum CPU Usage | everyone |
| AvgCPUUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Average CPU Usage | everyone |
| MinMemoryUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Minimum Percent Memory Usage | everyone |
| MaxMemoryUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Maximum Percent Memory Usage | everyone |
| AvgMemoryUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Average Percent Memory Usage | everyone |
| MinMemoryUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Minimum Memory Usage | everyone |
| MaxMemoryUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Maximum Memory Usage | everyone |
| AvgMemoryUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Average Memory Usage | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterClusterStatistics (System.Hosting) |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterClusterStatistics (System.Hosting) |


---
id: ResourceMetrics
slug: ResourceMetrics
---

# Cortex.Orion.Virtualization.Cluster.ResourceMetrics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MinCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgCpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinCpuUsageMhz | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxCpuUsageMhz | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AvgCpuUsageMhz | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MaxMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AvgMemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MinMemUsageMb | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxMemUsageMb | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AvgMemUsageMb | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Availability | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Cluster | [Cortex.Orion.Virtualization.Cluster](./../Cortex.Orion.Virtualization/Cluster) | Defined by relationship Cortex.Orion.Virtualization.ClusterToResourceMetrics (System.Hosting) |


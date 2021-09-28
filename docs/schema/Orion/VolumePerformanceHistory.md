---
id: VolumePerformanceHistory
slug: VolumePerformanceHistory
---

# Orion.VolumePerformanceHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AvgDiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinDiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxDiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgDiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinDiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxDiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgDiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinDiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxDiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgDiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinDiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxDiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.VolumePerformanceHistory (System.Hosting) |


---
id: Statistics
slug: Statistics
---

# Cortex.Orion.Volume.Statistics

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
| VolumeSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| VolumeSpaceUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Cortex.Orion.Volume](./../Cortex.Orion/Volume) | Defined by relationship Cortex.Orion.VolumeToStatistics (System.Hosting) |


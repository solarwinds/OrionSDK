---
id: VolumeCapacityStatistics
slug: VolumeCapacityStatistics
---

# Orion.SRM.VolumeCapacityStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Stores capacity statistics for all Volumes

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
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CapacityTotal | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacityAllocated | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacityFileSystem | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacityFree | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Weight | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.SRM.VolumesReferencesVolumeCapacityStatistics (System.Hosting) |


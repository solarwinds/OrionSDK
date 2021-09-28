---
id: VolumeStatistics
slug: VolumeStatistics
---

# Orion.Cloud.Aws.VolumeStatistics

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
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ReadLatencyInMilliseconds | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| WriteLatencyInMilliseconds | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReadOperationsPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| WriteOperationsPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| QueuedOperations | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IdleTimePercentage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputPercentage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ReadBandwidthInKibibytesPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| WriteBandwidthInKibibytesPerSecond | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| AverageReadOperationSizeInKibibytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AverageWriteOperationSizeInKibibytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ConsumedReadWriteOperationsPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Orion.Cloud.Aws.Volumes](./../Orion.Cloud.Aws/Volumes) | Defined by relationship Orion.Cloud.Aws.VolumesHostsVolumeStatistics (System.Hosting) |


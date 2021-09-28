---
id: Volumes
slug: Volumes
---

# Orion.Cloud.Aws.Volumes

SolarWinds Information Service 2020.2 Schema Documentation Index

Cloud volume from Amazon Elastic Compute Cloud Web Service.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.Cloud.Volumes](./../Orion.Cloud/Volumes)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ReadLatencyInMilliseconds | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Read latency in milliseconds. | everyone |
| WriteLatencyInMilliseconds | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Write latency in milliseconds. | everyone |
| ReadOperationsPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Read operations per second. | everyone |
| WriteOperationsPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Write operations per second. | everyone |
| QueuedOperations | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Number of queued operations. | everyone |
| IdleTimePercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Idle time percentage. | everyone |
| ThroughputPercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Throughput percentage. | everyone |
| ReadBandwidthInKibibytesPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Read bandwidth in kibibytes per second. | everyone |
| WriteBandwidthInKibibytesPerSecond | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Write bandwidth in kibibytes per second. | everyone |
| AverageReadOperationSizeInKibibytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average read operation size in kibibytes. | everyone |
| AverageWriteOperationSizeInKibibytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average write operation size in kibibytes. | everyone |
| ConsumedIOPS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Consumed input/output operations per second. | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Orion id prefix. | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Orion id column. | everyone |
| Description | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Cloud volume description. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details page url part. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VolumeStatus | [Orion.Cloud.Aws.VolumeStatus](./../Orion.Cloud.Aws/VolumeStatus) | Defined by relationship Orion.Cloud.Aws.VolumesVolumeStatus (System.Hosting) |
| Statistics | [Orion.Cloud.Aws.VolumeStatistics](./../Orion.Cloud.Aws/VolumeStatistics) | Defined by relationship Orion.Cloud.Aws.VolumesHostsVolumeStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudInstance | [Orion.Cloud.Aws.Instances](./../Orion.Cloud.Aws/Instances) | Defined by relationship Orion.Cloud.Aws.InstanceHostsVolumes (System.Hosting) |


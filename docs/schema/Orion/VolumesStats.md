---
id: VolumesStats
slug: VolumesStats
---

# Orion.VolumesStats

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PercentUsed | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SpaceUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| SpaceAvailable | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AllocationFailuresThisHour | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AllocationFailuresToday | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalDiskIOPS | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.VolumesHostsVolumesStats (System.Hosting) |


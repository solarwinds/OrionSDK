---
id: Volume
slug: Volume
---

# Cortex.Orion.Volume

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

↳ [Cortex.Orion.PartitionedInstance](./../Cortex.Orion/PartitionedInstance)

↳ [Cortex.Orion.MonitoringElement](./../Cortex.Orion/MonitoringElement)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VolumeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RawCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FullName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatCollection | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeType_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PollingType_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VolumeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeviceId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DiskSerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VolumeSize | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| VolumeSpaceUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskQueueLength | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskTransfer | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskReads | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DiskWrites | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalDiskIops | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RelatedNode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CapacityMetrics | [Cortex.Orion.Volume.CapacityMetrics](./../Cortex.Orion.Volume/CapacityMetrics) | Defined by relationship Cortex.Orion.VolumeToCapacityMetrics (System.Hosting) |
| PerformanceMetrics | [Cortex.Orion.Volume.PerformanceMetrics](./../Cortex.Orion.Volume/PerformanceMetrics) | Defined by relationship Cortex.Orion.VolumeToPerformanceMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Volume.Statistics](./../Cortex.Orion.Volume/Statistics) | Defined by relationship Cortex.Orion.VolumeToStatistics (System.Hosting) |
| SCSI | [Cortex.Orion.ScsiInformation](./../Cortex.Orion/ScsiInformation) | Defined by relationship Cortex.Orion.VolumeToScsiInformation (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.NodeToVolumes (System.Hosting) |

## Verbs

### Core.AddToCortex

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.AssignToEngine

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.GetSupportedMetrics

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.InventoryNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.PollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.SetPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.StartRealTimePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.StopRealTimePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


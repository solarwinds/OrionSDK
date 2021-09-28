---
id: Cluster
slug: Cluster
---

# Cortex.Orion.Virtualization.Cluster

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

↳ [Cortex.Orion.PartitionedInstance](./../Cortex.Orion/PartitionedInstance)

↳ [Cortex.Orion.MonitoringElement](./../Cortex.Orion/MonitoringElement)

↳ [Cortex.Orion.Virtualization.HypervisorEntity](./../Cortex.Orion.Virtualization/HypervisorEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DataCenterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CpuCoreCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CpuThreadCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TotalCpu | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VsanEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| VsanUuid | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PlatformId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ManagedStatusDetails | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgLatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgLatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgLatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinIopsRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxIopsRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgIopsRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinIopsWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxIopsWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgIopsWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinIopsTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxIopsTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgIopsTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
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
| RelatedDataCenter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageMetrics | [Cortex.Orion.Virtualization.Cluster.StorageMetrics](./../Cortex.Orion.Virtualization.Cluster/StorageMetrics) | Defined by relationship Cortex.Orion.Virtualization.ClusterToStorageMetrics (System.Hosting) |
| ResourceMetrics | [Cortex.Orion.Virtualization.Cluster.ResourceMetrics](./../Cortex.Orion.Virtualization.Cluster/ResourceMetrics) | Defined by relationship Cortex.Orion.Virtualization.ClusterToResourceMetrics (System.Hosting) |
| Datastores | [Cortex.Orion.Virtualization.Datastore](./../Cortex.Orion.Virtualization/Datastore) | Defined by relationship Cortex.Orion.Virtualization.ClustersToDatastores (System.Reference) |
| Hosts | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.ClusterToHosts (System.Reference) |
| StoragePools | [Cortex.Orion.Virtualization.StoragePool](./../Cortex.Orion.Virtualization/StoragePool) | Defined by relationship Cortex.Orion.Virtualization.ClusterToStoragePools (System.Hosting) |
| VSan | [Cortex.Orion.Virtualization.VSan](./../Cortex.Orion.Virtualization/VSan) | Defined by relationship Cortex.Orion.Virtualization.ClusterToVSan (System.Reference) |
| TriggeredAlarmStates | [Cortex.Orion.Virtualization.TriggeredAlarmState](./../Cortex.Orion.Virtualization/TriggeredAlarmState) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToCluster (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataCenter | [Cortex.Orion.Virtualization.DataCenter](./../Cortex.Orion.Virtualization/DataCenter) | Defined by relationship Cortex.Orion.Virtualization.DataCenterToClusters (System.Reference) |

## Verbs

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


---
id: VSan
slug: VSan
---

# Cortex.Orion.Virtualization.VSan

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
| VsanIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TotalCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| UsedSpacePercentage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| UsedByVms | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IsDedupEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DedupRatio | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DedupUsedSpaceBefore | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| DedupUsedSpaceAfter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Congestions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutstandingIO | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RelatedCluster | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedDatastore | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSanMetrics | [Cortex.Orion.Virtualization.VSan.VSanMetrics](./../Cortex.Orion.Virtualization.VSan/VSanMetrics) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Virtualization.VSan.Statistics](./../Cortex.Orion.Virtualization.VSan/Statistics) | Defined by relationship Cortex.Orion.Virtualization.VSanToStatistics (System.Hosting) |
| VSanDiskGroups | [Cortex.Orion.Virtualization.VSanDiskGroup](./../Cortex.Orion.Virtualization/VSanDiskGroup) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanDiskGroups (System.Hosting) |
| VSanHealthGroups | [Cortex.Orion.Virtualization.VSanHealthGroup](./../Cortex.Orion.Virtualization/VSanHealthGroup) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanHealthGroups (System.Hosting) |
| VSanObjectSpaceSummaries | [Cortex.Orion.Virtualization.VSanObjectSpaceSummary](./../Cortex.Orion.Virtualization/VSanObjectSpaceSummary) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanObjectSpaceSummaries (System.Hosting) |
| VSanResyncInfos | [Cortex.Orion.Virtualization.VSanResyncInfo](./../Cortex.Orion.Virtualization/VSanResyncInfo) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanResyncInfos (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionCluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Cortex.Orion.Virtualization.OrionClusterToVSan (System.Hosting) |
| Cluster | [Cortex.Orion.Virtualization.Cluster](./../Cortex.Orion.Virtualization/Cluster) | Defined by relationship Cortex.Orion.Virtualization.ClusterToVSan (System.Reference) |
| Datastore | [Cortex.Orion.Virtualization.Datastore](./../Cortex.Orion.Virtualization/Datastore) | Defined by relationship Cortex.Orion.Virtualization.DatastoreToVSan (System.Reference) |

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


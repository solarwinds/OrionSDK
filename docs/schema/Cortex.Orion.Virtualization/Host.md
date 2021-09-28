---
id: Host
slug: Host
---

# Cortex.Orion.Virtualization.Host

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
| HostId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DataCenterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SecondaryClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CredentialId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DnsHostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| BiosSerial | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VsanNodeUuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| PlatformId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ManagedStatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VmCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VmRunningCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InMaintenanceMode | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ProcessorType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CpuMhz | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CpuCoreCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CpuPkgCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemorySize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| NicCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetworkCapacityKbps | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
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
| AvgCongestions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutstandingIo | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
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
| MinNetworkUtilization | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxNetworkUtilization | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgNetworkUtilization | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinNetworkUsageRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxNetworkUsageRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgNetworkUsageRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinNetworkTransmitRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxNetworkTransmitRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgNetworkTransmitRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinNetworkReceiveRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxNetworkReceiveRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgNetworkReceiveRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RelatedCluster | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedDataCenter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedCredential | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageMetrics | [Cortex.Orion.Virtualization.Host.StorageMetrics](./../Cortex.Orion.Virtualization.Host/StorageMetrics) | Defined by relationship Cortex.Orion.Virtualization.HostToStorageMetrics (System.Hosting) |
| ResourceMetrics | [Cortex.Orion.Virtualization.Host.ResourceMetrics](./../Cortex.Orion.Virtualization.Host/ResourceMetrics) | Defined by relationship Cortex.Orion.Virtualization.HostToResourceMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Virtualization.Host.Statistics](./../Cortex.Orion.Virtualization.Host/Statistics) | Defined by relationship Cortex.Orion.Virtualization.HostToStatistics (System.Hosting) |
| Alarms | [Cortex.Orion.Virtualization.Alarm](./../Cortex.Orion.Virtualization/Alarm) | Defined by relationship Cortex.Orion.Virtualization.AlarmsToHost (System.Reference) |
| Datastores | [Cortex.Orion.Virtualization.Datastore](./../Cortex.Orion.Virtualization/Datastore) | Defined by relationship Cortex.Orion.Virtualization.HostsToDatastores (System.Reference) |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.Virtualization.HostToNode (System.Reference) |
| VirtualMachines | [Cortex.Orion.Virtualization.VirtualMachine](./../Cortex.Orion.Virtualization/VirtualMachine) | Defined by relationship Cortex.Orion.Virtualization.HostToVirtualMachines (System.Reference) |
| VSanDiskGroups | [Cortex.Orion.Virtualization.VSanDiskGroup](./../Cortex.Orion.Virtualization/VSanDiskGroup) | Defined by relationship Cortex.Orion.Virtualization.HostToVSanDiskGroups (System.Reference) |
| VSanResyncInfo | [Cortex.Orion.Virtualization.VSanResyncInfo](./../Cortex.Orion.Virtualization/VSanResyncInfo) | Defined by relationship Cortex.Orion.Virtualization.HostToVSanResyncInfo (System.Hosting) |
| TriggeredAlarmStates | [Cortex.Orion.Virtualization.TriggeredAlarmState](./../Cortex.Orion.Virtualization/TriggeredAlarmState) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToHost (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Cluster | [Cortex.Orion.Virtualization.Cluster](./../Cortex.Orion.Virtualization/Cluster) | Defined by relationship Cortex.Orion.Virtualization.ClusterToHosts (System.Reference) |
| DataCenter | [Cortex.Orion.Virtualization.DataCenter](./../Cortex.Orion.Virtualization/DataCenter) | Defined by relationship Cortex.Orion.Virtualization.DataCenterToHosts (System.Reference) |
| Credential | [Cortex.Orion.VMwareCredential](./../Cortex.Orion/VMwareCredential) | Defined by relationship Cortex.Orion.Virtualization.HostToVMwareCredential (System.Reference) |

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


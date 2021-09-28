---
id: Datastore
slug: Datastore
---

# Cortex.Orion.Virtualization.Datastore

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
| DatastoreIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PlatformId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Accessible | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ReservedCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacityFromAdvertised | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ClusterCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Local | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| FreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ProvisionedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| SpaceUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
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
| RelatedStoragePool | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ResourceMetrics | [Cortex.Orion.Virtualization.Datastore.ResourceMetrics](./../Cortex.Orion.Virtualization.Datastore/ResourceMetrics) | Defined by relationship Cortex.Orion.Virtualization.DatastoreToResourceMetrics (System.Hosting) |
| VirtualMachineDisks | [Cortex.Orion.Virtualization.VirtualMachineDisk](./../Cortex.Orion.Virtualization/VirtualMachineDisk) | Defined by relationship Cortex.Orion.Virtualization.DatastoreToVirtualMachineDisks (System.Reference) |
| VSan | [Cortex.Orion.Virtualization.VSan](./../Cortex.Orion.Virtualization/VSan) | Defined by relationship Cortex.Orion.Virtualization.DatastoreToVSan (System.Reference) |
| TriggeredAlarmStates | [Cortex.Orion.Virtualization.TriggeredAlarmState](./../Cortex.Orion.Virtualization/TriggeredAlarmState) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToDatastore (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Clusters | [Cortex.Orion.Virtualization.Cluster](./../Cortex.Orion.Virtualization/Cluster) | Defined by relationship Cortex.Orion.Virtualization.ClustersToDatastores (System.Reference) |
| Hosts | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.HostsToDatastores (System.Reference) |
| StoragePool | [Cortex.Orion.Virtualization.StoragePool](./../Cortex.Orion.Virtualization/StoragePool) | Defined by relationship Cortex.Orion.Virtualization.StoragePoolToDatastores (System.Reference) |
| VirtualMachines | [Cortex.Orion.Virtualization.VirtualMachine](./../Cortex.Orion.Virtualization/VirtualMachine) | Defined by relationship Cortex.Orion.Virtualization.VirtualMachinesToDatastores (System.Reference) |

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


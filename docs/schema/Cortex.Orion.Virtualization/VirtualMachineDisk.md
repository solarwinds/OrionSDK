---
id: VirtualMachineDisk
slug: VirtualMachineDisk
---

# Cortex.Orion.Virtualization.VirtualMachineDisk

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
| VirtualMachineDiskId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VirtualMachineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DataStoreId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ControllerBusNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DiskUnitNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RelatedDatastore | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedVirtualMachine | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSanMetrics | [Cortex.Orion.Virtualization.VirtualMachineDisk.VSanMetrics](./../Cortex.Orion.Virtualization.VirtualMachineDisk/VSanMetrics) | Defined by relationship Cortex.Orion.Virtualization.VirtualMachineDiskToVSanMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Virtualization.VirtualMachineDisk.Statistics](./../Cortex.Orion.Virtualization.VirtualMachineDisk/Statistics) | Defined by relationship Cortex.Orion.Virtualization.VirtualMachineDiskToStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Datastore | [Cortex.Orion.Virtualization.Datastore](./../Cortex.Orion.Virtualization/Datastore) | Defined by relationship Cortex.Orion.Virtualization.DatastoreToVirtualMachineDisks (System.Reference) |
| VirtualMachine | [Cortex.Orion.Virtualization.VirtualMachine](./../Cortex.Orion.Virtualization/VirtualMachine) | Defined by relationship Cortex.Orion.Virtualization.VirtualMachineToVirtualMachineDisks (System.Reference) |

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


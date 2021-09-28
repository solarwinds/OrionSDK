---
id: VirtualDisks
slug: VirtualDisks
---

# Orion.VIM.VirtualDisks

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Disk

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualDiskID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Disk ID | everyone |
| CortexID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine ID | everyone |
| VirtualMachineName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Virtual Machine Name | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Host Name | everyone |
| ClusterName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Cluster Name | everyone |
| DatacenterName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Datacenter Name | everyone |
| VCenterName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | VCenter Name | everyone |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Datastore ID | everyone |
| DataStoreName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Datastore Name | everyone |
| LunID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | LUN ID | everyone |
| LunName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | LUN Name | everyone |
| IsRawMapping | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Is Raw Mapping | everyone |
| FileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | File Name | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Label | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Capacity | everyone |
| ControllerBusNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Controller Bus Number | everyone |
| DiskUnitNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Disk Unit Number | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Serial Number | everyone |
| ThinProvisioned | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Thin Provisioned | everyone |
| ControllerGuestGuid | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Controller Guest Guid | everyone |
| IOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | IOPS Total | everyone |
| IOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | IOPS Read | everyone |
| IOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | IOPS Write | everyone |
| LatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Latency Total | everyone |
| LatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Latency Read | everyone |
| LatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Latency Write | everyone |
| ThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Throughput Total | everyone |
| ThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Throughput Read | everyone |
| ThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Throughput Write | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualDiskStatistics | [Orion.VIM.VirtualDisksStatistics](./../Orion.VIM/VirtualDisksStatistics) | Defined by relationship Orion.VIM.VirtualDisksToVirtualDisksStatistics (System.Hosting) |
| VirtualDiskVSanStatistics | [Cortex.Orion.Virtualization.VirtualMachineDisk.VSanMetrics](./../Cortex.Orion.Virtualization.VirtualMachineDisk/VSanMetrics) | Defined by relationship Orion.VIM.VirtualDiskToVirtualDiskVSanStatistics (System.Reference) |
| VirtualDiskVSanStatistics | [Cortex.Orion.Virtualization.VirtualMachineDisk.VSanMetrics](./../Cortex.Orion.Virtualization.VirtualMachineDisk/VSanMetrics) | Defined by relationship Orion.VIM.VirtualDiskToVirtualDiskVSanStatistics (System.Reference) |
| VirtualDiskStatistics | [Orion.VIM.VirtualDisksStatistics](./../Orion.VIM/VirtualDisksStatistics) | Defined by relationship Orion.VIM.VirtualDisksToVirtualDisksStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataStore | [Orion.VIM.DataStores](./../Orion.VIM/DataStores) | Defined by relationship Orion.VIM.DataStoreToVirtualDisksMappingReference (System.Reference) |
| Lun | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunToVirtualDisksMappingReference (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualDisksMappingReference (System.Reference) |
| DataStore | [Orion.VIM.DataStores](./../Orion.VIM/DataStores) | Defined by relationship Orion.VIM.DataStoreToVirtualDisksMappingReference (System.Reference) |
| Lun | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunToVirtualDisksMappingReference (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineToVirtualDisksMappingReference (System.Reference) |


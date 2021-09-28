---
id: Datastores
slug: Datastores
---

# Orion.VIM.Datastores

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Datastore

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Datastore ID | everyone |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DataStoreIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Datastore Identifier | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type | everyone |
| URL | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL | everyone |
| Accessible | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Accessible | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Managed Status | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Capacity | everyone |
| ReservedCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Reserved Capacity | everyone |
| CapacityFromAdvertised | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | True if Capacity taken from advertisedCapacity (advertisedCapactiy not null), False if taken from maxCapacity (advertisedCapactiy null) | everyone |
| FreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Free Space | everyone |
| ProvisionedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Provisioned Space | everyone |
| SpaceUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Space Utilization | everyone |
| ProvisionedSpaceAllocation | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Provisioned Space Allocation | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | IOPS Total | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | IOPS Read | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | IOPS Write | everyone |
| ThroughputTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Latency Total | everyone |
| LatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Latency Read | everyone |
| LatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Latency Write | everyone |
| DepletionDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Depletion Date | everyone |
| Platform | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Platform | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClusterCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Cluster Count | everyone |
| Local | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Local | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyLUNs | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.Rely.SRM.DatastoresRelyOnLUNs (System.Reliance) |
| RelyFileShares | [Orion.SRM.FileShares](./../Orion.SRM/FileShares) | Defined by relationship Orion.Rely.SRM.DatastoresRelyOnFileShares (System.Reliance) |
| Thresholds | [Orion.VIM.DatastoreThresholds](./../Orion.VIM/DatastoreThresholds) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreThresholds (System.Hosting) |
| IOPSTotalThreshold | [Orion.VIM.DatastoreIOPSTotalThreshold](./../Orion.VIM/DatastoreIOPSTotalThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.VIM.DatastoreIOPSReadThreshold](./../Orion.VIM/DatastoreIOPSReadThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.VIM.DatastoreIOPSWriteThreshold](./../Orion.VIM/DatastoreIOPSWriteThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSWriteThreshold (System.Hosting) |
| LatencyTotalThreshold | [Orion.VIM.DatastoreLatencyTotalThreshold](./../Orion.VIM/DatastoreLatencyTotalThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyTotalThreshold (System.Hosting) |
| LatencyReadThreshold | [Orion.VIM.DatastoreLatencyReadThreshold](./../Orion.VIM/DatastoreLatencyReadThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyReadThreshold (System.Hosting) |
| LatencyWriteThreshold | [Orion.VIM.DatastoreLatencyWriteThreshold](./../Orion.VIM/DatastoreLatencyWriteThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyWriteThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.DatastoresCustomProperties](./../Orion.VIM/DatastoresCustomProperties) | Defined by relationship Orion.VIM.DatastoresHostCustomProperties (System.Hosting) |
| DatastoreStatistics | [Orion.VIM.DatastoreStatistics](./../Orion.VIM/DatastoreStatistics) | Defined by relationship Orion.VIM.DatastoresToDatastoreStatistics (System.Hosting) |
| Thresholds | [Orion.VIM.DatastoreThresholds](./../Orion.VIM/DatastoreThresholds) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreThresholds (System.Hosting) |
| IOPSTotalThreshold | [Orion.VIM.DatastoreIOPSTotalThreshold](./../Orion.VIM/DatastoreIOPSTotalThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.VIM.DatastoreIOPSReadThreshold](./../Orion.VIM/DatastoreIOPSReadThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.VIM.DatastoreIOPSWriteThreshold](./../Orion.VIM/DatastoreIOPSWriteThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreIOPSWriteThreshold (System.Hosting) |
| LatencyTotalThreshold | [Orion.VIM.DatastoreLatencyTotalThreshold](./../Orion.VIM/DatastoreLatencyTotalThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyTotalThreshold (System.Hosting) |
| LatencyReadThreshold | [Orion.VIM.DatastoreLatencyReadThreshold](./../Orion.VIM/DatastoreLatencyReadThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyReadThreshold (System.Hosting) |
| LatencyWriteThreshold | [Orion.VIM.DatastoreLatencyWriteThreshold](./../Orion.VIM/DatastoreLatencyWriteThreshold) | Defined by relationship Orion.VIM.DatastoreHostsDatastoreLatencyWriteThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.DatastoresCustomProperties](./../Orion.VIM/DatastoresCustomProperties) | Defined by relationship Orion.VIM.DatastoresHostCustomProperties (System.Hosting) |
| DatastoreStatistics | [Orion.VIM.DatastoreStatistics](./../Orion.VIM/DatastoreStatistics) | Defined by relationship Orion.VIM.DatastoresToDatastoreStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LUNs | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.SRM.LUNsReferencesDatastores (System.Reference) |
| FileShares | [Orion.SRM.FileShares](./../Orion.SRM/FileShares) | Defined by relationship Orion.SRM.FileSharesReferencesDatastores (System.Reference) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterReferencesDatastore (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostReferencesDatastore (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineReferencesDatastore (System.Reference) |
| RelyVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.Rely.VIM.VolumesRelyOnDatastores (System.Reliance) |
| RelyVirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnDatastores (System.Reliance) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterReferencesDatastore (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostReferencesDatastore (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineReferencesDatastore (System.Reference) |
| RelyVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.Rely.VIM.VolumesRelyOnDatastores (System.Reliance) |
| RelyVirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnDatastores (System.Reliance) |


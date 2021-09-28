---
id: VirtualMachines
slug: VirtualMachines
---

# Orion.VIM.VirtualMachines

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Machine

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.Virtualization.Instance](./../Orion.Virtualization/Instance)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | UUID | everyone |
| HostID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Host ID | everyone |
| ResourcePoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VMConfigFile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Virtual Machine Config File | everyone |
| MemoryConfigured | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Configured | everyone |
| MemoryShares | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Shares | everyone |
| CPUShares | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Shares | everyone |
| GuestState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest State | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address | everyone |
| LogDirectory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GuestVmWareToolsVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest VMware Tools Version | everyone |
| GuestVmWareToolsStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest VMware Tools Status | everyone |
| GuestName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest Name | everyone |
| GuestFamily | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest Family | everyone |
| GuestDnsName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Guest DNS Name | everyone |
| NicCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | NIC Count | everyone |
| VDisksCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | VDisks Count | everyone |
| ProcessorCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Processor Count | everyone |
| PowerState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Power State | everyone |
| BootTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Boot Time | everyone |
| OSUptime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ConfigStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Config Status | everyone |
| OverallStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Overall Status | everyone |
| NodeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Node Status | everyone |
| CpuUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Usage | everyone |
| MemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Memory Percent Usage | everyone |
| MemUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Usage | everyone |
| IsLicensed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Is Licensed | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelativePath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DatastoreIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CpuReady | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SwappedMemoryUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SwappedMemoryUtilizationPercent | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BalloonMemload | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BalloonMemloadPercent | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ThroughputTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SnapshotStorageSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ConsumedMemLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ConsumedPercentMemLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LastActivityDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TotalStorageSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TotalStorageSizeUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VolumeSummaryCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VolumeSummaryFreeSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VolumeSummaryFreeSpacePercent | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| VolumeSummaryCapacityDepletionDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RunTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CpuCostop | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DynamicMemoryEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Dynamic Memory Enabled | everyone |
| SnapshotSummaryCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OldestSnapshotDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| HeartBeat | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| SnapshotDateModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MemoryAllocationLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VirtualDiskDateModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |
| MinimumMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| StartupMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MemoryBuffer | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InstanceUuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyLUNs | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.Rely.SRM.VirtualMachinesRelyOnLUNs (System.Reliance) |
| Platform | [Orion.VIM.Platform](./../Orion.VIM/Platform) | Defined by relationship Orion.VIM.VirtualMachineReferencesPlatform (System.Reference) |
| Thresholds | [Orion.VIM.VirtualMachineThresholds](./../Orion.VIM/VirtualMachineThresholds) | Defined by relationship Orion.VIM.VirtualMachineHostsVirtualMachineThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.VirtualMachineCpuLoadThreshold](./../Orion.VIM/VirtualMachineCpuLoadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.VirtualMachineMemUsageThreshold](./../Orion.VIM/VirtualMachineMemUsageThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsMemUsageThreshold (System.Hosting) |
| NetworkUsageRateThreshold | [Orion.VIM.VirtualMachineNetworkUsageRateThreshold](./../Orion.VIM/VirtualMachineNetworkUsageRateThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsNetworkUsageRateThreshold (System.Hosting) |
| CpuReadyThreshold | [Orion.VIM.VirtualMachineCpuReadyThreshold](./../Orion.VIM/VirtualMachineCpuReadyThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsCpuReadyThreshold (System.Hosting) |
| LatencyTotalThreshold | [Orion.VIM.VirtualMachineLatencyTotalThreshold](./../Orion.VIM/VirtualMachineLatencyTotalThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyTotalThreshold (System.Hosting) |
| LatencyReadThreshold | [Orion.VIM.VirtualMachineLatencyReadThreshold](./../Orion.VIM/VirtualMachineLatencyReadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyReadThreshold (System.Hosting) |
| LatencyWriteThreshold | [Orion.VIM.VirtualMachineLatencyWriteThreshold](./../Orion.VIM/VirtualMachineLatencyWriteThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyWriteThreshold (System.Hosting) |
| IOPSTotalThreshold | [Orion.VIM.VirtualMachineIOPSTotalThreshold](./../Orion.VIM/VirtualMachineIOPSTotalThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.VIM.VirtualMachineIOPSReadThreshold](./../Orion.VIM/VirtualMachineIOPSReadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.VIM.VirtualMachineIOPSWriteThreshold](./../Orion.VIM/VirtualMachineIOPSWriteThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSWriteThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.VirtualMachinesCustomProperties](./../Orion.VIM/VirtualMachinesCustomProperties) | Defined by relationship Orion.VIM.VirtualMachinesHostCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.VirtualMachineReferencesDatastore (System.Reference) |
| VirtualDisks | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualMachineToVirtualDisksMappingReference (System.Reference) |
| VirtualVolumes | [Orion.VIM.VirtualMachineVolumes](./../Orion.VIM/VirtualMachineVolumes) | Defined by relationship Orion.VIM.VirtualMachineToVirtualVolumesMappingReference (System.Reference) |
| VirtualMediaDevices | [Orion.VIM.VirtualMachineMediaDevices](./../Orion.VIM/VirtualMachineMediaDevices) | Defined by relationship Orion.VIM.VirtualMachineToVirtualMediaDeviceMappingReference (System.Hosting) |
| ResourcePool | [Orion.VIM.ResourcePools](./../Orion.VIM/ResourcePools) | Defined by relationship Orion.VIM.VirtualMachineReferencesResourcePool (System.Reference) |
| IPAddresses | [Orion.VIM.VirtualMachineIPAddresses](./../Orion.VIM/VirtualMachineIPAddresses) | Defined by relationship Orion.VIM.VirtualMachinesToIPAddressesMappingReference (System.Reference) |
| MACAddresses | [Orion.VIM.VirtualMachineMACAddresses](./../Orion.VIM/VirtualMachineMACAddresses) | Defined by relationship Orion.VIM.VirtualMachinesToMACAddressesHosting (System.Hosting) |
| VMStatistics | [Orion.VIM.VMStatistics](./../Orion.VIM/VMStatistics) | Defined by relationship Orion.VIM.VMVMStatistics (System.Hosting) |
| RelyHost | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnHost (System.Reliance) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.VirtualMachineRelyOnNode (System.Reliance) |
| RelyDatastores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnDatastores (System.Reliance) |
| Platform | [Orion.VIM.Platform](./../Orion.VIM/Platform) | Defined by relationship Orion.VIM.VirtualMachineReferencesPlatform (System.Reference) |
| Thresholds | [Orion.VIM.VirtualMachineThresholds](./../Orion.VIM/VirtualMachineThresholds) | Defined by relationship Orion.VIM.VirtualMachineHostsVirtualMachineThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.VirtualMachineCpuLoadThreshold](./../Orion.VIM/VirtualMachineCpuLoadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.VirtualMachineMemUsageThreshold](./../Orion.VIM/VirtualMachineMemUsageThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsMemUsageThreshold (System.Hosting) |
| NetworkUsageRateThreshold | [Orion.VIM.VirtualMachineNetworkUsageRateThreshold](./../Orion.VIM/VirtualMachineNetworkUsageRateThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsNetworkUsageRateThreshold (System.Hosting) |
| CpuReadyThreshold | [Orion.VIM.VirtualMachineCpuReadyThreshold](./../Orion.VIM/VirtualMachineCpuReadyThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsCpuReadyThreshold (System.Hosting) |
| LatencyTotalThreshold | [Orion.VIM.VirtualMachineLatencyTotalThreshold](./../Orion.VIM/VirtualMachineLatencyTotalThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyTotalThreshold (System.Hosting) |
| LatencyReadThreshold | [Orion.VIM.VirtualMachineLatencyReadThreshold](./../Orion.VIM/VirtualMachineLatencyReadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyReadThreshold (System.Hosting) |
| LatencyWriteThreshold | [Orion.VIM.VirtualMachineLatencyWriteThreshold](./../Orion.VIM/VirtualMachineLatencyWriteThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsLatencyWriteThreshold (System.Hosting) |
| IOPSTotalThreshold | [Orion.VIM.VirtualMachineIOPSTotalThreshold](./../Orion.VIM/VirtualMachineIOPSTotalThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.VIM.VirtualMachineIOPSReadThreshold](./../Orion.VIM/VirtualMachineIOPSReadThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.VIM.VirtualMachineIOPSWriteThreshold](./../Orion.VIM/VirtualMachineIOPSWriteThreshold) | Defined by relationship Orion.VIM.VirtualMachineHostsIOPSWriteThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.VirtualMachinesCustomProperties](./../Orion.VIM/VirtualMachinesCustomProperties) | Defined by relationship Orion.VIM.VirtualMachinesHostCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.VirtualMachineReferencesDatastore (System.Reference) |
| VirtualDisks | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualMachineToVirtualDisksMappingReference (System.Reference) |
| VirtualVolumes | [Orion.VIM.VirtualMachineVolumes](./../Orion.VIM/VirtualMachineVolumes) | Defined by relationship Orion.VIM.VirtualMachineToVirtualVolumesMappingReference (System.Reference) |
| VirtualMediaDevices | [Orion.VIM.VirtualMachineMediaDevices](./../Orion.VIM/VirtualMachineMediaDevices) | Defined by relationship Orion.VIM.VirtualMachineToVirtualMediaDeviceMappingReference (System.Hosting) |
| ResourcePool | [Orion.VIM.ResourcePools](./../Orion.VIM/ResourcePools) | Defined by relationship Orion.VIM.VirtualMachineReferencesResourcePool (System.Reference) |
| IPAddresses | [Orion.VIM.VirtualMachineIPAddresses](./../Orion.VIM/VirtualMachineIPAddresses) | Defined by relationship Orion.VIM.VirtualMachinesToIPAddressesMappingReference (System.Reference) |
| MACAddresses | [Orion.VIM.VirtualMachineMACAddresses](./../Orion.VIM/VirtualMachineMACAddresses) | Defined by relationship Orion.VIM.VirtualMachinesToMACAddressesHosting (System.Hosting) |
| VMStatistics | [Orion.VIM.VMStatistics](./../Orion.VIM/VMStatistics) | Defined by relationship Orion.VIM.VMVMStatistics (System.Hosting) |
| RelyHost | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnHost (System.Reliance) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.VirtualMachineRelyOnNode (System.Reliance) |
| RelyDatastores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnDatastores (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SRMLUNs | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.SRM.LUNsReferencesVirtualMachines (System.Reference) |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostsToVirtualMachinesMappingReference (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToVirtualMachines (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesVirtualMachine (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesVirtualMachine (System.Reference) |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostsToVirtualMachinesMappingReference (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToVirtualMachines (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesVirtualMachine (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesVirtualMachine (System.Reference) |


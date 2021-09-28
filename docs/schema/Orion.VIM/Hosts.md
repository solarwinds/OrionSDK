---
id: Hosts
slug: Hosts
---

# Orion.VIM.Hosts

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Host

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| update | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| HostID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Host ID | everyone |
| CortexID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Node ID | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Host Name | everyone |
| ClusterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Cluster ID | everyone |
| SecondaryClusterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Secondary Cluster ID | everyone |
| DataCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Data Center ID | everyone |
| VMwareProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | VMware Product Name | everyone |
| VMwareProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | VMware Product Version | everyone |
| PollingJobID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ServiceURIID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CredentialID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| HostStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling status providing info whether entity is polled or not. | everyone |
| PollingMethod | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling Method | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Model | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Vendor | everyone |
| ProcessorType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Processor Type | everyone |
| CpuCoreCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Core Count | everyone |
| CpuPkgCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Pkg Count | everyone |
| CpuMhz | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU | everyone |
| NicCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | NIC Count | everyone |
| HbaCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | HBA Count | everyone |
| HbaFcCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | HBA FC Count | everyone |
| HbaScsiCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | HBA SCSI Count | everyone |
| HbaIscsiCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | HBA ISCSI Count | everyone |
| MemorySize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Size | everyone |
| BuildNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Build Number | everyone |
| BiosSerial | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | BIOS Serial | everyone |
| DNSHostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | DNS Host Name | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address | everyone |
| ConnectionState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Connection State | everyone |
| ConfigStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Config Status | everyone |
| OverallStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Overall Status | everyone |
| NodeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Node Status | everyone |
| NetworkUtilization | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Network Utilization | everyone |
| NetworkUsageRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Network Usage Rate | everyone |
| NetworkTransmitRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Network Transmit Rate | everyone |
| NetworkReceiveRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Network Receive Rate | everyone |
| NetworkCapacityKbps | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Network Capacity | everyone |
| CpuLoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | CPU Load | everyone |
| CpuUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Usage | everyone |
| MemUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Memory Percent Usage | everyone |
| MemUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Usage | everyone |
| VmCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine Count | everyone |
| VmRunningCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine Running Count | everyone |
| StatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status Message | everyone |
| PlatformID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtualization Platform | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BootTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Boot time | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RunTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TotalLatency | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |
| InMaintenanceMode | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| VsanNodeUuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Thresholds | [Orion.VIM.HostThresholds](./../Orion.VIM/HostThresholds) | Defined by relationship Orion.VIM.HostHostsHostThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.HostCpuLoadThreshold](./../Orion.VIM/HostCpuLoadThreshold) | Defined by relationship Orion.VIM.HostHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.HostMemUsageThreshold](./../Orion.VIM/HostMemUsageThreshold) | Defined by relationship Orion.VIM.HostHostsMemUsageThreshold (System.Hosting) |
| NetworkUtilizationThreshold | [Orion.VIM.HostNetworkUtilizationThreshold](./../Orion.VIM/HostNetworkUtilizationThreshold) | Defined by relationship Orion.VIM.HostHostsNetworkUtilizationThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.HostsCustomProperties](./../Orion.VIM/HostsCustomProperties) | Defined by relationship Orion.VIM.HostsHostCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.HostReferencesDatastore (System.Reference) |
| DataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.HostReferencesDataCenter (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.HostsToVirtualMachinesMappingReference (System.Reference) |
| IPAddresses | [Orion.VIM.HostIPAddresses](./../Orion.VIM/HostIPAddresses) | Defined by relationship Orion.VIM.HostsToIPAddressesMappingReference (System.Reference) |
| MACAddresses | [Orion.VIM.HostMACAddresses](./../Orion.VIM/HostMACAddresses) | Defined by relationship Orion.VIM.HostsToMACAddressesHosting (System.Hosting) |
| HostStatistics | [Orion.VIM.HostStatistics](./../Orion.VIM/HostStatistics) | Defined by relationship Orion.VIM.HostsHostStatistics (System.Hosting) |
| HostStorageStatistics | [Orion.VIM.HostStorageStatistics](./../Orion.VIM/HostStorageStatistics) | Defined by relationship Orion.VIM.HostsHostStorageStatistics (System.Hosting) |
| VSanResyncInfo | [Cortex.Orion.Virtualization.VSanResyncInfo](./../Cortex.Orion.Virtualization/VSanResyncInfo) | Defined by relationship Orion.VIM.HostReferencesVSanResyncInfo (System.Reference) |
| RelyDataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnDataCenter (System.Reliance) |
| RelyCluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnCluster (System.Reliance) |
| RelySecondaryCluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnSecondaryCluster (System.Reliance) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.HostRelyOnNode (System.Reliance) |
| HostStorageStatistics | [Orion.VIM.HostStorageStatistics](./../Orion.VIM/HostStorageStatistics) | Defined by relationship Orion.VIM.HostsHostStorageStatistics (System.Hosting) |
| VSanResyncInfo | [Cortex.Orion.Virtualization.VSanResyncInfo](./../Cortex.Orion.Virtualization/VSanResyncInfo) | Defined by relationship Orion.VIM.HostReferencesVSanResyncInfo (System.Reference) |
| Thresholds | [Orion.VIM.HostThresholds](./../Orion.VIM/HostThresholds) | Defined by relationship Orion.VIM.HostHostsHostThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.HostCpuLoadThreshold](./../Orion.VIM/HostCpuLoadThreshold) | Defined by relationship Orion.VIM.HostHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.HostMemUsageThreshold](./../Orion.VIM/HostMemUsageThreshold) | Defined by relationship Orion.VIM.HostHostsMemUsageThreshold (System.Hosting) |
| NetworkUtilizationThreshold | [Orion.VIM.HostNetworkUtilizationThreshold](./../Orion.VIM/HostNetworkUtilizationThreshold) | Defined by relationship Orion.VIM.HostHostsNetworkUtilizationThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.HostsCustomProperties](./../Orion.VIM/HostsCustomProperties) | Defined by relationship Orion.VIM.HostsHostCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.HostReferencesDatastore (System.Reference) |
| DataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.HostReferencesDataCenter (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.HostsToVirtualMachinesMappingReference (System.Reference) |
| IPAddresses | [Orion.VIM.HostIPAddresses](./../Orion.VIM/HostIPAddresses) | Defined by relationship Orion.VIM.HostsToIPAddressesMappingReference (System.Reference) |
| MACAddresses | [Orion.VIM.HostMACAddresses](./../Orion.VIM/HostMACAddresses) | Defined by relationship Orion.VIM.HostsToMACAddressesHosting (System.Hosting) |
| HostStatistics | [Orion.VIM.HostStatistics](./../Orion.VIM/HostStatistics) | Defined by relationship Orion.VIM.HostsHostStatistics (System.Hosting) |
| RelyDataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnDataCenter (System.Reliance) |
| RelyCluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnCluster (System.Reliance) |
| RelySecondaryCluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.HostsRelyOnSecondaryCluster (System.Reliance) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.HostRelyOnNode (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PollingTasks | [Orion.VIM.PollingTasks](./../Orion.VIM/PollingTasks) | Defined by relationship Orion.VIM.PollingTaskReferencesHost (System.Reference) |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterToHostsMappingReference (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToHosts (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesHost (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesHost (System.Reference) |
| RelyVirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnHost (System.Reliance) |
| PollingTasks | [Orion.VIM.PollingTasks](./../Orion.VIM/PollingTasks) | Defined by relationship Orion.VIM.PollingTaskReferencesHost (System.Reference) |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterToHostsMappingReference (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToHosts (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesHost (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesHost (System.Reference) |
| RelyVirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachinesRelyOnHost (System.Reliance) |


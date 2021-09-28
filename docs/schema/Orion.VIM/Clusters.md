---
id: Clusters
slug: Clusters
---

# Orion.VIM.Clusters

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Cluster

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ClusterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Cluster ID | everyone |
| CortexID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DataCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| TotalMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Total Memory | everyone |
| TotalCpu | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Total CPU | everyone |
| CpuCoreCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Core Count | everyone |
| CpuThreadCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Thread Count | everyone |
| EffectiveCpu | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Effective CPU | everyone |
| EffectiveMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Effective Memory | everyone |
| DrsBehaviour | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | DRS Behaviour | everyone |
| DrsStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | DRS Status | everyone |
| DrsVmotionRate | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | DRS vMotion Rate | everyone |
| HaAdmissionControlStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | HA Admission Control Status | everyone |
| HaStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | HA Status | everyone |
| HaFailoverLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | HA Failover Level | everyone |
| ConfigStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Config Status | everyone |
| OverallStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Overall Status | everyone |
| CPULoad | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | CPU Load | everyone |
| CPUUsageMHz | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Usage | everyone |
| MemoryUsage | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) | Memory Percent Usage | everyone |
| MemoryUsageMB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Usage | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PlatformID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtualization Platform | everyone |
| VmCapacityCount | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| VmCapacityConstraint | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DiskUtilizationDepletionDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DatastoreUsedSpace | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CpuUtilizationDepletionDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MemoryUtilizationDepletionDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Computed polling source | everyone |
| VsanEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| VsanUuid | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling status providing info whether entity is polled or not. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSan | [Cortex.Orion.Virtualization.VSan](./../Cortex.Orion.Virtualization/VSan) | Defined by relationship Cortex.Orion.Virtualization.OrionClusterToVSan (System.Hosting) |
| Thresholds | [Orion.VIM.ClusterThresholds](./../Orion.VIM/ClusterThresholds) | Defined by relationship Orion.VIM.ClusterHostsClusterThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.ClusterCpuLoadThreshold](./../Orion.VIM/ClusterCpuLoadThreshold) | Defined by relationship Orion.VIM.ClusterHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.ClusterMemUsageThreshold](./../Orion.VIM/ClusterMemUsageThreshold) | Defined by relationship Orion.VIM.ClusterHostsMemUsageThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.ClustersCustomProperties](./../Orion.VIM/ClustersCustomProperties) | Defined by relationship Orion.VIM.ClustersCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.ClusterReferencesDatastore (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.ClusterToHostsMappingReference (System.Reference) |
| ClusterStatistics | [Orion.VIM.ClusterStatistics](./../Orion.VIM/ClusterStatistics) | Defined by relationship Orion.VIM.ClusterClusterStatistics (System.Hosting) |
| ClusterStorageStatistics | [Orion.VIM.ClusterStorageStatistics](./../Orion.VIM/ClusterStorageStatistics) | Defined by relationship Orion.VIM.ClusterHostsStorageStatistics (System.Hosting) |
| NutanixDiscoveryMetadata | [Orion.Nutanix.DiscoveryMetadata](./../Orion.Nutanix/DiscoveryMetadata) | Defined by relationship Orion.VIM.ClusterReferencesNutanixDiscoveryMetadata (System.Reference) |
| RelyDataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.ClustersRelyOnDataCenter (System.Reliance) |
| ClusterStorageStatistics | [Orion.VIM.ClusterStorageStatistics](./../Orion.VIM/ClusterStorageStatistics) | Defined by relationship Orion.VIM.ClusterHostsStorageStatistics (System.Hosting) |
| Thresholds | [Orion.VIM.ClusterThresholds](./../Orion.VIM/ClusterThresholds) | Defined by relationship Orion.VIM.ClusterHostsClusterThresholds (System.Hosting) |
| CpuLoadThreshold | [Orion.VIM.ClusterCpuLoadThreshold](./../Orion.VIM/ClusterCpuLoadThreshold) | Defined by relationship Orion.VIM.ClusterHostsCpuLoadThreshold (System.Hosting) |
| MemUsageThreshold | [Orion.VIM.ClusterMemUsageThreshold](./../Orion.VIM/ClusterMemUsageThreshold) | Defined by relationship Orion.VIM.ClusterHostsMemUsageThreshold (System.Hosting) |
| CustomProperties | [Orion.VIM.ClustersCustomProperties](./../Orion.VIM/ClustersCustomProperties) | Defined by relationship Orion.VIM.ClustersCustomProperties (System.Hosting) |
| DataStores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.VIM.ClusterReferencesDatastore (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.ClusterToHostsMappingReference (System.Reference) |
| ClusterStatistics | [Orion.VIM.ClusterStatistics](./../Orion.VIM/ClusterStatistics) | Defined by relationship Orion.VIM.ClusterClusterStatistics (System.Hosting) |
| NutanixDiscoveryMetadata | [Orion.Nutanix.DiscoveryMetadata](./../Orion.Nutanix/DiscoveryMetadata) | Defined by relationship Orion.VIM.ClusterReferencesNutanixDiscoveryMetadata (System.Reference) |
| RelyDataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.ClustersRelyOnDataCenter (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.DataCenterToClustersMappingReference (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesCluster (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesCluster (System.Reference) |
| RelyHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnCluster (System.Reliance) |
| RelySecondaryHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnSecondaryCluster (System.Reliance) |
| DataCenter | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.DataCenterToClustersMappingReference (System.Reference) |
| Luns | [Orion.VIM.Luns](./../Orion.VIM/Luns) | Defined by relationship Orion.VIM.LunReferencesCluster (System.Reference) |
| NasShares | [Orion.VIM.Nas](./../Orion.VIM/Nas) | Defined by relationship Orion.VIM.NasReferencesCluster (System.Reference) |
| RelyHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnCluster (System.Reliance) |
| RelySecondaryHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnSecondaryCluster (System.Reliance) |


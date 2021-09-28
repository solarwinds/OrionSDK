---
id: DataCenters
slug: DataCenters
---

# Orion.VIM.DataCenters

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Datacenter

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DataCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | DataCenter ID | everyone |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| ConfigStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Config Status | everyone |
| OverallStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Overall Status | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Overall Status | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.DataCenterToClustersMappingReference (System.Reference) |
| RelyVCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.Rely.VIM.DataCentersRelyOnVCenter (System.Reliance) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.DataCenterToClustersMappingReference (System.Reference) |
| RelyVCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.Rely.VIM.DataCentersRelyOnVCenter (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostReferencesDataCenter (System.Reference) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.VCentersToDataCentersMappingReference (System.Reference) |
| RelyClusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.ClustersRelyOnDataCenter (System.Reliance) |
| RelyHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnDataCenter (System.Reliance) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.HostReferencesDataCenter (System.Reference) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.VCentersToDataCentersMappingReference (System.Reference) |
| RelyClusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.Rely.VIM.ClustersRelyOnDataCenter (System.Reliance) |
| RelyHosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostsRelyOnDataCenter (System.Reliance) |


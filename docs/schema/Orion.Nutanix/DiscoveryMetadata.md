---
id: DiscoveryMetadata
slug: DiscoveryMetadata
---

# Orion.Nutanix.DiscoveryMetadata

SolarWinds Information Service 2020.2 Schema Documentation Index

Nutanix Discovery Metadata - contains significant information about Nutanix element, mainly for polling.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MetadataID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Metadata ID | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address | everyone |
| ApiPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | API Port | everyone |
| SshPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | SSH Port | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Uuid | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Uuid | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Engine ID | everyone |
| PollingFrequencyInMinutes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling frequency in minutes | everyone |
| StatisticsPollingFrequencyInSeconds | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Statistics polling frequency in seconds | everyone |
| StatisticsAggregationPeriodInMinutes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Statistics aggregation period in minutes | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.Nutanix.DiscoveryMetadataReferencesPollingEngine (System.Reference) |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterReferencesNutanixDiscoveryMetadata (System.Reference) |
| Cluster | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.ClusterReferencesNutanixDiscoveryMetadata (System.Reference) |


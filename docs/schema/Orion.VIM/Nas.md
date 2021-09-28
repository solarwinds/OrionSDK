---
id: Nas
slug: Nas
---

# Orion.VIM.Nas

SolarWinds Information Service 2020.2 Schema Documentation Index

NAS

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NasID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | NAS ID | everyone |
| RemotePath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Remote Path | everyone |
| RemoteHost | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address | everyone |
| DnsHostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Dns hostname | everyone |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Datastore ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.NasReferencesCluster (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.NasReferencesHost (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.NasReferencesVirtualMachine (System.Reference) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.NasReferencesCluster (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.NasReferencesHost (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.NasReferencesVirtualMachine (System.Reference) |


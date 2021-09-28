---
id: Luns
slug: Luns
---

# Orion.VIM.Luns

SolarWinds Information Service 2020.2 Schema Documentation Index

LUN

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LunID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | LUN ID | everyone |
| LunIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | LUN Identifier | everyone |
| CanonicalName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Canonical Name | everyone |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Datastore ID | everyone |
| ScsiLunID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | SCSI LUN ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualDisks | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.LunToVirtualDisksMappingReference (System.Reference) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.LunReferencesCluster (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.LunReferencesHost (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.LunReferencesVirtualMachine (System.Reference) |
| VirtualDisks | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.LunToVirtualDisksMappingReference (System.Reference) |
| Clusters | [Orion.VIM.Clusters](./../Orion.VIM/Clusters) | Defined by relationship Orion.VIM.LunReferencesCluster (System.Reference) |
| Hosts | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.LunReferencesHost (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.LunReferencesVirtualMachine (System.Reference) |


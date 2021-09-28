---
id: VCenters
slug: VCenters
---

# Orion.VIM.VCenters

SolarWinds Information Service 2020.2 Schema Documentation Index

VMware vCenter

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | VCenter ID | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Node ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| VMwareProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | VMware Product Name | everyone |
| VMwareProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | VMware Product Version | everyone |
| PollingJobID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ServiceURIID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CredentialID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| HostStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling status providing info whether entity is polled or not. | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Model | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Vendor | everyone |
| BuildNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Build Number | everyone |
| BiosSerial | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | BIOS Serial | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address | everyone |
| ConnectionState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Connection State | everyone |
| PollingSource | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status Message | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Managed Status | everyone |
| ManagedStatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Managed Status Message | everyone |
| TriggeredAlarmDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Details Url | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataCenters | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.VCentersToDataCentersMappingReference (System.Reference) |
| ResourcePools | [Orion.VIM.ResourcePools](./../Orion.VIM/ResourcePools) | Defined by relationship Orion.VIM.VCentersToResourcePoolsMappingReference (System.Reference) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.VCenterRelyOnNode (System.Reliance) |
| DataCenters | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.VIM.VCentersToDataCentersMappingReference (System.Reference) |
| ResourcePools | [Orion.VIM.ResourcePools](./../Orion.VIM/ResourcePools) | Defined by relationship Orion.VIM.VCentersToResourcePoolsMappingReference (System.Reference) |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.VIM.VCenterRelyOnNode (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PollingTasks | [Orion.VIM.PollingTasks](./../Orion.VIM/PollingTasks) | Defined by relationship Orion.VIM.PollingTaskReferencesVCenter (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToVCenters (System.Reference) |
| RelyDataCenters | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.DataCentersRelyOnVCenter (System.Reliance) |
| PollingTasks | [Orion.VIM.PollingTasks](./../Orion.VIM/PollingTasks) | Defined by relationship Orion.VIM.PollingTaskReferencesVCenter (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.VIM.NodesToVCenters (System.Reference) |
| RelyDataCenters | [Orion.VIM.DataCenters](./../Orion.VIM/DataCenters) | Defined by relationship Orion.Rely.VIM.DataCentersRelyOnVCenter (System.Reliance) |


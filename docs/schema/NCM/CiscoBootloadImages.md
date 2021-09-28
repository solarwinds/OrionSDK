---
id: CiscoBootloadImages
slug: CiscoBootloadImages
---

# NCM.CiscoBootloadImages

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ImageIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SysBootImageList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysKickstartImageList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| EntityPhysical | [NCM.EntityPhysical](./../NCM/EntityPhysical) | Defined by relationship NCM.EntityPhysicalHostsCiscoBootloadImages (System.Reference) |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesHostsCiscoBootloadImages (System.Reference) |
| Nodes | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodesHostsCiscoBootloadImages (System.Hosting) |


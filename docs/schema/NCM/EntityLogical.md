---
id: EntityLogical
slug: EntityLogical
---

# NCM.EntityLogical

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TDomain | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Community | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefEntityLogical (System.Reference) |
| Node | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodeHostsEntityLogical (System.Hosting) |


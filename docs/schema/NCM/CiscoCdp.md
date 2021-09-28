---
id: CiscoCdp
slug: CiscoCdp
---

# NCM.CiscoCdp

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IfIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CDPIndex | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteDevice | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemotePort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteCapability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemotePlatform | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteDuplex | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteNativeVLAN | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interfaces | [NCM.Interfaces](./../NCM/Interfaces) | Defined by relationship NCM.InterfacesRefCiscoCdp (System.Reference) |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefCiscoCdp (System.Reference) |
| Node | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodeHostsCiscoCdp (System.Hosting) |


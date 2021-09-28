---
id: VirtualPortChannel
slug: VirtualPortChannel
---

# Orion.Nexus.VirtualPortChannel

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VpcId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VpcStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VpcStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Port | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RemoteNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RemoteVpcId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RemoteVirtualPortChannel | [Orion.Nexus.VirtualPortChannel](./../Orion.Nexus/VirtualPortChannel) | Defined by relationship Orion.VirtualPortChannelReferencesRemoteVirtualPortChannel (System.Reference) |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.VirtualPortChannelReferencesInterface (System.Reference) |
| VirtualPortChannelInterfaces | [Orion.Nexus.VirtualPortChannelInterfaces](./../Orion.Nexus/VirtualPortChannelInterfaces) | Defined by relationship Orion.VirtualPortChannelHostsVirtualPortChannelInterfaces (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsVirtualPortChannels (System.Hosting) |
| RemoteVirtualPortChannel | [Orion.Nexus.VirtualPortChannel](./../Orion.Nexus/VirtualPortChannel) | Defined by relationship Orion.VirtualPortChannelReferencesRemoteVirtualPortChannel (System.Reference) |


---
id: VirtualPortChannelInterfaces
slug: VirtualPortChannelInterfaces
---

# Orion.Nexus.VirtualPortChannelInterfaces

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
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.VirtualPortChannelInterfaceReferencesInterface (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualPortChannel | [Orion.Nexus.VirtualPortChannel](./../Orion.Nexus/VirtualPortChannel) | Defined by relationship Orion.VirtualPortChannelHostsVirtualPortChannelInterfaces (System.Hosting) |


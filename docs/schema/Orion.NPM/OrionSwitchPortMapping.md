---
id: OrionSwitchPortMapping
slug: OrionSwitchPortMapping
---

# Orion.NPM.OrionSwitchPortMapping

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SourceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourceIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePortAdminStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourcePortSpeed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| SourcePortIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourceMACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceInterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MappedIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedHostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MappedPortDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedPortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedPortAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedPortType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedPortState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedPortAdminStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MappedPortSpeed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MappedPortIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MappedMACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MappedInterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SourceNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.SwitchPortMappingReferencesSourceNode (System.Reference) |
| MappedNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.SwitchPortMappingReferencesMappedNode (System.Reference) |
| SourceInterfaces | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.SwitchPortMappingReferencesSourceInterface (System.Reference) |
| MappedInterfaces | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.SwitchPortMappingReferencesMappedInterface (System.Reference) |


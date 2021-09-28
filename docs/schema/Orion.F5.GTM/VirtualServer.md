---
id: VirtualServer
slug: VirtualServer
---

# Orion.F5.GTM.VirtualServer

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VirtualServerIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMemberRelationship | [Orion.F5.GTM.PoolMember](./../Orion.F5.GTM/PoolMember) | Defined by relationship Orion.F5GTMVirtualServerReferencePoolMembers (System.Reference) |
| Map | [Orion.F5.Map.VirtualServer](./../Orion.F5.Map/VirtualServer) | Defined by relationship Orion.F5GTMVirtualServerReferenceMap (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Server | [Orion.F5.GTM.Server](./../Orion.F5.GTM/Server) | Defined by relationship Orion.F5GTMServerReferenceVirtualServers (System.Reference) |


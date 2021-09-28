---
id: VirtualServer
slug: VirtualServer
---

# Orion.F5.Map.VirtualServer

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GTMVirtualServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LTMVirtualServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LTMIPAddressID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GTMVirtualServer | [Orion.F5.GTM.VirtualServer](./../Orion.F5.GTM/VirtualServer) | Defined by relationship Orion.F5GTMVirtualServerReferenceMap (System.Reference) |
| LTMVirtualServer | [Orion.F5.LTM.VirtualServer](./../Orion.F5.LTM/VirtualServer) | Defined by relationship Orion.F5LTMVirtualServerReferenceMap (System.Reference) |


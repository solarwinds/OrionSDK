---
id: RemoteSWIS
slug: RemoteSWIS
---

# SWISf.RemoteSWIS

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InstanceSiteId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SwisUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Tag | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AlwaysIncludeEntities | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DPAServer | [Orion.DPA.DpaServer](./../Orion.DPA/DpaServer) | Defined by relationship Orion.DpaServerRemoteSwis (System.Reference) |


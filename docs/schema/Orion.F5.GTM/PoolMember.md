---
id: PoolMember
slug: PoolMember
---

# Orion.F5.GTM.PoolMember

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PoolIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VirtualServerIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemberOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Pool | [Orion.F5.GTM.Pool](./../Orion.F5.GTM/Pool) | Defined by relationship Orion.F5GTMPoolReferencePoolMembers (System.Reference) |
| VirtualServer | [Orion.F5.GTM.VirtualServer](./../Orion.F5.GTM/VirtualServer) | Defined by relationship Orion.F5GTMVirtualServerReferencePoolMembers (System.Reference) |


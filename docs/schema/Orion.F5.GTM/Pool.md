---
id: Pool
slug: Pool
---

# Orion.F5.GTM.Pool

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PoolIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PoolType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WideIPRelationship | [Orion.F5.GTM.WideIPPool](./../Orion.F5.GTM/WideIPPool) | Defined by relationship Orion.F5PoolReferenceWideIPPool (System.Reference) |
| PoolMemberRelationship | [Orion.F5.GTM.PoolMember](./../Orion.F5.GTM/PoolMember) | Defined by relationship Orion.F5GTMPoolReferencePoolMembers (System.Reference) |


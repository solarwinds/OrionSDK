---
id: WideIPPool
slug: WideIPPool
---

# Orion.F5.GTM.WideIPPool

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
| WideIPIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemberOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WideIP | [Orion.F5.GTM.WideIP](./../Orion.F5.GTM/WideIP) | Defined by relationship Orion.F5WideIPReferenceWideIPPool (System.Reference) |
| Pool | [Orion.F5.GTM.Pool](./../Orion.F5.GTM/Pool) | Defined by relationship Orion.F5PoolReferenceWideIPPool (System.Reference) |


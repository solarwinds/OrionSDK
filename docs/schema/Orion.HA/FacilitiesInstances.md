---
id: FacilitiesInstances
slug: FacilitiesInstances
---

# Orion.HA.FacilitiesInstances

SolarWinds Information Service 2020.2 Schema Documentation Index

Facilities which belongs to pool members. Facility can be imagined e.g. as a service (e.g. MSMQ) which indicates health (ability to takeover resources) of a pool member.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RefId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Reference ID of facility | everyone |
| PoolMemberId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool member | everyone |
| CurrentStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Current status of facility | everyone |
| Config | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Facility configuration | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMember | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.HA.PoolsMembersHostsFacilitiesInstances (System.Hosting) |


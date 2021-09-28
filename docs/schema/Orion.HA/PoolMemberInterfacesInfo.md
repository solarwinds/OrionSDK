---
id: PoolMemberInterfacesInfo
slug: PoolMemberInterfacesInfo
---

# Orion.HA.PoolMemberInterfacesInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

IP addresses present on interfaces of pool members.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PoolMemberId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool member | everyone |
| InterfaceType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Type of interface (1 - primary, 2 - other) | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP address | everyone |
| SubnetPrefixLength | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Length of subnet prefix | everyone |
| IsDynamic | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Static or dynamic IPv4 address flag (true - dynamic IP address). | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMember | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.HA.PoolsMembersPoolMemberInterfacesInfo (System.Reference) |


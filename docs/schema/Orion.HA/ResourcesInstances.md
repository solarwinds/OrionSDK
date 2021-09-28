---
id: ResourcesInstances
slug: ResourcesInstances
---

# Orion.HA.ResourcesInstances

SolarWinds Information Service 2020.2 Schema Documentation Index

Resources which belongs to pool members. Resource is a responsibility of Orion server which can be switched to another server in a pool e.g. "Main poller responsibility" or "Virtual IP".

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
| PoolId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool | everyone |
| RefId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Reference ID of resource | everyone |
| PoolMemberId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool member | everyone |
| CurrentStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Current status of resource | everyone |
| PreferredStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Preferred status of member - the status HA service want resource to be | everyone |
| Config | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Resource configuration | everyone |
| ActionExecutionParameters | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Resource actions execution arguments | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMember | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.HA.PoolsMembersResourcesInstances (System.Reference) |
| Pool | [Orion.HA.Pools](./../Orion.HA/Pools) | Defined by relationship Orion.HA.PoolsResourcesInstances (System.Reference) |


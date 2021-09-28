---
id: PoolMembers
slug: PoolMembers
---

# Orion.HA.PoolMembers

SolarWinds Information Service 2020.2 Schema Documentation Index

Pool members (Orion polling engines and backup servers) present in Orion deployment.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PoolMemberId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool member | everyone |
| PoolMemberType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type of pool member (MainPoller, MainPollerStandby, AdditionalPoller, AdditionalPollerStandby) | everyone |
| PoolId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Host name | everyone |
| ElectionPriority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Pool master election priority | everyone |
| Priority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Pool member preference | everyone |
| PreferredStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Preferred status of member - the status HA service or user want member to be | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Current status of pool member | everyone |
| LastHeartBeatTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp of last heart beat | everyone |
| PrimaryIpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Pool member primary IP address | everyone |
| ReasonOfFail | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reason of last failure (0 - ResourceFail, 1 - FacilityFail, 2 - NotResponding, 3- SuicideRule, 4 - Switchover, 5 - Failback) | everyone |
| StatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of last failure | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FacilitiesInstances | [Orion.HA.FacilitiesInstances](./../Orion.HA/FacilitiesInstances) | Defined by relationship Orion.HA.PoolsMembersHostsFacilitiesInstances (System.Hosting) |
| ResourcesInstances | [Orion.HA.ResourcesInstances](./../Orion.HA/ResourcesInstances) | Defined by relationship Orion.HA.PoolsMembersResourcesInstances (System.Reference) |
| PoolMemberInterfacesInfo | [Orion.HA.PoolMemberInterfacesInfo](./../Orion.HA/PoolMemberInterfacesInfo) | Defined by relationship Orion.HA.PoolsMembersPoolMemberInterfacesInfo (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.EnginesReferencesPoolMembers (System.Reference) |
| OrionServer | [Orion.OrionServers](./../Orion/OrionServers) | Defined by relationship Orion.OrionServersReferencesPoolMembers (System.Reference) |
| Pool | [Orion.HA.Pools](./../Orion.HA/Pools) | Defined by relationship Orion.HA.PoolReferencesPoolMembers (System.Reference) |


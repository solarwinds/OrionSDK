---
id: Pools
slug: Pools
---

# Orion.HA.Pools

SolarWinds Information Service 2020.2 Schema Documentation Index

High Availability pools. Pool unites pool members of the same type to provide high availability of Orion servers.

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
| PoolMasterMemberId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of pool member which acts as a pool master | everyone |
| PoolType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type of pool (0 - main poller, 1 - additional poller) | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a pool | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Pool is enabled or disabled | everyone |
| CurrentStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Current status of a pool | everyone |
| CurrentStatusTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp of current status | everyone |
| PoolMasterChangeTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp of pool master role change | everyone |
| IntervalMemberDown | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Interval after which is member considered as down | everyone |
| IntervalPoolTask | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Pool task interval in seconds. In this interval HA service performs regular tasks e.g. services status monitoring | everyone |
| IntervalSuicideRule | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Interval after which member releases its resource if it cannot reach other member of a pool do database | everyone |
| VirtualHostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Virtual Host name assigned to a pool | everyone |
| VirtualIpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Virtual IP Address assigned to a pool | everyone |
| DnsIpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address of DNS server hosting primary zone used by virtual host name | everyone |
| DnsZone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A name of forward lookup DNS zone where virtual host name record is stored | everyone |
| DnsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type of DNS server (Microsoft, BIND, Other) | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Members | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.HA.PoolReferencesPoolMembers (System.Reference) |
| ResourcesInstances | [Orion.HA.ResourcesInstances](./../Orion.HA/ResourcesInstances) | Defined by relationship Orion.HA.PoolsResourcesInstances (System.Reference) |
| LicenseAssignments | [Orion.Licensing.LicenseAssignments](./../Orion.Licensing/LicenseAssignments) | Defined by relationship Orion.HAPoolsReferencesLicenseAssignments (System.Reference) |

## Verbs

### CreatePool

Creates pool based on provided members and resource parametersName of a poolInteger array of pool member IDsAdditional properties containing resources configurations.Object which describes, whether pool was created. Property Code = 0 means that operation was successful. Property Result contains ID of created pool. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### EditPool

Updates pool with a given poolIdPool IDName of a poolAdditional properties containing resources configurations.Object which describes, whether pool was edited. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### ValidateCreatePool

Validates pool (without creating it) based on provided members and resource parametersName of a poolInteger array of pool member IDsAdditional properties containing resources configurations.Object which contains validation result. Property Code = 0 means that validation was successful. Property Result contains validation result data. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### ValidateEditPool

Validates pool with given poolId and resource parameters (without actual update)Pool IDName of a poolAdditional properties containing resources configurations.Object which contains validation result. Property Code = 0 means that validation was successful. Property Result contains validation result data. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### EnablePool

Enables pool with a given poolIdID of poolObject which describes, whether pool was enabled. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DisablePool

Disables pool with a given poolIdID of poolObject which describes, whether pool was disabled. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DeletePool

Delete pool with given poolId.ID of poolObject which describes, whether pool was deleted. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Switchover

Manual failover on a given pool.ID of poolObject which describes, whether manual failover was initiated. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DeleteStaleEngine

Deletes OrionServer and related pool memeber with a given hostName.hostNameObject which describes, whether stale engine was deleted. Property Code = 0 means that operation was successful. Property Message contains error message in case of error.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


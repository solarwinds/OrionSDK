---
id: VServerCapacityStatistics
slug: VServerCapacityStatistics
---

# Orion.SRM.VServerCapacityStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Stores capacity statistics for all VServers

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CapacityAllocated | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacitySubscribed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Weight | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VServer | [Orion.SRM.VServers](./../Orion.SRM/VServers) | Defined by relationship Orion.SRM.VServersReferencesVServerCapacityStatistics (System.Hosting) |


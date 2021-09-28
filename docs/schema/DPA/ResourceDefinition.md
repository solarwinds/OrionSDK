---
id: ResourceDefinition
slug: ResourceDefinition
---

# DPA.ResourceDefinition

SolarWinds Information Service 2020.2 Schema Documentation Index

Provides definition of DB resources (metrics grouped in categories). It provides no dynamic values (in terms values don't change in time unless user takes actions which will cause definition change) and as such it requires no time-frame.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a name of a resource (e.g. Active Sessions, Memory Utilization, Signal Waits Percent) | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Resource name used in DPA UI | everyone |
| CategoryName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a name of a category a resource belongs (e.g. CPU, Memory, Sessions) | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a short description of a resource (e.g. Number of batches being executed by SQL Server every second for resource having name Batch Requests Per Sec and belonging to category Sessions) | everyone |
| ValueUnit | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a unit of this metric (e.g. requests/second, %, pages/second). Unit is represented on Y axis of resource graph. | everyone |
| Thresholds | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Specifies a comma separated list of threshold values. It contains both WARN and CRITICAL limits where first two values are WARN limits and second two CRITICAL limits (e.g. 80,90,90,null) | everyone |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Specifies for which DB instance is this resource applicable. Reference to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.ResourceDefinitionDatabaseInstance (System.Reference) |


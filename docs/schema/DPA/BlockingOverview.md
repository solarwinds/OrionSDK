---
id: BlockingOverview
slug: BlockingOverview
---

# DPA.BlockingOverview

SolarWinds Information Service 2020.2 Schema Documentation Index

Blocking/Blocked time data

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| BlockingSessions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of blocking sessions within the time slice | everyone |
| BlockedSessions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of blocked sessions within the time slice. | everyone |
| TotalTimeBlocking | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total blocking time - real time blocking within the time slice. | everyone |
| TotalTimeBlocked | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total time blocked within the time slice. | everyone |
| TimesliceUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Specifies how time-frame should be split to time slices. | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Beginning and end of the interval for which we want to know the proeprty values (operators &amp;lt;, &amp;lt;=, &amp;gt; and &amp;gt;= can be used in WHERE clauses on this field). End defaults to now. | everyone |


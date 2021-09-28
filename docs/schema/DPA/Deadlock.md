---
id: Deadlock
slug: Deadlock
---

# DPA.Deadlock

SolarWinds Information Service 2020.2 Schema Documentation Index

Collected deadlock information

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of a monitored instance. References to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| DeadlockId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of Deadlock | everyone |
| EventDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Time when the deadlock ocurred | everyone |
| VictimImpact | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Time impact on queries | everyone |
| SessionCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of sessions involved in the deadlock | everyone |
| Program | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the program that sent the query | everyone |
| Machine | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | ID of Deadlock | everyone |
| User | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User under which the query was executed | everyone |
| Database | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the database affected by the deadlock | everyone |
| Object | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the deadlocked object (database table for example) | everyone |


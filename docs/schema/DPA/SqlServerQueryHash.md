---
id: SqlServerQueryHash
slug: SqlServerQueryHash
---

# DPA.SqlServerQueryHash

SolarWinds Information Service 2020.2 Schema Documentation Index

Provides mapping between SQL Handle and its Hash in scope of the given database instance. Both DatabaseId and Handle are mandatory in where condition.

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of a monitored instance. References to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| Handle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SQL Handle | everyone |
| Hash | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | SQL Hash | everyone |


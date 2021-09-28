---
id: SQLQueryInfo
slug: SQLQueryInfo
---

# DPA.SQLQueryInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

The entity provides the full formatted sql text and custom name for given sqlhash. DatabaseId and Hash are mandatory in where condition.

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
| SqlHash | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SQL Hash | everyone |
| FullSqlText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Full formatted SQL text. If text not polled returns 'SQL statement not available'. | everyone |
| SQLName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Custom name of SQL. If SQL not named, returns SQL Hash or Oracle SQL Id if supported and collected. | everyone |


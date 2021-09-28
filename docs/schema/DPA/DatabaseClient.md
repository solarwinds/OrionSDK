---
id: DatabaseClient
slug: DatabaseClient
---

# DPA.DatabaseClient

SolarWinds Information Service 2020.2 Schema Documentation Index

Provides mapping between machine (client) (identified by its address) and monitored DB instance (identified by its ID).

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
| Address | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Address of a machine that accessed monitored instance during the provided time period | everyone |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of a monitored instance. References to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Definition of Time interval for which we want to find mappings (operators &amp;lt;, &amp;lt;=, &amp;gt; and &amp;gt;= can be used in WHERE clauses on this field) Turns into last seen date in result set. | everyone |


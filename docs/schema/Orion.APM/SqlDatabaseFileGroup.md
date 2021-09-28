---
id: SqlDatabaseFileGroup
slug: SqlDatabaseFileGroup
---

# Orion.APM.SqlDatabaseFileGroup

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database file group information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseFileGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file group. | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SQL database. | everyone |
| ServerDataSpaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SQL server data space entity. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database file group name. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseFileGroups (System.Hosting) |


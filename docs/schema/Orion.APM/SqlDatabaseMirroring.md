---
id: SqlDatabaseMirroring
slug: SqlDatabaseMirroring
---

# Orion.APM.SqlDatabaseMirroring

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL database mirroring information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| MirroringID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The database mirroring GUID. | everyone |
| State | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The byte value that contains database mirroring state. | everyone |
| Role | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The byte value that contains database role. | everyone |
| PartnerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains partner database name. | everyone |
| PartnerInstance | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains partner database instance. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlDatabase | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseHostsSqlDatabaseMirroring (System.Hosting) |


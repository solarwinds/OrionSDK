---
id: SqlIndex
slug: SqlIndex
---

# Orion.APM.SqlIndex

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL index.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IndexID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of index. | everyone |
| SqlDatabaseFileGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database file group. | everyone |
| SqlDatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL database. | everyone |
| ServerObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of index. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the index name. | everyone |
| TableName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the index table name. | everyone |
| IndexType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The byte value that contains the index type. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the index size. | everyone |
| Fragmentation | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the index fragmentation. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an index. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for index. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlDatabaseIndexes (System.Hosting) |


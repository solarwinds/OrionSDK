---
id: TrendDataDimension
slug: TrendDataDimension
---

# DPA.TrendDataDimension

SolarWinds Information Service 2020.2 Schema Documentation Index

Trend data for DB instance per dimension

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. This parameter is not required for data-dimensions 18, 19 and 20 (see bellow – virtual dimensions). On the other hand this parameter can be specified with WHERE Id IN (x, y, z) for these three dimensions | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Trend data-dimension; possible values are: SQL (1), WAIT (2), PROGRAM (3), DATABASE_INSTANCE (4), MACHINE (5), DB_USER (6), OS_USER (7), FILE (8), DRIVE (9), PLAN (10), ACTION (11), MODULE (12), PARTITION (13), OBJECT (14), PROCEDURE (15) and virtual dimensions TOP_WAIT (18), TRENDING_UP_WAIT (19), TRENDING_DOWN_WAIT (20) | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Data-dimension names–readable data-dimension representations: 'SQL Statement', 'Wait-time', 'Program', 'Database', 'Machine', 'Database User', 'O/S User', 'File', 'Drive', 'Plan', 'Action', 'Module', 'Partition', 'Object', 'Procedure', 'Top Wait-time', 'Trending-up Wait-time', 'Trending-down Wait-time' | everyone |
| Wait | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total wait-time in seconds for each returned record. For Trending-up (down) wait-time this value represents percent change (not time) | everyone |
| AverageWait | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average wait-time in seconds for DB instance | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Time-stamp of entity record (operators &amp;lt;, &amp;lt;=, &amp;gt; and &amp;gt;= can be used in WHERE clauses on this field) | everyone |
| TimeUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Used for filtration of records by setting desired granularity (millis (0), seconds (1), minutes (2), hours (3), days (4), weeks (5), months (6))
Since this is only a prototype the only values allowed are 3 (hours) and 4 (days) and both are mutually exclusive (you cannot get records for both hours and days by a single query) | everyone |
| InstanceId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | IDs of an instances in DPA; for programs, machines, users, etc. these are typically generically-generated IDs in local repository table; for SQL texts these are SQL hashes | everyone |
| InstanceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of an instance; e.g. 'IGNITE' (for program), 'administrator-XYZ' (for user), 348A3F21 (for SQL text) | everyone |
| InstanceValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Typically set only for SQLs–this field contains full SQL text | everyone |
| MaxInstances | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Serves only to limit the maximal number of monitored database instances to be retrieved (top 5, 10, etc.) | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceTrendDataDimension (System.Reference) |


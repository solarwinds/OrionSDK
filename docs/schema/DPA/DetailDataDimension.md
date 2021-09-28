---
id: DetailDataDimension
slug: DetailDataDimension
---

# DPA.DetailDataDimension

SolarWinds Information Service 2020.2 Schema Documentation Index

Detail Wait Time statistics for DB instance

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| DimensionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Detail data-dimension; possible values are: SQL (1), WAIT (2), PROGRAM (3), DATABASE_INSTANCE (4), MACHINE (5), DB_USER (6), OS_USER (7), FILE (8), DRIVE (9), PLAN (10), ACTION (11), MODULE (12), PARTITION (13), OBJECT (14), PROCEDURE (15), SESSION (16) | everyone |
| InstanceId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IDs of an instances in DPA; for programs, machines, users, etc. these are typically generically-generated IDs in local repository table; for SQL texts these are SQL hashes | everyone |
| InstanceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of an instance; e.g. 'IGNITE' (for program), 'administrator-XYZ' (for user), 348A3F21 (for SQL text) | everyone |
| TopN | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Limits the maximal number of categories (SQLs, programs etc.) to be retrieved for the specified time interval. Ignored for WAIT dimension if the TimesliceUnit is not provided.
If TopN is not specified, default value is the NUMBER_OF_ITEMS_IN_TIMESERIES_CHART attribute in DPA config for the given monitored database instance. | everyone |
| InstanceValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | For SQL time-slice – this field contains full SQL text; For other time-slice dimensions it is empty; For all non time-slice dimensions it contains WAIT cause | everyone |
| IntervalUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Allowed values are 
HOUR (3), TWO_HOURS (30), THREE_HOURS (31), FOUR_HOURS (32), SIX_HOURS (33), EIGHT_HOURS (34), TWELVE_HOURS (35 | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Time-stamp of entity record (operators &amp;lt;, &amp;lt;=, &amp;gt; and &amp;gt;= can be used in WHERE clauses on this field) | everyone |
| TimesliceUnit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Specifies how time-frame should be split. Allowed values are (other than ones in IntervalUnit) 
FIVE_SECONDS (10), TEN_SECONDS (11), FIFTEEN_SECONDS (12), TWENTY_SECONDS (13), THIRTY_SECONDS (14), MINUTE (2), TWO_MINUTES (20), FIVE_MINUTES (21), TEN_MINUTES (22), TWENTY_MINUTES (23), THIRTY_MINUTES (24), TWO_DAYS (40), THREE_DAYS (41) | everyone |
| Wait | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total wait-time in seconds for each returned record | everyone |
| Executions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of Executions for each returned value. Returns 'null' if value is not specified (e.g. Timeslice &amp;lt; 10 min or Dimension &amp;lt;&amp;gt; 1 ), -1 if 'Not Available' (e.g. in Truncate queries), otherwise not negative number | everyone |
| Average | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Average in seconds for each returned value. Returns 'null' if value is not specified (e.g. Timeslice &amp;lt; 10 min or Dimension &amp;lt;&amp;gt; 1 ), -1 if 'Not Available' (e.g. in Truncate queries), otherwise not negative number | everyone |
| MachineIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Machine identifier | everyone |
| AdditionalValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceDetailDataDimension (System.Reference) |


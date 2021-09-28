---
id: WaitData
slug: WaitData
---

# DPA.WaitData

SolarWinds Information Service 2020.2 Schema Documentation Index

PerfStack data explorer data for waits

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseInstanceId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of Database Instance | everyone |
| PrimaryDimension | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a primary dimension. Has to be equal to dimension name without non-alphanumeric characters. See the names in NormalizedDataDimension class | everyone |
| PrimaryDimensionValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Single value uniquely identifying the dimension entry. | everyone |
| WaitTime | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total Wait Time for this dimension entry in given time interval. | everyone |
| TotalWaitPercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Percentage of Total Wait Time in given time interval. | everyone |
| Executions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of query executions from SQL Statistics (CONSS_xx). Available only for SQL / TOP_WAIT primary dimension. | everyone |
| WaitTypes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Comma separated list of Wait Types for SQL / TOP_WAIT dimensions for 1 hour of data. NULL for all other dimensions. | everyone |
| Databases | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Comma separated list of Databases for SQL / TOP_WAIT dimensions for 1 hour of data. NULL for all other dimensions. | everyone |
| DbUsers | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Comma separated list of Database Users for SQL / TOP_WAIT dimensions for 1 hour of data. NULL for all other dimensions. | everyone |
| Machines | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Comma separated list of Machines for SQL / TOP_WAIT dimensions for 1 hour of data. NULL for all other dimensions. | everyone |
| Programs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Comma separated list of Programs for SQL / TOP_WAIT dimensions for 1 hour of data. NULL for all other dimensions. | everyone |
| Text | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Additional text. Currently only used for SQL / TOP_WAIT dimension to provide first part of the SQL query from CONST_xx. | everyone |
| Link | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL link. Will be used to provide URLs for Perfstack that'll lead to more details about the entry. | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Time of the data point. | everyone |
| Interval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Duration of the data point in seconds. | everyone |
| Rank | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Order of the entry based on its total wait time. | everyone |


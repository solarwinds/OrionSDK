---
id: TimeSeriesData
slug: TimeSeriesData
---

# DPA.TimeSeriesData

SolarWinds Information Service 2020.2 Schema Documentation Index

PerfStack compatible metric data

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of Database Instance | everyone |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of Database Instance | everyone |
| CategoryName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a category a resource belongs (e.g. CPU, Memory, Sessions) that must be equal to one of the records from DPA.TimeSeriesDefinition.CategoryName | everyone |
| MetricName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a metric (e.g. ActiveSessions, MemoryUtilization, SignalWaitsPercent) that must be equal to one of the records from DPA.TimeSeriesDefinition.MetricName | everyone |
| Value | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double-precision value of this data-point in given time | everyone |
| Weight | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Specifies for which time frime this data point is applicable in seconds | everyone |
| ObservationTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp of data-point | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Label of given data point for Wait-Time based metrics | everyone |
| Rank | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Order of label in legend and chart | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceTimeSeriesData (System.Reference) |


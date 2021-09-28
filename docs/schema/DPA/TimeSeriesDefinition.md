---
id: TimeSeriesDefinition
slug: TimeSeriesDefinition
---

# DPA.TimeSeriesDefinition

SolarWinds Information Service 2020.2 Schema Documentation Index

Definition of PerfStack compatible metrics available for specific Database Instance

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
| DatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of Database Instance | everyone |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of Database Instance | everyone |
| CategoryName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a category a metric belongs to (e.g. CPU, Memory, Sessions, WaitTimes) in format that allows use this property in URL. In case of default category it is same as CategoryDisplayName with trimmed non-alphanumeric characters. In case of custom metrics it is a hash code of CategoryDisplayName. | everyone |
| CategoryDisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User friendly metric category name | everyone |
| MetricName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of a metric (e.g. ActiveSessions, MemoryUtilization, SignalWaitsPercent, TotalInstanceWaitTime) in format that allows use this property in URL. In case of default metric it is same as MetricDisplayName with trimmed non-alphanumeric characters. In case of custom metrics it is a hash code of internal DPA metric name | everyone |
| MinValue | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Minimum value this resource can return. Defaults to 0 if not defined. | everyone |
| MaxValue | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Maximum value this resource can return. Defaults to 0 if not defined. (e.g. 100 for data in percents) | everyone |
| DefaultAggregation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Default value aggregation to use in case data has to be aggregated on client side due to different granularity. Currently is always set to SUM. | everyone |
| Units | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Unit of this metric (e.g. requests/second, %, pages/second). Unit is represented on Y axis of resource graph. | everyone |
| ChartType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Determines how data should be displayed. "Gauge" = sparklines; "Bar" = bars; "Stacked" = stacked bars | everyone |
| Subtitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Metric subtitle used in data explorer in perfstack | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceTimeSeriesDefinition (System.Reference) |


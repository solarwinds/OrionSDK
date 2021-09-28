---
id: ForecastCapacity
slug: ForecastCapacity
---

# Orion.ForecastCapacity

SolarWinds Information Service 2020.2 Schema Documentation Index

Top level entity for Capacity Forecasting, which contains general information such as forecasting coeffiecients, predicated days to reach certain thresholds, etc.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InstanceId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MetricId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MetricName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InstanceCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ThresholdType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Timestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MinDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MaxDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CurrentValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| WarningThreshold | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CriticalThreshold | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CapacityThreshold | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Aavg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bavg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Apeak | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bpeak | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToWarningAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToCriticalAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToCapacityAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToWarningPeak | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToCriticalPeak | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DaysToCapacityPeak | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InstanceUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ForecastMetrics | [Orion.ForecastMetrics](./../Orion/ForecastMetrics) | Defined by relationship Orion.ForecastCapacityHostsForecastMetrics (System.Reference) |


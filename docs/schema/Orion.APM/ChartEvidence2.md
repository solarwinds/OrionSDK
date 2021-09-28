---
id: ChartEvidence2
slug: ChartEvidence2
---

# Orion.APM.ChartEvidence2

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents chart evidence statistic.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| MinStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the minimum statistic data. | everyone |
| AvgStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the average statistic data. | everyone |
| MaxStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum statistic data. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of chart evidence records that was archived. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsChartEvidence2 (System.Hosting) |


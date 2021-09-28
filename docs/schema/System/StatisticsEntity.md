---
id: StatisticsEntity
slug: StatisticsEntity
---

# System.StatisticsEntity

SolarWinds Information Service 2020.2 Schema Documentation Index

A sub-type of System.ExtensionEntity for statistical data

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ObservationTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | When this statistic was collected | everyone |
| ObservationFrequency | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The interval between collections. | everyone |
| Weight | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Weight of value in this row. Useful to compute weighted average of values. For example one row with value collected for 20 seconds will have Weight=20. Other row collected for one hour will have Weight=3600. | everyone |


---
id: CBQoSStatisticsDescription
slug: CBQoSStatisticsDescription
---

# Orion.Netflow.CBQoSStatisticsDescription

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| StatisticsID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| StatisticsName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.Netflow.CBQoSStatistics](./../Orion.Netflow/CBQoSStatistics) | Defined by relationship Orion.Netflow.CBQoSStatisticsDescriptionReferencesCBQoSStatistics (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PolicyMetric | [Orion.Netflow.CBQoSPolicyMetric](./../Orion.Netflow/CBQoSPolicyMetric) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSStatisticsDescription (System.Reference) |


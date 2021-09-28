---
id: CBQoSPolicyMetric
slug: CBQoSPolicyMetric
---

# Orion.Netflow.CBQoSPolicyMetric

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MetricID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatisticsID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| PolicyFullPathName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatisticsName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Policy | [Orion.Netflow.CBQoSPolicy](./../Orion.Netflow/CBQoSPolicy) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSPolicy (System.Reference) |
| StatisticsDescription | [Orion.Netflow.CBQoSStatisticsDescription](./../Orion.Netflow/CBQoSStatisticsDescription) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSStatisticsDescription (System.Reference) |
| Statistics | [Orion.Netflow.CBQoSStatistics](./../Orion.Netflow/CBQoSStatistics) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSStatistics (System.Reference) |


---
id: CBQoSStatistics
slug: CBQoSStatistics
---

# Orion.Netflow.CBQoSStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatisticsID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Timestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Bytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Bitrate | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ClassUtilization | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StatisticsDescription | [Orion.Netflow.CBQoSStatisticsDescription](./../Orion.Netflow/CBQoSStatisticsDescription) | Defined by relationship Orion.Netflow.CBQoSStatisticsDescriptionReferencesCBQoSStatistics (System.Reference) |
| Policy | [Orion.Netflow.CBQoSPolicy](./../Orion.Netflow/CBQoSPolicy) | Defined by relationship Orion.Netflow.CBQoSPolicyReferencesCBQoSStatistics (System.Reference) |
| PolicyMetric | [Orion.Netflow.CBQoSPolicyMetric](./../Orion.Netflow/CBQoSPolicyMetric) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSStatistics (System.Reference) |


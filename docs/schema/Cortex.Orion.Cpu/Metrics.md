---
id: Metrics
slug: Metrics
---

# Cortex.Orion.Cpu.Metrics

SolarWinds Information Service 2020.2 Schema Documentation Index

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
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| AvgPercentUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinPercentUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxPercentUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Cpu | [Cortex.Orion.Cpu](./../Cortex.Orion/Cpu) | Defined by relationship Cortex.Orion.CpuToMetrics (System.Hosting) |


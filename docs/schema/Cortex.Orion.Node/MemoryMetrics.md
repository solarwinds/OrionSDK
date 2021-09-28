---
id: MemoryMetrics
slug: MemoryMetrics
---

# Cortex.Orion.Node.MemoryMetrics

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
| AvgPercentMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinPercentMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxPercentMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgMemoryUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| MinMemoryUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| MaxMemoryUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.NodeToMemoryMetrics (System.Hosting) |


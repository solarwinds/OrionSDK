---
id: Statistics
slug: Statistics
---

# Cortex.Orion.Virtualization.VSan.Statistics

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
| IOPSTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IOPSRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IOPSWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ThroughputWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Congestions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutstandingIO | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSan | [Cortex.Orion.Virtualization.VSan](./../Cortex.Orion.Virtualization/VSan) | Defined by relationship Cortex.Orion.Virtualization.VSanToStatistics (System.Hosting) |


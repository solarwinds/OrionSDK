---
id: Statistics
slug: Statistics
---

# Cortex.Orion.Interface.Statistics

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
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReceiveBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TransmitBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReceiveUtilizationPercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TransmitUtilizationPercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReceiveErrors | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TransmitErrors | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ReceiveDiscards | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TransmitDiscards | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Cortex.Orion.Interface](./../Cortex.Orion/Interface) | Defined by relationship Cortex.Orion.InterfaceToStatistics (System.Hosting) |


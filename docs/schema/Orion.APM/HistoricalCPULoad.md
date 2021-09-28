---
id: HistoricalCPULoad
slug: HistoricalCPULoad
---

# Orion.APM.HistoricalCPULoad

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents historical data for CPU load.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Date | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the component availability in percent. | everyone |
| ComponentStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component status. | everyone |
| MinPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum CPU usage in percent. | everyone |
| AvgPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average CPU usage in percent. | everyone |
| MaxPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum CPU usage in percent. | everyone |
| ApplicationAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the application availability. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains historical data for CPU load entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHistoricalCPULoadHosting (System.Hosting) |


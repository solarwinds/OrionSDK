---
id: HistoricalMemory
slug: HistoricalMemory
---

# Orion.APM.HistoricalMemory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents historical data for memory usage.

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
| MinPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum memory usage in percent. | everyone |
| AvgPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average memory usage in percent. | everyone |
| MaxPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum memory usage in percent. | everyone |
| MinMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum memory usage. | everyone |
| AvgMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average memory usage. | everyone |
| MaxMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum memory usage. | everyone |
| MinPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum virtual memory usage in percent. | everyone |
| AvgPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average virtual memory usage in percent. | everyone |
| MaxPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum virtual memory usage in percent. | everyone |
| MinVirtualMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum virtual memory used. | everyone |
| AvgVirtualMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average virtual memory used. | everyone |
| MaxVirtualMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum virtual memory used. | everyone |
| ApplicationAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the application availability. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains historical data for memory usage entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHistoricalMemoryHosting (System.Hosting) |


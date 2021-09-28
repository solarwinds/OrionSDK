---
id: ForecastMetrics
slug: ForecastMetrics
---

# Orion.ForecastMetrics

SolarWinds Information Service 2020.2 Schema Documentation Index

Global settings for forecasting entities (e.g. CPULoad). Global settings include global thresholds, UsePeakValue flag, etc.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceDataEntityName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UsePeakValues | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ThresholdType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Icon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WarningThresholdSettingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CriticalThresholdSettingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CapacityThresholdSettingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ForecastCapacity | [Orion.ForecastCapacity](./../Orion/ForecastCapacity) | Defined by relationship Orion.ForecastCapacityHostsForecastMetrics (System.Reference) |


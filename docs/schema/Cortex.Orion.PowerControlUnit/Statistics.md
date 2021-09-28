---
id: Statistics
slug: Statistics
---

# Cortex.Orion.PowerControlUnit.Statistics

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
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BatteryPackCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BatteryCapacity | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BatteryTemperature | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeOnBattery | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReplaceIndicator | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| BasicBatteryStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OutputStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OutputPercentLoad | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RunTimeRemaining | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LastFailCause | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PowerControlUnit | [Cortex.Orion.PowerControlUnit](./../Cortex.Orion/PowerControlUnit) | Defined by relationship Cortex.Orion.PowerControlUnitToStatistics (System.Hosting) |


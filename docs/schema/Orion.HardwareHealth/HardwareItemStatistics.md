---
id: HardwareItemStatistics
slug: HardwareItemStatistics
---

# Orion.HardwareHealth.HardwareItemStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Item Statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| HardwareItemID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Item Base. | everyone |
| Availability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double value containing availability. | everyone |
| MinValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double value containing min value. | everyone |
| MaxValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double value containing max value | everyone |
| AvgValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double value containing average value | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status. | everyone |
| StatusCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status count. | everyone |
| OriginalStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a original status. | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing message. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItem | [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemStatistics (System.Hosting) |


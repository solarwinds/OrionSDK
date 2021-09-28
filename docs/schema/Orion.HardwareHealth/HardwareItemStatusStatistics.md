---
id: HardwareItemStatusStatistics
slug: HardwareItemStatusStatistics
---

# Orion.HardwareHealth.HardwareItemStatusStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Item Status Statistics.

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
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status. | everyone |
| StatusCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of status count. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItem | [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemStatusStatistics (System.Hosting) |


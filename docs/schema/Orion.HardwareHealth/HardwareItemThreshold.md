---
id: HardwareItemThreshold
slug: HardwareItemThreshold
---

# Orion.HardwareHealth.HardwareItemThreshold

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Item Thresholds.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Item Base. | everyone |
| Warning | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value indicates the warning threshold for entity. | everyone |
| Critical | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value indicates the critical threshold for entity. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareItem | [Orion.HardwareHealth.HardwareItemBase](./../Orion.HardwareHealth/HardwareItemBase) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemThreshold (System.Hosting) |

## Verbs

### SetThreshold

Sets thresholds for given sensors.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### ClearThresholds

Clear thresholds for given sensors.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


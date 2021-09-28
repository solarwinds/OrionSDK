---
id: Thresholds
slug: Thresholds
---

# Orion.VIM.Thresholds

SolarWinds Information Service 2020.2 Schema Documentation Index

VMware Threshold

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ThresholdID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Warning | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| High | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Maximum | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ThresholdType | [Orion.VIM.ThresholdTypes](./../Orion.VIM/ThresholdTypes) | Defined by relationship Orion.VIM.ThresholdTypesToThreshold (System.Reference) |
| ThresholdType | [Orion.VIM.ThresholdTypes](./../Orion.VIM/ThresholdTypes) | Defined by relationship Orion.VIM.ThresholdTypesToThreshold (System.Reference) |


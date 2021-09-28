---
id: ThresholdsNames
slug: ThresholdsNames
---

# Orion.ThresholdsNames

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ThresholdOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Unit | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DefaultThresholdOperator | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RecalculationNeeded | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ThresholdsLevelSettings | [Orion.ThresholdsLevelSettings](./../Orion/ThresholdsLevelSettings) | Defined by relationship Orion.ThresholdsNamesHostsThresholdsLevelSettings (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Thresholds | [Orion.Thresholds](./../Orion/Thresholds) | Defined by relationship Orion.ThresholdsHostsThresholdsNames (System.Hosting) |


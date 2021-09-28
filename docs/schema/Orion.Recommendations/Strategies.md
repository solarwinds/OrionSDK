---
id: Strategies
slug: Strategies
---

# Orion.Recommendations.Strategies

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides information about strategies configured by available modules.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| StrategyID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Strategy ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Module | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Module | everyone |
| StrategiesGroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Strategies Group ID | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Enabled | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendations | [Orion.Recommendations.RecommendationsBase](./../Orion.Recommendations/RecommendationsBase) | Defined by relationship Orion.Recommendations.RecommendationsToStrategies (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StrategiesGroup | [Orion.Recommendations.StrategiesGroup](./../Orion.Recommendations/StrategiesGroup) | Defined by relationship Orion.Recommendations.StrategiesGroupsToStrategies (System.Reference) |


---
id: StrategiesGroup
slug: StrategiesGroup
---

# Orion.Recommendations.StrategiesGroup

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides information about strategy groups configured by available modules.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| StrategiesGroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Strategies Group ID | everyone |
| Module | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Module | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Strategies | [Orion.Recommendations.Strategies](./../Orion.Recommendations/Strategies) | Defined by relationship Orion.Recommendations.StrategiesGroupsToStrategies (System.Reference) |


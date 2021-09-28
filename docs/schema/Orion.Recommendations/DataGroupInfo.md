---
id: DataGroupInfo
slug: DataGroupInfo
---

# Orion.Recommendations.DataGroupInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides information about data groups available in the environment.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Data Group ID | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Data Group Type | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Data Group Name | everyone |
| HasEnoughData | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | True if last recommendation recomputation had enough historical data | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendation | [Orion.Recommendations.RecommendationsBase](./../Orion.Recommendations/RecommendationsBase) | Defined by relationship Orion.Recommendations.RecommendationsBaseReferencesDataGroupInfo (System.Reference) |
| Job | [Orion.Recommendations.Jobs](./../Orion.Recommendations/Jobs) | Defined by relationship Orion.Recommendations.JobReferencesDataGroupInfo (System.Reference) |


---
id: RecommendationsBase
slug: RecommendationsBase
---

# Orion.Recommendations.RecommendationsBase

SolarWinds Information Service 2020.2 Schema Documentation Index

Base entity holding recommendations information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RecommendationID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Recommendation ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description | everyone |
| GroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Group ID | everyone |
| Priority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Priority | everyone |
| ComputedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Computed Time | everyone |
| JobID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Job Identifier | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status | everyone |
| BatchID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Batch ID | everyone |
| RecommendationKind | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Kind | everyone |
| Tags | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Tags | everyone |
| StrategyID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Strategy ID | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataGroup | [Orion.Recommendations.DataGroupInfo](./../Orion.Recommendations/DataGroupInfo) | Defined by relationship Orion.Recommendations.RecommendationsBaseReferencesDataGroupInfo (System.Reference) |
| Justification | [Orion.Recommendations.Justifications](./../Orion.Recommendations/Justifications) | Defined by relationship Orion.Recommendations.RecommendationsBaseHostsJustification (System.Hosting) |
| Batch | [Orion.Batching.Batches](./../Orion.Batching/Batches) | Defined by relationship Orion.Recommendations.RecommendationsBaseReferencesBatch (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Strategy | [Orion.Recommendations.Strategies](./../Orion.Recommendations/Strategies) | Defined by relationship Orion.Recommendations.RecommendationsToStrategies (System.Reference) |


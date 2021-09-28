---
id: Dependencies
slug: Dependencies
---

# Orion.Recommendations.Dependencies

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides information about recommendation dependencies.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RecommendationID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Recommendation ID | everyone |
| DependencyID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Dependency ID | everyone |
| Order | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Order | everyone |
| Reason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Reason | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendation | [Orion.Recommendations.ActiveRecommendations](./../Orion.Recommendations/ActiveRecommendations) | Defined by relationship Orion.Recommendations.RecommendationReferencesDependencies (System.Reference) |


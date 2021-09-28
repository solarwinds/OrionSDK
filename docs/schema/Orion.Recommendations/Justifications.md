---
id: Justifications
slug: Justifications
---

# Orion.Recommendations.Justifications

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides access to recommendations justifications.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RecommendationID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Recommendation ID | everyone |
| Data | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Data | everyone |
| RiskFull | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | RiskFull | everyone |
| RiskShort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | RiskShort | everyone |
| Resolution | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Resolution | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendation | [Orion.Recommendations.RecommendationsBase](./../Orion.Recommendations/RecommendationsBase) | Defined by relationship Orion.Recommendations.RecommendationsBaseHostsJustification (System.Hosting) |


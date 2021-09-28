---
id: Actions
slug: Actions
---

# Orion.Recommendations.Actions

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides access to all actions which belong to recommendations.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ActionID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Action ID | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type | everyone |
| Action | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Action Data | everyone |
| RecommendationID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Recommendation ID | everyone |
| Primary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Primary Action | everyone |
| Order | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Order | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description | everyone |
| Optional | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Optional | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status | everyone |
| FailureMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Failure Message | everyone |
| DateStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Started | everyone |
| DateFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Finished | everyone |
| BatchID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Batch ID | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendation | [Orion.Recommendations.ActiveRecommendations](./../Orion.Recommendations/ActiveRecommendations) | Defined by relationship Orion.Recommendations.ActiveRecommendationHostsActions (System.Hosting) |


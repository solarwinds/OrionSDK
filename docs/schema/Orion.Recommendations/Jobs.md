---
id: Jobs
slug: Jobs
---

# Orion.Recommendations.Jobs

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides information about computation jobs.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| JobID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Job ID | everyone |
| DataGroupID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Data Group ID | everyone |
| DateStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Job Started Date | everyone |
| DateFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Job Finished Data | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Job Status | everyone |
| RecommendationKind | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Kind | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DataGroup | [Orion.Recommendations.DataGroupInfo](./../Orion.Recommendations/DataGroupInfo) | Defined by relationship Orion.Recommendations.JobReferencesDataGroupInfo (System.Reference) |


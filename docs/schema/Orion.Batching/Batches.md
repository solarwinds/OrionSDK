---
id: Batches
slug: Batches
---

# Orion.Batching.Batches

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides access to batches (running, scheduled, finished, cancelled).

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| BatchID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Batch ID | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status | everyone |
| DateStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Started | everyone |
| DateFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Finished | everyone |
| ScheduledDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Scheduled Date | everyone |
| FailureMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Failure Message | everyone |
| StopOnFailure | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Stop on Failure | everyone |
| DependencyID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Dependency ID | everyone |
| UserID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | UserID | everyone |
| CancelationUserID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Cancellation User ID | everyone |
| CancelationReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Cancelation Reason | everyone |
| RevertBatchID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Revert Batch ID | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Action | [Orion.Batching.Actions](./../Orion.Batching/Actions) | Defined by relationship Orion.Batching.BatchHostsAction (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recommendation | [Orion.Recommendations.RecommendationsBase](./../Orion.Recommendations/RecommendationsBase) | Defined by relationship Orion.Recommendations.RecommendationsBaseReferencesBatch (System.Reference) |


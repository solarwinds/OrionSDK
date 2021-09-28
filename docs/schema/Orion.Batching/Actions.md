---
id: Actions
slug: Actions
---

# Orion.Batching.Actions

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides access to all actions which belong to batches.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Batch Action ID | everyone |
| BatchID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Batch ID | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status | everyone |
| DateStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Start Date | everyone |
| DateFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Finish Date | everyone |
| FailureMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Failure Message | everyone |
| Action | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Serialized Action | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Action Description | everyone |
| Order | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Batch action order | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Batch | [Orion.Batching.Batches](./../Orion.Batching/Batches) | Defined by relationship Orion.Batching.BatchHostsAction (System.Hosting) |


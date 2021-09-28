---
id: PollEntries
slug: PollEntries
---

# Orion.SCM.PollEntries

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents poll on particular SCM node, recorded.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where changes are collected. | everyone |
| ElementID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of ProfileElement entity. | everyone |
| PollTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of the poll (when data arrived to the poller). | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Type of the poll entry. Options are: 0 (Unknown), 1 (File), 2 (Registry), 4 (ParsedFile), 5 (SwisQuery), 6 (PowerShell), 8 (Script). | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SCMNode | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.SCMPollEntriesReferencesSCMNodes (System.Reference) |


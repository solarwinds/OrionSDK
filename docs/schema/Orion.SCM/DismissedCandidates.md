---
id: DismissedCandidates
slug: DismissedCandidates
---

# Orion.SCM.DismissedCandidates

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity provides Agent and Profile candidates the user does not want to see in the Candidates for monitoring widget.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,delete | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DismissedCandidateID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of this entity. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Node which is candidate for monitoring. | everyone |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Profile which is candidate for monitoring. | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Type of candidate. Options are: 0 (Agent), 1 (Profile). | everyone |


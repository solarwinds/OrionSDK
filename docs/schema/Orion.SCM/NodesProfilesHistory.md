---
id: NodesProfilesHistory
slug: NodesProfilesHistory
---

# Orion.SCM.NodesProfilesHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents history of assigned profiles.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of the entity. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Node where the profile is assigned. | everyone |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Profile which is assigned. | everyone |
| Assigned | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of profile assignment. | everyone |
| Unassigned | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of profile unassignment. | everyone |


---
id: NodesProfilesArchive
slug: NodesProfilesArchive
---

# Orion.SCM.NodesProfilesArchive

SolarWinds Information Service 2020.2 Schema Documentation Index

Unlike "Orion.SCM.NodesProfilesHistory", this entity contains only the most recent record of a Profile unassigned from a given Node.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Node where the profile is assigned. | everyone |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Profile which is assigned. | everyone |
| Assigned | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of profile assignment. | everyone |
| Unassigned | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of profile unassignment. | everyone |


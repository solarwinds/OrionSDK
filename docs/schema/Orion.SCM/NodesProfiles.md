---
id: NodesProfiles
slug: NodesProfiles
---

# Orion.SCM.NodesProfiles

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents mapping table for M:N relationship between SCM Nodes and SCM Profiles.

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
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Node where the profile is assigned. | everyone |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Profile which is assigned. | everyone |
| Assigned | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of profile assignment. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SCMNode | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship NodeReferencesOrion.SCM.NodesProfiles (System.Reference) |
| Profile | [Orion.SCM.Profiles](./../Orion.SCM/Profiles) | Defined by relationship ProfileReferencesOrion.SCM.NodesProfiles (System.Reference) |


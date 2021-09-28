---
id: Baseline
slug: Baseline
---

# Orion.SCM.Baseline

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents base line. Base line serves as base compare point.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| BaselineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of the baseline. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Node of the baseline. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of the baseline. All elements in the base line contain state at this moment. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.NodesReferencesBaseline (System.Reference) |

## Verbs

### SetBaseline

Create or update baseline and snapshot all related data so that they are not touched by maintenance processes.

#### Access control

everyone


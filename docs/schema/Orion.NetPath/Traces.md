---
id: Traces
slug: Traces
---

# Orion.NetPath.Traces

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains the path details as compressed Json. Each entry contains all traces for an associated test. There is one test for a given service, probe, and probing interval.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ExecutedAt | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndpointServiceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CompressedTraces | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServiceAssignment | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesTraces (System.Reference) |


---
id: Performances
slug: Performances
---

# Orion.NetPath.Performances

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains packet loss and latency information for nodes and edges.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndpointServiceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ObjectType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Status | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| RttMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RttMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RttAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RawRttMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RawRttMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RawRttAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLossMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLossMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLossAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Usage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BandwidthMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BandwidthMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BandwidthAvg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServiceAssignment | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesPerformances (System.Reference) |


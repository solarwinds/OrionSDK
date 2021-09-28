---
id: Tests
slug: Tests
---

# Orion.NetPath.Tests

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains probing results, including the summary and graph displayed to the user.

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
| ProbeStatus | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| CompletionRatio | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| UniqueEdgeCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UniquePathCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalTraceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalEdgeCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortClosedTraceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestUnreachedTraceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DnsFailureTraceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RouteChangeCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EdgeChangeCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SentPackets | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LostPackets | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConnectionBased | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Rtt | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RttMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Status | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Graph | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServiceAssignment | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesTests (System.Reference) |


---
id: QoeStatistics
slug: QoeStatistics
---

# Orion.DPI.QoeStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ObservationTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RecordCount | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RecordCountART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgNRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinNRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxNRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| RecordCountNRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Ingress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgIngressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinIngressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxIngressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Egress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgEgressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinEgressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxEgressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Transactions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgTransactionsPerMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MinTransactionsPerMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaxTransactionsPerMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.DPI.Applications](./../Orion.DPI/Applications) | Defined by relationship Orion.DPI.ApplicationsToQoeStatistics (System.Reference) |
| Probe | [Orion.DPI.Probes](./../Orion.DPI/Probes) | Defined by relationship Orion.DPI.ProbesToQoeStatistics (System.Reference) |


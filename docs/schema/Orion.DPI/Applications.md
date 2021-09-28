---
id: Applications
slug: Applications
---

# Orion.DPI.Applications

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| DiscoveryMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProtocolID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RiskLevel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| RiskLevelDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductivityRating | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ProductivityRatingDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Filter | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AdminStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FilterSyntax | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastDiscoveryDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastDiscoveryProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| ART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| NRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| Ingress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| IngressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| Egress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| EgressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| DataVolume | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DataVolumePerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Transactions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| TransactionsPerMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.DPI.QoeStatistics](./../Orion.DPI/QoeStatistics) | Defined by relationship Orion.DPI.ApplicationsToQoeStatistics (System.Reference) |
| Thresholds | [Orion.DPI.ApplicationsThresholdsForAlerting](./../Orion.DPI/ApplicationsThresholdsForAlerting) | Defined by relationship Orion.DPI.ApplicationsToThresholds (System.Reference) |
| Settings | [Orion.DPI.ApplicationSettings](./../Orion.DPI/ApplicationSettings) | Defined by relationship Orion.DPI.ApplicationToSettings (System.Reference) |
| ApplicationProtocol | [Orion.DPI.ApplicationProtocols](./../Orion.DPI/ApplicationProtocols) | Defined by relationship Orion.DPI.ApplicationToProtocol (System.Reference) |
| Category | [Orion.DPI.ApplicationCategories](./../Orion.DPI/ApplicationCategories) | Defined by relationship Orion.DPI.ApplicationToCategory (System.Reference) |
| ApplicationAssignment | [Orion.DPI.ApplicationAssignments](./../Orion.DPI/ApplicationAssignments) | Defined by relationship Orion.DPI.ApplicationsToApplicationAssignments (System.Reference) |


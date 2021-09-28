---
id: ApplicationsThresholdsForAlerting
slug: ApplicationsThresholdsForAlerting
---

# Orion.DPI.ApplicationsThresholdsForAlerting

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ARTWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ARTCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| NRTWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| NRTCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DataVolumeWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DataVolumeCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TransactionsWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TransactionsCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.DPI.Applications](./../Orion.DPI/Applications) | Defined by relationship Orion.DPI.ApplicationsToThresholds (System.Reference) |


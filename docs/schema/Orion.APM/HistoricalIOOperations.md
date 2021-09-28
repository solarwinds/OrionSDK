---
id: HistoricalIOOperations
slug: HistoricalIOOperations
---

# Orion.APM.HistoricalIOOperations

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents historical data for IO operations.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Date | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| MinIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum IO read operations per second. | everyone |
| AvgIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average IO read operations per second. | everyone |
| MaxIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum IO read operations per second. | everyone |
| MinIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum IO write operations per second. | everyone |
| AvgIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average IO write operations per second. | everyone |
| MaxIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum IO write operations per second. | everyone |
| MinIOTotalOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains minimum IO total operations per second. | everyone |
| AvgIOTotalOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains average IO total operations per second. | everyone |
| MaxIOTotalOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains maximum IO total operations per second. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains historical data for IO operations entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsHistoricalIOOperations (System.Hosting) |


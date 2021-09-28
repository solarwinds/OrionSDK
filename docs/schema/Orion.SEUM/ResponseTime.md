---
id: ResponseTime
slug: ResponseTime
---

# Orion.SEUM.ResponseTime

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Response times information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction id. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains time stamp. | everyone |
| MinDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal duration. | everyone |
| MaxDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal duration. | everyone |
| AvgDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average duration. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains status. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains availability percentage. | everyone |
| Screenshot | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains screenshot. | everyone |
| RawHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains response HTML as RAW. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains records count. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The bolean value that specifies if archive. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StepResponseTimes | [Orion.SEUM.StepResponseTime](./../Orion.SEUM/StepResponseTime) | Defined by relationship Orion.SEUM.ResponseTimeReferencesStepResponseTime (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Transaction | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.TransactionReferencesResponseTime (System.Reference) |


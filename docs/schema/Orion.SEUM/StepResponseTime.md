---
id: StepResponseTime
slug: StepResponseTime
---

# Orion.SEUM.StepResponseTime

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Step response time information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction step id. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains time stamp. | everyone |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction id. | everyone |
| MinDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal duration. | everyone |
| MaxDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal duration. | everyone |
| AvgDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average duration. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains availability percentage. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains status. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains step response error message. | everyone |
| ScreenshotId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains screenshot id. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains records count. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The bolean value that specifies if is archive. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LargeData | [Orion.SEUM.StepResponseTimeLargeData](./../Orion.SEUM/StepResponseTimeLargeData) | Defined by relationship Orion.SEUM.StepResponseTimeHostsLargeData (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Step | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTime (System.Reference) |
| TransactionResponseTime | [Orion.SEUM.ResponseTime](./../Orion.SEUM/ResponseTime) | Defined by relationship Orion.SEUM.ResponseTimeReferencesStepResponseTime (System.Reference) |


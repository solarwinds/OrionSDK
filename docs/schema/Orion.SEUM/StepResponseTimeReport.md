---
id: StepResponseTimeReport
slug: StepResponseTimeReport
---

# Orion.SEUM.StepResponseTimeReport

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Steps response time report information.

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
| MinDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal duration. | everyone |
| MaxDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal duration. | everyone |
| AvgDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average duration. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains availability percentage. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains step response error message. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains records count. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Step | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTimeReport (System.Reference) |


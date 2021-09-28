---
id: TransactionSteps
slug: TransactionSteps
---

# Orion.SEUM.TransactionSteps

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Transaction steps information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction step. | everyone |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction. | everyone |
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains recording id. | everyone |
| StepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains step id. | everyone |
| StepGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains additional identifier. | everyone |
| WarningThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains warning treshold. | everyone |
| CriticalThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains critical treshold. | everyone |
| OptimalThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains optimal treshold. | everyone |
| LastDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains last duration. | everyone |
| LastErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step last error message. | everyone |
| LastDateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains last duration. | everyone |
| LastPlayedUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains last played. | everyone |
| ScreenshotId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains screenshot id. | everyone |
| ScreenshotDateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains screenshot date time. | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step Orion column id. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction details url. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LargeData | [Orion.SEUM.TransactionStepLargeData](./../Orion.SEUM/TransactionStepLargeData) | Defined by relationship Orion.SEUM.TransactionStepHostsLargeData (System.Hosting) |
| ResponseTimes | [Orion.SEUM.StepResponseTime](./../Orion.SEUM/StepResponseTime) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTime (System.Reference) |
| ResponseTimeReports | [Orion.SEUM.StepResponseTimeReport](./../Orion.SEUM/StepResponseTimeReport) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTimeReport (System.Reference) |
| Requests | [Orion.SEUM.TransactionStepRequests](./../Orion.SEUM/TransactionStepRequests) | Defined by relationship Orion.SEUM.TransactionStepReferenesStepRequests (System.Reference) |
| ResponseTimesDetail | [Orion.SEUM.StepResponseTimeDetail](./../Orion.SEUM/StepResponseTimeDetail) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTimeDetail (System.Reference) |
| WebUri | [Orion.SEUM.TransactionStepWebUri](./../Orion.SEUM/TransactionStepWebUri) | Defined by relationship Orion.SEUM.TransactionStepHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Step | [Orion.SEUM.RecordingSteps](./../Orion.SEUM/RecordingSteps) | Defined by relationship Orion.SEUM.StepReferencesTransactionSteps (System.Reference) |
| RelyTransactions | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.Rely.TransactionsToSteps (System.Reliance) |
| Transaction | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.TransactionHostsTransactionSteps (System.Hosting) |


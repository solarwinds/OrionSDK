---
id: Transactions
slug: Transactions
---

# Orion.SEUM.Transactions

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Transactions information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction id. | everyone |
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains recording id. | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of agent. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction name. | everyone |
| Frequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction frequency. | everyone |
| JobId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains additional identifier. | everyone |
| LastDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains last duration. | everyone |
| LastDateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains last time stamp. | everyone |
| LastPlayedUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains last played. | everyone |
| WarningThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains warning treshold. | everyone |
| CriticalThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains critical treshold. | everyone |
| LastErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction last error message. | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction Orion column id. | everyone |
| LastModificationUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains last modification. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if transaction is unmanaged. | everyone |
| IsEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if transaction is enabled. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction details url. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ResponseTimes | [Orion.SEUM.ResponseTime](./../Orion.SEUM/ResponseTime) | Defined by relationship Orion.SEUM.TransactionReferencesResponseTime (System.Reference) |
| ResponseTimeReports | [Orion.SEUM.ResponseTimeReport](./../Orion.SEUM/ResponseTimeReport) | Defined by relationship Orion.SEUM.TransactionReferencesResponseTimeReport (System.Reference) |
| ResponseTimesDetail | [Orion.SEUM.ResponseTimeDetail](./../Orion.SEUM/ResponseTimeDetail) | Defined by relationship Orion.SEUM.TransactionReferencesResponseTimeDetail (System.Reference) |
| RunParameters | [Orion.SEUM.TransactionRunParameters](./../Orion.SEUM/TransactionRunParameters) | Defined by relationship Orion.SEUM.TransactionReferencesTransactionRunParameters (System.Reference) |
| CustomProperties | [Orion.SEUM.TransactionCustomProperties](./../Orion.SEUM/TransactionCustomProperties) | Defined by relationship Orion.SEUM.TransactionHostsCustomProperties (System.Hosting) |
| RelySteps | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.Rely.TransactionsToSteps (System.Reliance) |
| Steps | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionHostsTransactionSteps (System.Hosting) |
| WebUri | [Orion.SEUM.TransactionWebUri](./../Orion.SEUM/TransactionWebUri) | Defined by relationship Orion.SEUM.TransactionHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agent | [Orion.SEUM.Agents](./../Orion.SEUM/Agents) | Defined by relationship Orion.SEUM.AgentHostsTransactions (System.Hosting) |
| Recording | [Orion.SEUM.Recordings](./../Orion.SEUM/Recordings) | Defined by relationship Orion.SEUM.RecordingReferencesTransactions (System.Reference) |

## Verbs

### Unmanage

Verb to unmanage transactionnetObjectIdstart time when transaction is not managedend time when transaction is not managedindicates whether remanage time is relative to unmanage time

#### Access control

everyone

### Remanage

Verb to remanage transactionnetObjetId

#### Access control

everyone

### Create

Verb to create transactionId of the recording to be run in transactionId of the agent that will run the transactionReturns transaction id.

#### Access control

everyone


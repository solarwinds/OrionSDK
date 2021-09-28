---
id: TransactionRunParameters
slug: TransactionRunParameters
---

# Orion.SEUM.TransactionRunParameters

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Response times information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction id. | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains type. | everyone |
| Key | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction run parameter key. | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction run parameter value. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Transaction | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.TransactionReferencesTransactionRunParameters (System.Reference) |


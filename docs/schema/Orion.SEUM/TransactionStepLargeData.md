---
id: TransactionStepLargeData
slug: TransactionStepLargeData
---

# Orion.SEUM.TransactionStepLargeData

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Transactions steps for large data information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction step id. | everyone |
| Screenshot | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains screenshot. | everyone |
| Thumbnail | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains thumbnail. | everyone |
| RawHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step HTML as RAW for large data. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TransactionStep | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionStepHostsLargeData (System.Hosting) |


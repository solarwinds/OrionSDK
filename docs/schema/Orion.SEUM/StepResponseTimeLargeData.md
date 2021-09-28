---
id: StepResponseTimeLargeData
slug: StepResponseTimeLargeData
---

# Orion.SEUM.StepResponseTimeLargeData

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Steps response time for large data information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction step id. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains time stamp. | everyone |
| Screenshot | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains screenshot. | everyone |
| Thumbnail | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains thumbnail. | everyone |
| RawHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains step response HTML as RAW for large data. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StepResponseTime | [Orion.SEUM.StepResponseTime](./../Orion.SEUM/StepResponseTime) | Defined by relationship Orion.SEUM.StepResponseTimeHostsLargeData (System.Hosting) |


---
id: ResponseTimeDetail
slug: ResponseTimeDetail
---

# Orion.SEUM.ResponseTimeDetail

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Response time detail information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction id. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The unique date representation of response time. | everyone |
| Duration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains duration. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains status. | everyone |
| Screenshot | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The array of bytes that contains screenshot. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains availability percentage. | everyone |
| RawHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains response HTML as RAW. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The bolean value that specifies if archive. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StepResponseTimes | [Orion.SEUM.StepResponseTimeDetail](./../Orion.SEUM/StepResponseTimeDetail) | Defined by relationship Orion.SEUM.ResponseTimeDetailReferencesStepResponseTimeDetail (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Transaction | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.TransactionReferencesResponseTimeDetail (System.Reference) |


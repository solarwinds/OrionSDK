---
id: StepResponseTimeDetail
slug: StepResponseTimeDetail
---

# Orion.SEUM.StepResponseTimeDetail

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Step response time detail information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction step. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The unique date representation of step response time. | everyone |
| TransactionId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction id. | everyone |
| Duration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains duration. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains availability percentage. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains status. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains step response error message. | everyone |
| ScreenshotId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains screenshot id. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The bolean value that specifies if is archive. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LargeData | [Orion.SEUM.StepResponseTimeDetailLargeData](./../Orion.SEUM/StepResponseTimeDetailLargeData) | Defined by relationship Orion.SEUM.StepResponseTimeDetailHostsLargeData (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Step | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionStepReferencesStepResponseTimeDetail (System.Reference) |
| TransactionResponseTime | [Orion.SEUM.ResponseTimeDetail](./../Orion.SEUM/ResponseTimeDetail) | Defined by relationship Orion.SEUM.ResponseTimeDetailReferencesStepResponseTimeDetail (System.Reference) |


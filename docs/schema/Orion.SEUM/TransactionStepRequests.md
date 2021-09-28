---
id: TransactionStepRequests
slug: TransactionStepRequests
---

# Orion.SEUM.TransactionStepRequests

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Transaction step requests information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TransactionStepRequestId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction step request. | everyone |
| TransactionStepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction step. | everyone |
| RequestIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains request index. | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step request url. | everyone |
| MimeType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step request mime type. | everyone |
| StatusCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains status code. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains size. | everyone |
| RequestBeginMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains request begin time in ms. | everyone |
| DNSBeginMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains DNS begin time in ms. | everyone |
| ConnectionBeginMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains connection begin time in ms. | everyone |
| SendBeginMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains send begin time in ms. | everyone |
| SendEndMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains send end time in ms. | everyone |
| ReceiveBeginMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains receive begin time in ms. | everyone |
| ReceiveEndMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains receive time end time in ms. | everyone |
| BlockedDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains blocked duration time in ms. | everyone |
| DNSResolutionDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains DNS resolution duration time in ms. | everyone |
| ConnectionDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains connection duration time in ms. | everyone |
| SendDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains send duration time in ms. | everyone |
| TimeToFirstByteDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains time to first byte duration time in ms. | everyone |
| DownloadDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains download duration time in ms. | everyone |
| TotalDurationMs | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains total duration time in ms. | everyone |
| StepFullName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step request full name. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains transaction step request details url. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TransactionStep | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.TransactionStepReferenesStepRequests (System.Reference) |


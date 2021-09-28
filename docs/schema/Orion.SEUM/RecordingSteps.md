---
id: RecordingSteps
slug: RecordingSteps
---

# Orion.SEUM.RecordingSteps

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Recordings steps information.

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
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of recording. | everyone |
| StepId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of recording step. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains recording step name. | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains recording step url. | everyone |
| StepOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains recording step order. | everyone |
| Guid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains recording step additional identifier. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains recording step description. | everyone |
| PlaybackCommands | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains recording step playback commands. | everyone |
| WarningThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains recording step warning treshold. | everyone |
| CriticalThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains recording step critical treshold. | everyone |
| ControlActionId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The integer value that contains recording step control action id. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TransactionSteps | [Orion.SEUM.TransactionSteps](./../Orion.SEUM/TransactionSteps) | Defined by relationship Orion.SEUM.StepReferencesTransactionSteps (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recording | [Orion.SEUM.Recordings](./../Orion.SEUM/Recordings) | Defined by relationship Orion.SEUM.RecordingHostsRecordingSteps (System.Hosting) |


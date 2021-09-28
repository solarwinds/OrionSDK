---
id: Recordings
slug: Recordings
---

# Orion.SEUM.Recordings

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Recordings information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of recording. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains recording name. | everyone |
| Guid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains additional recording identifier. | everyone |
| CreationDateUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains recording creation time. | everyone |
| LastUpdateUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains recording last update time. | everyone |
| RequiresInteractiveSession | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if recording requires interactive session. | everyone |
| ProbeType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains probe type. | everyone |
| Version | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Version of a recording. Determines if recording is supported. | everyone |
| Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Resolution width of the recording. | everyone |
| Height | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Resolution height of the recording. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Transactions | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.RecordingReferencesTransactions (System.Reference) |
| Steps | [Orion.SEUM.RecordingSteps](./../Orion.SEUM/RecordingSteps) | Defined by relationship Orion.SEUM.RecordingHostsRecordingSteps (System.Hosting) |
| CustomProperties | [Orion.SEUM.RecordingCustomProperties](./../Orion.SEUM/RecordingCustomProperties) | Defined by relationship Orion.SEUM.RecordingHostsCustomProperties (System.Hosting) |
| Authentication | [Orion.SEUM.RecordingAuthentications](./../Orion.SEUM/RecordingAuthentications) | Defined by relationship Orion.SEUM.RecordingHostsRecordingAuthentications (System.Hosting) |
| Certificate | [Orion.SEUM.RecordingCertificates](./../Orion.SEUM/RecordingCertificates) | Defined by relationship Orion.SEUM.RecordingHostsRecordingCertificates (System.Hosting) |

## Verbs

### Load

Verb to load recordingRecordingIdReturns recording object.

#### Access control

everyone

### Exists

Verb to check if recording existsrecordingGuidReturns boolean indicating whether the recording exists

#### Access control

everyone

### Save

Verb to save recordingRecording object to saveReturns recording id integer.

#### Access control

everyone

### Import

Verb to import recording from fileRecording file contentRecording namePassword to decipher the fileReturns recording id integer.

#### Access control

everyone


---
id: RecordingAuthentications
slug: RecordingAuthentications
---

# Orion.SEUM.RecordingAuthentications

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents username and password credentials stored in the recording.

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
| CredentialsId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of a credential pair. | everyone |
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of a recording. | everyone |
| Host | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Domain name of the website that requires credentials. | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains username for authentication. | everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains password for authentication. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recording | [Orion.SEUM.Recordings](./../Orion.SEUM/Recordings) | Defined by relationship Orion.SEUM.RecordingHostsRecordingAuthentications (System.Hosting) |


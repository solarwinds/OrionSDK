---
id: RecordingCertificates
slug: RecordingCertificates
---

# Orion.SEUM.RecordingCertificates

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the certificates information used within recording.

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
| CertificateId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of a certificate. | everyone |
| RecordingId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of a recording. | everyone |
| CommonName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that represents the certificate's common name. | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains url of the webpage that issued the certificate. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Recording | [Orion.SEUM.Recordings](./../Orion.SEUM/Recordings) | Defined by relationship Orion.SEUM.RecordingHostsRecordingCertificates (System.Hosting) |


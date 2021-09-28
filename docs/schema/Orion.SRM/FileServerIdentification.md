---
id: FileServerIdentification
slug: FileServerIdentification
---

# Orion.SRM.FileServerIdentification

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains other information about each of the File Servers - mainly for storing additional IP addresses

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FileServerIdentificationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FileServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FileServer | [Orion.SRM.FileServers](./../Orion.SRM/FileServers) | Defined by relationship Orion.SRM.FileServersReferencesFileServerIdentification (System.Reference) |


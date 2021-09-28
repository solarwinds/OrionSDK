---
id: FileServers
slug: FileServers
---

# Orion.SRM.FileServers

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all File Servers

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FileServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FileShares | [Orion.SRM.FileShares](./../Orion.SRM/FileShares) | Defined by relationship Orion.SRM.FileServersReferencesFileShares (System.Reference) |
| FileServerIdentifications | [Orion.SRM.FileServerIdentification](./../Orion.SRM/FileServerIdentification) | Defined by relationship Orion.SRM.FileServersReferencesFileServerIdentification (System.Reference) |


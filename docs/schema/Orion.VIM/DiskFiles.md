---
id: DiskFiles
slug: DiskFiles
---

# Orion.VIM.DiskFiles

SolarWinds Information Service 2020.2 Schema Documentation Index

Disk File

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DiskFileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Disk File ID | everyone |
| DataStoreID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | DataStore ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Size | everyone |
| LastModifiedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last Modified Time | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | File Type | everyone |
| VirtualDiskID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Disk ID | everyone |
| Orphaned | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Orphaned | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Snapshots | [Orion.VIM.Snapshots](./../Orion.VIM/Snapshots) | Defined by relationship Orion.VIM.SnapshotReferencesDiskFile (System.Reference) |
| Snapshots | [Orion.VIM.Snapshots](./../Orion.VIM/Snapshots) | Defined by relationship Orion.VIM.SnapshotReferencesDiskFile (System.Reference) |


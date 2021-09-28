---
id: Snapshots
slug: Snapshots
---

# Orion.VIM.Snapshots

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual Machine Snapshot

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SnapshotID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Snapshot ID | everyone |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Virtual Machine ID | everyone |
| SnapshotIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Snapshot Identifier | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date Created | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description | everyone |
| PowerState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Power State | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DiskFiles | [Orion.VIM.DiskFiles](./../Orion.VIM/DiskFiles) | Defined by relationship Orion.VIM.SnapshotReferencesDiskFile (System.Reference) |
| DiskFiles | [Orion.VIM.DiskFiles](./../Orion.VIM/DiskFiles) | Defined by relationship Orion.VIM.SnapshotReferencesDiskFile (System.Reference) |


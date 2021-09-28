---
id: FileShares
slug: FileShares
---

# Orion.SRM.FileShares

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all File Shares

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FileShareID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FileServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UserCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Path | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Quota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Free | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Used | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyVolume | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.Rely.SRM.FileSharesRelyOnVolumes (System.Reliance) |
| CustomProperties | [Orion.SRM.FileShareCustomProperties](./../Orion.SRM/FileShareCustomProperties) | Defined by relationship Orion.SRM.FileShareHostsCustomProperties (System.Hosting) |
| ServerVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.SRM.FileSharesReferencesServerVolumes (System.Reference) |
| Datastores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.SRM.FileSharesReferencesDatastores (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyServerVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.Rely.SRM.ServerVolumesRelyOnFileShares (System.Reliance) |
| RelyDatastores | [Orion.VIM.Datastores](./../Orion.VIM/Datastores) | Defined by relationship Orion.Rely.SRM.DatastoresRelyOnFileShares (System.Reliance) |
| Volume | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.SRM.VolumesReferencesFileShares (System.Reference) |
| FileServer | [Orion.SRM.FileServers](./../Orion.SRM/FileServers) | Defined by relationship Orion.SRM.FileServersReferencesFileShares (System.Reference) |


---
id: VServers
slug: VServers
---

# Orion.SRM.VServers

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all VServers

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StorageArrayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RootVolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UserCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CapacityAllocated | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CapacitySubscribed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSOther | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOSizeTotal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeRead | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeWrite | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CapacityRunoutSlope | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| CapacityRunoutOffset | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| CapacityRunout | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CapacityRunoutDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyStorageArrayForVServer | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.Rely.SRM.VServersRelyOnStorageArrays (System.Reliance) |
| IOPSTotalThreshold | [Orion.SRM.VServerIOPSTotalThreshold](./../Orion.SRM/VServerIOPSTotalThreshold) | Defined by relationship Orion.VServersHostsVServerIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.SRM.VServerIOPSReadThreshold](./../Orion.SRM/VServerIOPSReadThreshold) | Defined by relationship Orion.VServersHostsVServerIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.SRM.VServerIOPSWriteThreshold](./../Orion.SRM/VServerIOPSWriteThreshold) | Defined by relationship Orion.VServersHostsVServerIOPSWriteThreshold (System.Hosting) |
| IOPSOtherThreshold | [Orion.SRM.VServerIOPSOtherThreshold](./../Orion.SRM/VServerIOPSOtherThreshold) | Defined by relationship Orion.VServersHostsVServerIOPSOtherThreshold (System.Hosting) |
| IOSizeTotalThreshold | [Orion.SRM.VServerIOSizeTotalThreshold](./../Orion.SRM/VServerIOSizeTotalThreshold) | Defined by relationship Orion.VServersHostsVServerIOSizeTotalThreshold (System.Hosting) |
| IOSizeReadThreshold | [Orion.SRM.VServerIOSizeReadThreshold](./../Orion.SRM/VServerIOSizeReadThreshold) | Defined by relationship Orion.VServersHostsVServerIOSizeReadThreshold (System.Hosting) |
| IOSizeWriteThreshold | [Orion.SRM.VServerIOSizeWriteThreshold](./../Orion.SRM/VServerIOSizeWriteThreshold) | Defined by relationship Orion.VServersHostsVServerIOSizeWriteThreshold (System.Hosting) |
| BytesPSTotalThreshold | [Orion.SRM.VServerBytesPSTotalThreshold](./../Orion.SRM/VServerBytesPSTotalThreshold) | Defined by relationship Orion.VServersHostsVServerBytesPSTotalThreshold (System.Hosting) |
| BytesPSReadThreshold | [Orion.SRM.VServerBytesPSReadThreshold](./../Orion.SRM/VServerBytesPSReadThreshold) | Defined by relationship Orion.VServersHostsVServerBytesPSReadThreshold (System.Hosting) |
| BytesPSWriteThreshold | [Orion.SRM.VServerBytesPSWriteThreshold](./../Orion.SRM/VServerBytesPSWriteThreshold) | Defined by relationship Orion.VServersHostsVServerBytesPSWriteThreshold (System.Hosting) |
| Volumes | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.SRM.VServersReferencesVolumes (System.Reference) |
| CapacityStatistics | [Orion.SRM.VServerCapacityStatistics](./../Orion.SRM/VServerCapacityStatistics) | Defined by relationship Orion.SRM.VServersReferencesVServerCapacityStatistics (System.Hosting) |
| Statistics | [Orion.SRM.VServerStatistics](./../Orion.SRM/VServerStatistics) | Defined by relationship Orion.SRM.VServersReferencesVServerStatistics (System.Hosting) |
| CustomProperties | [Orion.SRM.VServersCustomProperties](./../Orion.SRM/VServersCustomProperties) | Defined by relationship Orion.SRM.VServersHostsCustomProperties (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyVolumes | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.Rely.SRM.VolumesRelyOnVServers (System.Reliance) |
| RelyServerVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.Rely.SRM.ServerVolumesRelyOnVservers (System.Reliance) |
| StorageArray | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.SRM.StorageArraysReferencesVServer (System.Reference) |
| RootVolume | [Orion.SRM.Volumes](./../Orion.SRM/Volumes) | Defined by relationship Orion.SRM.VolumesReferencesVServer (System.Reference) |


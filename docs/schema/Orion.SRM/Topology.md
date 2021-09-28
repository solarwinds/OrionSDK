---
id: Topology
slug: Topology
---

# Orion.SRM.Topology

SolarWinds Information Service 2020.2 Schema Documentation Index

Stores topology info

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StorageArrayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NetObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Manual | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageArray | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.SRM.StorageArraysReferencesTopology (System.Reference) |
| Volumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.VolumesReferencesTopology (System.Reference) |


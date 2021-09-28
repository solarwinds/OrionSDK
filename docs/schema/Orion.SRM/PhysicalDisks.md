---
id: PhysicalDisks
slug: PhysicalDisks
---

# Orion.SRM.PhysicalDisks

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all physical disks

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PhysicalDiskID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StorageArrayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OperStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Spare | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageArray | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.SRM.StorageArraysReferencesPhysicalDisks (System.Reference) |

## Verbs

### GetCountOfElementsPerEngineForLicensing

ToDo

#### Access control

everyone


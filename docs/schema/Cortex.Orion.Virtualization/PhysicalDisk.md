---
id: PhysicalDisk
slug: PhysicalDisk
---

# Cortex.Orion.Virtualization.PhysicalDisk

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PhysicalDiskId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsSsd | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ScsiDiskType_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScsiDiskType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Capacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Health | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedVSanDiskGroup | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSanDiskGroup | [Cortex.Orion.Virtualization.VSanDiskGroup](./../Cortex.Orion.Virtualization/VSanDiskGroup) | Defined by relationship Cortex.Orion.Virtualization.VSanDiskGroupToPhysicalDisks (System.Reference) |


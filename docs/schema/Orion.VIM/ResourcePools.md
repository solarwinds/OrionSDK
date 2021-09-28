---
id: ResourcePools
slug: ResourcePools
---

# Orion.VIM.ResourcePools

SolarWinds Information Service 2020.2 Schema Documentation Index

VMResource Pool

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ResourcePoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | VMResourcePool ID | everyone |
| ManagedObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| CpuMaxUsage | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Maximum Usage | everyone |
| CpuOverallUsage | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Overall Usage | everyone |
| CpuReservationUsedForVM | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Reservation Used For VM | everyone |
| CpuReservationUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Reservation Used | everyone |
| MemMaxUsage | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Maximum Usage | everyone |
| MemOverallUsage | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Overall Usage | everyone |
| MemReservationUsedForVM | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Reservation Used For VM | everyone |
| MemReservationUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Reservation Used | everyone |
| LastModifiedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last Modified Time | everyone |
| CpuExpandable | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | CPU Expandable | everyone |
| CpuLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Limit | everyone |
| CpuReservation | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU Reservation | everyone |
| CpuShareLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | CPU Share Level | everyone |
| CpuShareCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | CPU Share Count | everyone |
| MemExpandable | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Memory Expandable | everyone |
| MemLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Limit | everyone |
| MemReservation | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory Reservation | everyone |
| MemShareLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Memory Share Level | everyone |
| MemShareCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Memory Share Count | everyone |
| ConfigStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Config Status | everyone |
| OverallStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Overall Status | everyone |
| ManagedStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Managed Status | everyone |
| ClusterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VCenterID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HostID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentResourcePoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineReferencesResourcePool (System.Reference) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.VCentersToResourcePoolsMappingReference (System.Reference) |
| VirtualMachines | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.VirtualMachineReferencesResourcePool (System.Reference) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.VCentersToResourcePoolsMappingReference (System.Reference) |


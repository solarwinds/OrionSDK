---
id: VSanMetrics
slug: VSanMetrics
---

# Cortex.Orion.Virtualization.VirtualMachineDisk.VSanMetrics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ElementId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| LatencyRead | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyWrite | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LatencyTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualMachineDisk | [Cortex.Orion.Virtualization.VirtualMachineDisk](./../Cortex.Orion.Virtualization/VirtualMachineDisk) | Defined by relationship Cortex.Orion.Virtualization.VirtualMachineDiskToVSanMetrics (System.Hosting) |
| VirtualDisk | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualDiskToVirtualDiskVSanStatistics (System.Reference) |
| VirtualDisk | [Orion.VIM.VirtualDisks](./../Orion.VIM/VirtualDisks) | Defined by relationship Orion.VIM.VirtualDiskToVirtualDiskVSanStatistics (System.Reference) |


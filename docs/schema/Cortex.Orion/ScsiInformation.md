---
id: ScsiInformation
slug: ScsiInformation
---

# Cortex.Orion.ScsiInformation

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
| ScsiTargetId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScsiLunId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScsiPortId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScsiControllerId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ScsiPortOffset | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelatedVolume | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Volume | [Cortex.Orion.Volume](./../Cortex.Orion/Volume) | Defined by relationship Cortex.Orion.VolumeToScsiInformation (System.Hosting) |


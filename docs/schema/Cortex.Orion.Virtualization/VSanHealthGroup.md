---
id: VSanHealthGroup
slug: VSanHealthGroup
---

# Cortex.Orion.Virtualization.VSanHealthGroup

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
| HealthGroupName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HealthGroupId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HealthStatus_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HealthStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedVSan | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VSan | [Cortex.Orion.Virtualization.VSan](./../Cortex.Orion.Virtualization/VSan) | Defined by relationship Cortex.Orion.Virtualization.VSanToVSanHealthGroups (System.Hosting) |


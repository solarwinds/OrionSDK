---
id: Alarm
slug: Alarm
---

# Cortex.Orion.Virtualization.Alarm

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
| ManagedObjectId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsDeleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| RelatedHost | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedVCenter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TriggeredAlarmStates | [Cortex.Orion.Virtualization.TriggeredAlarmState](./../Cortex.Orion.Virtualization/TriggeredAlarmState) | Defined by relationship Cortex.Orion.Virtualization.AlarmToTriggeredAlarmStates (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Host | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.AlarmsToHost (System.Reference) |
| VCenter | [Cortex.Orion.Virtualization.VCenter](./../Cortex.Orion.Virtualization/VCenter) | Defined by relationship Cortex.Orion.Virtualization.AlarmsToVCenter (System.Reference) |


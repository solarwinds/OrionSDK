---
id: TriggeredAlarmState
slug: TriggeredAlarmState
---

# Cortex.Orion.Virtualization.TriggeredAlarmState

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
| Acknowledged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AcknowledgedByUser | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AcknowledgedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Timestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedAlarm | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedCluster | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedDataCenter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedDatastore | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedHost | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedVirtualMachine | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Alarm | [Cortex.Orion.Virtualization.Alarm](./../Cortex.Orion.Virtualization/Alarm) | Defined by relationship Cortex.Orion.Virtualization.AlarmToTriggeredAlarmStates (System.Hosting) |
| Cluster | [Cortex.Orion.Virtualization.Cluster](./../Cortex.Orion.Virtualization/Cluster) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToCluster (System.Reference) |
| DataCenter | [Cortex.Orion.Virtualization.DataCenter](./../Cortex.Orion.Virtualization/DataCenter) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToDataCenter (System.Reference) |
| Datastore | [Cortex.Orion.Virtualization.Datastore](./../Cortex.Orion.Virtualization/Datastore) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToDatastore (System.Reference) |
| Host | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToHost (System.Reference) |
| VirtualMachine | [Cortex.Orion.Virtualization.VirtualMachine](./../Cortex.Orion.Virtualization/VirtualMachine) | Defined by relationship Cortex.Orion.Virtualization.TriggeredAlarmStatesToVirtualMachine (System.Reference) |


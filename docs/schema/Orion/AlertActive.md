---
id: AlertActive
slug: AlertActive
---

# Orion.AlertActive

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all currently triggered alerts for individual swis entities.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertActiveID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| AlertObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Acknowledged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AcknowledgedBy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AcknowledgedDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AcknowledgedNote | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggeredDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TriggeredMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NumberOfNotes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastExecutedEscalationLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertObjects | [Orion.AlertObjects](./../Orion/AlertObjects) | Defined by relationship Orion.AlertActiveToAlertObjects (System.Reference) |
| AlertActiveObjects | [Orion.AlertActiveObjects](./../Orion/AlertActiveObjects) | Defined by relationship Orion.AlertActiveToAlertActiveObjects (System.Reference) |

## Verbs

### Acknowledge

Acknowledge active alerts, based on array of alert active ids and desired notes.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |

### Unacknowledge

Unacknowledge active alerts, based on array of alert active ids.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |

### ClearAlert

Delete active alert from database. Manual alert reset

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |

### AppendNote

Appends note to Alert object.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |


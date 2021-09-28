---
id: AlertStatus
slug: AlertStatus
---

# Orion.AlertStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertDefID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ActiveObject | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| WorkingState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ObjectName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TriggerTimeOffset | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TriggerCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ResetTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Acknowledged | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| AcknowledgedBy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AcknowledgedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AlertNotes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Notes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Verbs

### Acknowledge

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |

### AcknowledgeAlert

ToDo

#### Access control

everyone

### AddNote

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |


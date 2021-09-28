---
id: Events
slug: Events
---

# Orion.Events

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EventID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EventTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| NetworkNode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetObjectValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EventType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Acknowledged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NetObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TimeStamp | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.EnginesHostsEvents (System.Reference) |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsEvents (System.Reference) |
| EventTypeProperties | [Orion.EventTypes](./../Orion/EventTypes) | Defined by relationship Orion.EventTypeHostsEvents (System.Reference) |

## Verbs

### Acknowledge

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |


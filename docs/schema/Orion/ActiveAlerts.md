---
id: ActiveAlerts
slug: ActiveAlerts
---

# Orion.ActiveAlerts

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ObjectType | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| ObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ObjectName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EventMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Monitoredproperty | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CurrentValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResetValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertNotes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ExpireTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsActiveAlerts (System.Reference) |


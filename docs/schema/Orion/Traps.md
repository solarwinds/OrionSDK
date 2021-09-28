---
id: Traps
slug: Traps
---

# Orion.Traps

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.LogEntity](./../Orion/LogEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TrapID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Community | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Tag | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Acknowledged | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Hostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TrapType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ColorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeStamp | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ObservationSeverity | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TrapVarbinds | [Orion.TrapVarbinds](./../Orion/TrapVarbinds) | Defined by relationship Orion.TrapHostsTrapVarbinds (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsTraps (System.Reference) |


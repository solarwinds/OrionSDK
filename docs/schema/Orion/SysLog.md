---
id: SysLog
slug: SysLog
---

# Orion.SysLog

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
| MessageID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Acknowledged | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SysLogFacility | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SysLogSeverity | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Hostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MessageType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysLogTag | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FirstIPInMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SecIPInMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MacInMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TimeStamp | [System.Byte[]](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ObservationSeverity | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsSyslogs (System.Reference) |

## Verbs

### Acknowledge

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | clearEvents |


---
id: WindowsEvent
slug: WindowsEvent
---

# Orion.APM.WindowsEvent

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents windows event.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| LogFile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains log file name. | everyone |
| RecordNumber | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains record number. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| EventType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The long value that contains event type. | everyone |
| EventCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that contains event code. | everyone |
| TimeGeneratedUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date when event was generated in Utc. | everyone |
| ComputerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains computer name. | everyone |
| SourceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains source name. | everyone |
| User | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains user name. | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains event message. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsWindowsEvent (System.Hosting) |


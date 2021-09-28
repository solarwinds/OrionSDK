---
id: LogEntrySecondarySources
slug: LogEntrySecondarySources
---

# Orion.OLM.LogEntrySecondarySources

SolarWinds Information Service 2020.2 Schema Documentation Index

Secondary sources for messages. Messages have relation to Orion nodes and in some cases they can also have secondary source, which describes the source in more details.
In case of VMware event types it can be ESX host name, for example.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogEntrySecondarySourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of secondary source. | everyone |
| Identity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Unique identity of secondary source. | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Secondary source label can be hostname or any other description of the source. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Events | [Orion.OLM.LogEntry](./../Orion.OLM/LogEntry) | Defined by relationship Orion.OLMLogEntrySecondarySources (System.Reference) |


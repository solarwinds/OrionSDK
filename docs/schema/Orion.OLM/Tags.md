---
id: Tags
slug: Tags
---

# Orion.OLM.Tags

SolarWinds Information Service 2020.2 Schema Documentation Index

Custom and out of the box tags which can be assigned to log entries.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogEntryTagID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Identifier of the tag. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the tag. | everyone |
| ColorIndex | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | Color defined by index in internal log color map. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Events | [Orion.OLM.LogEntry](./../Orion.OLM/LogEntry) | Defined by relationship Orion.OLMLogEntryTags (System.Reference) |


---
id: LogEntryType
slug: LogEntryType
---

# Orion.OLM.LogEntryType

SolarWinds Information Service 2020.2 Schema Documentation Index

Types of log sources, for example Syslog, Trap ... 

Each type has retention period after which messages are deleted.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| read,update,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogEntryTypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the log entry type. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Translated name of log entry type in case that product is installed in different than English language. | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of log entry type. | everyone |
| RetentionPeriodInDays | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Retention period for the log entry type. | read,invoke: everyone&amp;lt;br/&amp;gt;read,update,invoke: admin |
| DetailPageEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether a detail page is enabled for messages of this type. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Events | [Orion.OLM.LogEntry](./../Orion.OLM/LogEntry) | Defined by relationship Orion.OLMLogEntryTypes (System.Reference) |


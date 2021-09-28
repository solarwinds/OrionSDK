---
id: LogEntry
slug: LogEntry
---

# Orion.OLM.LogEntry

SolarWinds Information Service 2020.2 Schema Documentation Index

Stored messages or events.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogEntryID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Identifier of message. | everyone |
| LogEntryTypeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of message type that is Syslog, Trap, ... | everyone |
| LogEntryLevelID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of log entry level (severity). | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of mapped node. | everyone |
| MessageSourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of message source from which the message was sent. | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time when the message was received. | everyone |
| MessageDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time when the message was created. Usually it's parsed from the message itself. | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Stored message. | everyone |
| Level | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Translated log entry level name in case that product is installed in different than English language. | everyone |
| LevelKey | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Log entry level name. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LogType | [Orion.OLM.LogEntryType](./../Orion.OLM/LogEntryType) | Defined by relationship Orion.OLMLogEntryTypes (System.Reference) |
| FieldValues | [Orion.OLM.LogEntryFieldValue](./../Orion.OLM/LogEntryFieldValue) | Defined by relationship Orion.OLMLogEntryFieldValues (System.Reference) |
| Tags | [Orion.OLM.Tags](./../Orion.OLM/Tags) | Defined by relationship Orion.OLMLogEntryTags (System.Reference) |
| SecondarySources | [Orion.OLM.LogEntrySecondarySources](./../Orion.OLM/LogEntrySecondarySources) | Defined by relationship Orion.OLMLogEntrySecondarySources (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| LogMessageSource | [Orion.OLM.MessageSources](./../Orion.OLM/MessageSources) | Defined by relationship Orion.OLMMessageSourcesLogEntry (System.Reference) |

## Verbs

### UidMaxForDate

For internal use only.

#### Access control

everyone

### UidMinForDate

For internal use only.

#### Access control

everyone

### UidExtractDate

For internal use only.

#### Access control

everyone


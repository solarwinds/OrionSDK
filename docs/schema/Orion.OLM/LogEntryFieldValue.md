---
id: LogEntryFieldValue
slug: LogEntryFieldValue
---

# Orion.OLM.LogEntryFieldValue

SolarWinds Information Service 2020.2 Schema Documentation Index

Values of log entry fields.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogEntryFieldID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Identifier of the field. | everyone |
| LogEntryFieldValueID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Identifier of the log entry and field relation. | everyone |
| LogEntryID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Identifier of log entry. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Translated name of the field in case that product is installed in different than English language. | everyone |
| TextValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Text value in case the field is string based. | everyone |
| NumericValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Numeric value in case the field is numeric. | everyone |
| DateTimeValue | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time in case the field is time related. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Event | [Orion.OLM.LogEntry](./../Orion.OLM/LogEntry) | Defined by relationship Orion.OLMLogEntryFieldValues (System.Reference) |


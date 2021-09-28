---
id: ElementErrors
slug: ElementErrors
---

# Orion.SCM.Results.ElementErrors

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents polling errors which occur while discovering and polling Profile Elements.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where error was collected. | everyone |
| ElementID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of ProfileElement entity. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime when the error occurred. | everyone |
| Type | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Type of the error. Options are: 0 (Unknown), 1 (Access denied), 2 (Unauthorized access), 3 (Parsed file not found), 4 (Parsing failed), 10 (Local file not exists),
      11 (script execution timeout), 12 (script execution error). | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Error message. | everyone |


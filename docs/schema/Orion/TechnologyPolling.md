---
id: TechnologyPolling
slug: TechnologyPolling
---

# Orion.TechnologyPolling

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TechnologyID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TechnologyPollingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Priority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.TechnologyPollingAssignments](./../Orion/TechnologyPollingAssignments) | Defined by relationship Orion.TechnologyPollingHostTechnologyPollingAssignments (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Technology | [Orion.Technology](./../Orion/Technology) | Defined by relationship Orion.TechnologyHostTechnologyPolling (System.Hosting) |


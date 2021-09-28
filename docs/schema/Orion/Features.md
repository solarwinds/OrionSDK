---
id: Features
slug: Features
---

# Orion.Features

SolarWinds Information Service 2020.2 Schema Documentation Index

Represents available orion features on orion installation.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Reports | [Orion.Report](./../Orion/Report) | Defined by relationship Orion.ReportOrionFeatures (System.Reference) |
| Events | [Orion.EventTypes](./../Orion/EventTypes) | Defined by relationship Orion.EventTypesOrionFeatures (System.Reference) |
| ViewGroup | [Orion.Web.ViewGroup](./../Orion.Web/ViewGroup) | Defined by relationship Orion.Web.ViewGroupOrionFeatures (System.Reference) |

## Verbs

### Refresh

Internal verb which enforce system to recalculate orion features

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


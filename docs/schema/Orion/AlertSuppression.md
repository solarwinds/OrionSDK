---
id: AlertSuppression
slug: AlertSuppression
---

# Orion.AlertSuppression

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains entities which do not trigger any alerts during the SuppressFrom-SuppressUntil time period.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SuppressFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SuppressUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Verbs

### SuppressAlerts

Do not trigger any alerts for entities defined in entityUris array during the suppressFrom-suppressUntil time period.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### ResumeAlerts

Alerts for entities defined in entityUris array will be triggered as usual.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### GetAlertSuppressionState

Get Alert Suppression State for provided list of entities.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | everyone |


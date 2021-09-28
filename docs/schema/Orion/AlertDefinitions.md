---
id: AlertDefinitions
slug: AlertDefinitions
---

# Orion.AlertDefinitions

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | manageAlerts |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertDefID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DOW | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerQuery | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerQueryDesign | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResetQuery | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResetQueryDesign | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SuppressionQuery | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SuppressionQueryDesign | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerSustained | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ResetSustained | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| LastExecuteTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ExecuteInterval | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BlockUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| LastErrorTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastError | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Reverted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Verbs

### RevertMigratedAlert

Sets alert definition Reverted property to true with means that alert will be processed by alerting service v1. Also sets Enable property based on parameter.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |


---
id: Alerts
slug: Alerts
---

# Orion.Alerts

SolarWinds Information Service 2020.2 Schema Documentation Index

Alerts created in Basic Alerts Manger.

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
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DOW | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NetObjects | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Trigger | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Reset | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Sustained | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TriggerSubjectTemplate | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggerMessageTemplate | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResetSubjectTemplate | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResetMessageTemplate | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Frequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EMailAddresses | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReplyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReplyAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LogFile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LogMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ShellTrigger | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ShellReset | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SuppressionType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Suppression | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertDefID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Reverted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Verbs

### MigrateAllBasicAlerts

This verb migrates all alerts created in Basic Alerts Manager to new data entities used in Alert Manager on Orion website.It returns list of Alert Migration Results which contains information about migrated Alerts.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### MigrateBasicAlert

This verb migrates alert created in Basic Alerts Manager to new data entities used in Alert Manager on Orion website.Id of Alert created in Basic Alerts Manager i.e. AlertID property of Orion.Alerts entity.It returns Alert Migration Result which contains information about migrated Alert.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


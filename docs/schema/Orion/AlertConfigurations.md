---
id: AlertConfigurations
slug: AlertConfigurations
---

# Orion.AlertConfigurations

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| read,update,invoke | allowDisableAlert |
| create,read,update,delete,invoke | manageAlerts |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertRefID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Frequency | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Trigger | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Reset | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Severity | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NotifyEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NotificationSettings | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastEdit | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CreatedBy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Category | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Canned | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CustomProperties | [Orion.AlertConfigurationsCustomProperties](./../Orion/AlertConfigurationsCustomProperties) | Defined by relationship Orion.AlertConfigurationsHostsCustomProperties (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertObject | [Orion.AlertObjects](./../Orion/AlertObjects) | Defined by relationship Orion.AlertObjectsToAlertConfigurations (System.Reference) |

## Verbs

### MigrateAllAdvancedAlerts

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### MigrateAdvancedAlert

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### MigrateAdvancedAlertFromXML

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Import

This verb imports alert into system from alert xml

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### Export

This verb exports alert definition

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |


---
id: ActionsProperties
slug: ActionsProperties
---

# Orion.ActionsProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |
| create,read,update,delete,invoke | manageAlerts |
| create,read,update,delete,invoke | manageReports |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PropertyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Action | [Orion.Actions](./../Orion/Actions) | Defined by relationship Orion.ActionsHostActionsProperties (System.Hosting) |


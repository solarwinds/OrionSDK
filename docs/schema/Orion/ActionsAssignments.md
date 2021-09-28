---
id: ActionsAssignments
slug: ActionsAssignments
---

# Orion.ActionsAssignments

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
| ActionAssignmentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnvironmentType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CategoryType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Properties | [Orion.ActionAssignmentProperties](./../Orion/ActionAssignmentProperties) | Defined by relationship Orion.AssignmentsHostActionAssignmentProperties (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Action | [Orion.Actions](./../Orion/Actions) | Defined by relationship Orion.ActionsHostActionsAssignments (System.Hosting) |


---
id: ActionAssignmentProperties
slug: ActionAssignmentProperties
---

# Orion.ActionAssignmentProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

Action properties per assignment to store values for shared actions

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
| ActionAssignmentPropertyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActionAssignmentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PropertyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.ActionsAssignments](./../Orion/ActionsAssignments) | Defined by relationship Orion.AssignmentsHostActionAssignmentProperties (System.Hosting) |


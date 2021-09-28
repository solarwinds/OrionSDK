---
id: Actions
slug: Actions
---

# Orion.Actions

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |
| read,invoke | allowDisableAlert |
| create,read,update,delete,invoke | manageAlerts |
| create,read,update,delete,invoke | manageReports |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActionTypeID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Title | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| SortOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Properties | [Orion.ActionsProperties](./../Orion/ActionsProperties) | Defined by relationship Orion.ActionsHostActionsProperties (System.Hosting) |
| Assignments | [Orion.ActionsAssignments](./../Orion/ActionsAssignments) | Defined by relationship Orion.ActionsHostActionsAssignments (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertIncident | [Orion.ESI.AlertIncident](./../Orion.ESI/AlertIncident) | Defined by relationship AlertIncidentToOrionActions (System.Reference) |

## Verbs

### DeleteActionsByAssignments

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### DeleteActionsByAssignmentsAndCategory

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### SaveActionsForAssignments

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | allowDisableAlert |
| invoke | manageAlerts |
| invoke | manageReports |

### UpdateAction

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### UpdateActionsProperties

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### UpdateActionsDescriptions

This verb updates actions descriptions after updating of actions properties.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### UpdateActionsFrequencies

This verb updates actions frequencies after multi editing of actions

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### TestAlertingAction

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageAlerts |

### TestReportingAction

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


---
id: AlertIncident
slug: AlertIncident
---

# Orion.ESI.AlertIncident

SolarWinds Information Service 2020.2 Schema Documentation Index

Abstract entity aggregating incidents provided by integrated incident services and related to Orion alerts.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InstanceID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| AlertObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IncidentID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertTriggerState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastTriggerTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IncidentNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IncidentUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AssignedTo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Actions | [Orion.Actions](./../Orion/Actions) | Defined by relationship AlertIncidentToOrionActions (System.Reference) |
| AlertObjects | [Orion.AlertObjects](./../Orion/AlertObjects) | Defined by relationship AlertIncidentToOrionAlertObjects (System.Reference) |
| IncidentIntegrations | [Orion.ESI.IncidentService](./../Orion.ESI/IncidentService) | Defined by relationship AlertIncidentToIncidentIntegration (System.Reference) |


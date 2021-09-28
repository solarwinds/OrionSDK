---
id: AlertObjects
slug: AlertObjects
---

# Orion.AlertObjects

SolarWinds Information Service 2020.2 Schema Documentation Index

Serve for tie Orion.AlertHistory and Orion.AlertActive with triggered entity and Orion.AlertConfiguration.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AlertID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityDetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityNetObjectId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedNodeUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelatedNodeDetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RelatedNodeCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RealEntityUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RealEntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TriggeredCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastTriggeredDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Context | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertNote | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertConfigurations | [Orion.AlertConfigurations](./../Orion/AlertConfigurations) | Defined by relationship Orion.AlertObjectsToAlertConfigurations (System.Reference) |
| AlertHistory | [Orion.AlertHistory](./../Orion/AlertHistory) | Defined by relationship Orion.AlertHistoryToAlertObjects (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertIncident | [Orion.ESI.AlertIncident](./../Orion.ESI/AlertIncident) | Defined by relationship AlertIncidentToOrionAlertObjects (System.Reference) |
| AlertActive | [Orion.AlertActive](./../Orion/AlertActive) | Defined by relationship Orion.AlertActiveToAlertObjects (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesReferencesAlertObjects (System.Reference) |


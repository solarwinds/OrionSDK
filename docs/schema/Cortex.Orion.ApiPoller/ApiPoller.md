---
id: ApiPoller
slug: ApiPoller
---

# Cortex.Orion.ApiPoller.ApiPoller

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RelatedEntityId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelatedEntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TemplateId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.ApiPoller.ApiPoller.Metrics](./../Cortex.Orion.ApiPoller.ApiPoller/Metrics) | Defined by relationship Cortex.Orion.ApiPoller.ApiPollerToMetrics (System.Hosting) |
| RequestDetails | [Cortex.Orion.ApiPoller.RequestDetails](./../Cortex.Orion.ApiPoller/RequestDetails) | Defined by relationship Cortex.Orion.ApiPoller.ApiPollerToRequestDetailsRelation (System.Hosting) |
| ValuesToMonitor | [Cortex.Orion.ApiPoller.ValueToMonitor](./../Cortex.Orion.ApiPoller/ValueToMonitor) | Defined by relationship Cortex.Orion.ApiPoller.ApiPollerToValueToMonitorRelation (System.Hosting) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Cortex.Orion.ApiPollerToNode (System.Reliance) |
| Template | [Orion.APIPoller.Templates](./../Orion.APIPoller/Templates) | Defined by relationship Cortex.Orion.ApiPollerToTemplate (System.Reference) |

## Verbs

### ApiPoller.CreateAPIPollersCommand

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.AssignToEngine

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.GetSupportedMetrics

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.InventoryNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.PollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.SetPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.StartRealTimePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Core.StopRealTimePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


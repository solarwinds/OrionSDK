---
id: Apic
slug: Apic
---

# Cortex.Orion.CiscoAci.Apic

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
| OrionNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpStatusThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CriticalStatusThreshold | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MonitoredClusterControllersWarningMessageIpAddresses | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedCredential | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedNode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationProfiles | [Cortex.Orion.CiscoAci.ApplicationProfile](./../Cortex.Orion.CiscoAci/ApplicationProfile) | Defined by relationship Cortex.Orion.CiscoAci.ApicToApplicationProfiles (System.Reference) |
| EndpointGroups | [Cortex.Orion.CiscoAci.EndpointGroup](./../Cortex.Orion.CiscoAci/EndpointGroup) | Defined by relationship Cortex.Orion.CiscoAci.ApicToEndpointGroups (System.Reference) |
| Fabric | [Cortex.Orion.CiscoAci.Fabric](./../Cortex.Orion.CiscoAci/Fabric) | Defined by relationship Cortex.Orion.CiscoAci.ApicToFabric (System.Hosting) |
| PhysicalEntities | [Cortex.Orion.CiscoAci.PhysicalEntity](./../Cortex.Orion.CiscoAci/PhysicalEntity) | Defined by relationship Cortex.Orion.CiscoAci.ApicToPhysicalEntities (System.Reference) |
| Tenants | [Cortex.Orion.CiscoAci.Tenant](./../Cortex.Orion.CiscoAci/Tenant) | Defined by relationship Cortex.Orion.CiscoAci.ApicToTenants (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Cortex.Orion.OrionNodeToApic (System.Hosting) |
| Credential | [Cortex.Orion.CiscoAci.CiscoAciCredential](./../Cortex.Orion.CiscoAci/CiscoAciCredential) | Defined by relationship Cortex.Orion.CiscoAci.ApicToCredential (System.Reference) |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.CiscoAci.NodeToApic (System.Reference) |

## Verbs

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

### Orion.CiscoAci.AssignAciPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.CiscoAci.GetPollInterval

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.CiscoAci.IsAciPollingAssigned

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.CiscoAci.SyncAciCredentialsWithOrion

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.CiscoAci.TestAciCredentials

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.CiscoAci.UnassignAciPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


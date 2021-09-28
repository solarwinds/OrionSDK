---
id: CloudAccount
slug: CloudAccount
---

# Cortex.Orion.NetMan.CloudMonitoring.CloudAccount

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
| OrionCloudAccountId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatisticsPollingInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UnprocessedRequestCost | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VirtualNetworkGatewaysPollingEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| MonitorApiRequestsEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CloudAccountType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingFlags | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastSuccessfulPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedCloudMonitoringCentralizedSettings | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AzureMonitoringCredential | [Cortex.Orion.NetMan.CloudMonitoring.AzureMonitoringCredential](./../Cortex.Orion.NetMan.CloudMonitoring/AzureMonitoringCredential) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudAccountToAzureMonitoringCredential (System.Hosting) |
| VirtualNetworks | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetwork](./../Cortex.Orion.NetMan.CloudMonitoring/VirtualNetwork) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudAccountToVirtualNetwork (System.Hosting) |
| VirtualNetworkGateways | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway](./../Cortex.Orion.NetMan.CloudMonitoring/VirtualNetworkGateway) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudAccountToVirtualNetworkGateway (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AzureCloudAccount | [Orion.Cloud.Azure.Accounts](./../Orion.Cloud.Azure/Accounts) | Defined by relationship Cortex.Cortex.Orion.NetMan.CloudMonitoring.CortexToOrionCloudAccount (System.Reference) |
| CloudMonitoringCentralizedSettings | [Cortex.Orion.NetMan.CloudMonitoring.CloudMonitoringCentralizedSettings](./../Cortex.Orion.NetMan.CloudMonitoring/CloudMonitoringCentralizedSettings) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudMonitoringCentralizedSettingsToCloudAccount (System.Reference) |

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

### Orion.NetMan.CloudMonitoring.CreateOrUpdateCloudAccount

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.NetMan.CloudMonitoring.GetCloudAccountState

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.NetMan.CloudMonitoring.RemoveCloudAccount

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


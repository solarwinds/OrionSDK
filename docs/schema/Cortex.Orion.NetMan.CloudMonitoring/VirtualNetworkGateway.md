---
id: VirtualNetworkGateway
slug: VirtualNetworkGateway
---

# Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway

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
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PublicIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GatewayType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InternalId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TunnelTrafficBytesIn | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TunnelTrafficBytesOut | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| PollingFlags | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollingStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastSuccessfulPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedCloudAccount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedVirtualNetwork | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway.Metrics](./../Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway/Metrics) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGatewayToMetrics (System.Hosting) |
| AvailabilityMetrics | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway.AvailabilityMetrics](./../Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway/AvailabilityMetrics) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGatewayToAvailabilityMetrics (System.Hosting) |
| OwnedConnections | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection](./../Cortex.Orion.NetMan.CloudMonitoring/VirtualNetworkConnection) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.SourceVirtualNetworkGatewayToVirtualNetworkConnection (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CloudAccount | [Cortex.Orion.NetMan.CloudMonitoring.CloudAccount](./../Cortex.Orion.NetMan.CloudMonitoring/CloudAccount) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.CloudAccountToVirtualNetworkGateway (System.Reference) |
| VirtualNetwork | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetwork](./../Cortex.Orion.NetMan.CloudMonitoring/VirtualNetwork) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkToVirtualNetworkGateway (System.Hosting) |

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


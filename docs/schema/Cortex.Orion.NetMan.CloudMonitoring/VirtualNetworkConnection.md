---
id: VirtualNetworkConnection
slug: VirtualNetworkConnection
---

# Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection

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
| ResourceGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgorithm | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IntegrityAlgorithm | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InternalId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TunnelTrafficBytesIn | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TunnelTrafficBytesOut | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
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
| RelatedSourceVirtualNetworkGateway | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection.Metrics](./../Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection/Metrics) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnectionToMetrics (System.Hosting) |
| AvailabilityMetrics | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection.AvailabilityMetrics](./../Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnection/AvailabilityMetrics) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkConnectionToAvailabilityMetrics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SourceVirtualNetworkGateway | [Cortex.Orion.NetMan.CloudMonitoring.VirtualNetworkGateway](./../Cortex.Orion.NetMan.CloudMonitoring/VirtualNetworkGateway) | Defined by relationship Cortex.Orion.NetMan.CloudMonitoring.SourceVirtualNetworkGatewayToVirtualNetworkConnection (System.Hosting) |

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


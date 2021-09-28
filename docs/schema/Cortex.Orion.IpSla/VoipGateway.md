---
id: VoipGateway
slug: VoipGateway
---

# Cortex.Orion.IpSla.VoipGateway

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

↳ [Cortex.Orion.PartitionedInstance](./../Cortex.Orion/PartitionedInstance)

↳ [Cortex.Orion.MonitoringElement](./../Cortex.Orion/MonitoringElement)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VoipGatewayId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsSuccess | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsRedirect | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsErrClient | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsErrServer | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsGlobalFail | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SipStatsRetry | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelatedNode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.IpSla.VoipGateway.Metrics](./../Cortex.Orion.IpSla.VoipGateway/Metrics) | Defined by relationship Cortex.Orion.IpSla.VoipGatewayToMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.IpSla.VoipGateway.Statistics](./../Cortex.Orion.IpSla.VoipGateway/Statistics) | Defined by relationship Cortex.Orion.IpSla.VoipGatewayToStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.IpSla.NodeToVoipGateway (System.Hosting) |

## Verbs

### Core.AddToCortex

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


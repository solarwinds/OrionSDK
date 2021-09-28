---
id: Container
slug: Container
---

# Cortex.Orion.Cman.Container

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
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ContainerId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpAddresses | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Command | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RestartCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HealthStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeDeleted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IsDeleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| StartedAt | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ContainerImageId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ContainerAgentId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Cpu | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Memory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
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
| CpuMetrics | [Cortex.Orion.Cman.Container.CpuMetrics](./../Cortex.Orion.Cman.Container/CpuMetrics) | Defined by relationship Cortex.Orion.Cman.ContainerToCpuMetrics (System.Hosting) |
| MemoryMetrics | [Cortex.Orion.Cman.Container.MemoryMetrics](./../Cortex.Orion.Cman.Container/MemoryMetrics) | Defined by relationship Cortex.Orion.Cman.ContainerToMemoryMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Cman.Container.Statistics](./../Cortex.Orion.Cman.Container/Statistics) | Defined by relationship Cortex.Orion.Cman.ContainerToStatistics (System.Hosting) |
| EnvironmentVariables | [Cortex.Orion.Cman.ContainerEnvironmentVariable](./../Cortex.Orion.Cman/ContainerEnvironmentVariable) | Defined by relationship Cortex.Orion.Cman.ContainerToEnvVar (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ContainerAgent | [Cortex.Orion.Cman.ContainerAgent](./../Cortex.Orion.Cman/ContainerAgent) | Defined by relationship Cortex.Orion.Cman.ContainerAgentToContainer (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesToCortexContainer (System.Hosting) |
| NodeRel | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.NodesToCortexContainer (System.Reliance) |

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


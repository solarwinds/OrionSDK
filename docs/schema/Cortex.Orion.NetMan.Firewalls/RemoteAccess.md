---
id: RemoteAccess
slug: RemoteAccess
---

# Cortex.Orion.NetMan.Firewalls.RemoteAccess

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
| Domain | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Username | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisconnectTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Lifetime | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| ComputerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VpnType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TunnelType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VirtualIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PublicIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| BpsIn | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BpsOut | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MbpsIn | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MbpsOut | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedFirewall | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.NetMan.Firewalls.RemoteAccess.Metrics](./../Cortex.Orion.NetMan.Firewalls.RemoteAccess/Metrics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.RemoteAccessToMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.NetMan.Firewalls.RemoteAccess.Statistics](./../Cortex.Orion.NetMan.Firewalls.RemoteAccess/Statistics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.RemoteAccessToStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Firewall | [Cortex.Orion.NetMan.Firewalls.Firewall](./../Cortex.Orion.NetMan.Firewalls/Firewall) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToRemoteAccesses (System.Hosting) |

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


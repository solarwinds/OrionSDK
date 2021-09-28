---
id: Firewall
slug: Firewall
---

# Cortex.Orion.NetMan.Firewalls.Firewall

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
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RequestInventory | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PollState_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentOsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedFirewallCentralizedSettings | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedNode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.NetMan.Firewalls.Firewall.Metrics](./../Cortex.Orion.NetMan.Firewalls.Firewall/Metrics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.NetMan.Firewalls.Firewall.Statistics](./../Cortex.Orion.NetMan.Firewalls.Firewall/Statistics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToStatistics (System.Hosting) |
| RemoteAccesses | [Cortex.Orion.NetMan.Firewalls.RemoteAccess](./../Cortex.Orion.NetMan.Firewalls/RemoteAccess) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToRemoteAccesses (System.Hosting) |
| Tunnels | [Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel](./../Cortex.Orion.NetMan.Firewalls/SiteToSiteTunnel) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToSiteToSiteTunnels (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Cortex.Orion.OrionNodeToFirewall (System.Hosting) |
| FirewallCentralizedSettings | [Cortex.Orion.NetMan.Firewalls.FirewallCentralizedSettings](./../Cortex.Orion.NetMan.Firewalls/FirewallCentralizedSettings) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallCentralizedSettingsToFirewall (System.Reference) |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.NetMan.Firewalls.NodeToFirewall (System.Reference) |

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

### Orion.NetMan.Firewalls.DisablePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.NetMan.Firewalls.EnablePolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.NetMan.Firewalls.GetAuthorizationKey

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### Orion.NetMan.Firewalls.IsPollingEnabled

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


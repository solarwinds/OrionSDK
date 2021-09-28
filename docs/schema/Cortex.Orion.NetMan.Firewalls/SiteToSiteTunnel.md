---
id: SiteToSiteTunnel
slug: SiteToSiteTunnel
---

# Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel

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
| LocalIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteIp | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TunnelId | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| BpsIn | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MbpsIn | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BpsOut | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MbpsOut | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EncryptionCipher | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HashAlgorithm | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SecurityZone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VirtualFirewall | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RemoteNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastStatusChanged | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IssueMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
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
| Metrics | [Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel.Metrics](./../Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel/Metrics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnelToMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel.Statistics](./../Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnel/Statistics) | Defined by relationship Cortex.Orion.NetMan.Firewalls.SiteToSiteTunnelToStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Firewall | [Cortex.Orion.NetMan.Firewalls.Firewall](./../Cortex.Orion.NetMan.Firewalls/Firewall) | Defined by relationship Cortex.Orion.NetMan.Firewalls.FirewallToSiteToSiteTunnels (System.Hosting) |

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


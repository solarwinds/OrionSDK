---
id: Node
slug: Node
---

# Cortex.Orion.Node

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
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ObjectSubType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SnmpPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SnmpVersion | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Fqdn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OsVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Uptime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| DiscoveryProfileId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatCollection | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PollInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SysObjectId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CpuPercentUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentMemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MemoryUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| Status_Value | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedHost | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedVCenter | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CpuMetrics | [Cortex.Orion.Node.CpuMetrics](./../Cortex.Orion.Node/CpuMetrics) | Defined by relationship Cortex.Orion.NodeToCpuMetrics (System.Hosting) |
| MemoryMetrics | [Cortex.Orion.Node.MemoryMetrics](./../Cortex.Orion.Node/MemoryMetrics) | Defined by relationship Cortex.Orion.NodeToMemoryMetrics (System.Hosting) |
| HealthMetrics | [Cortex.Orion.Node.HealthMetrics](./../Cortex.Orion.Node/HealthMetrics) | Defined by relationship Cortex.Orion.NodeToHealthMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Node.Statistics](./../Cortex.Orion.Node/Statistics) | Defined by relationship Cortex.Orion.NodeToStatistics (System.Hosting) |
| VoipGatewaySipTrunk | [Cortex.Orion.IpSla.VoipGatewaySipTrunk](./../Cortex.Orion.IpSla/VoipGatewaySipTrunk) | Defined by relationship Cortex.Orion.IpSla.NodeToVoipGatewaySipTrunk (System.Hosting) |
| VoipGateway | [Cortex.Orion.IpSla.VoipGateway](./../Cortex.Orion.IpSla/VoipGateway) | Defined by relationship Cortex.Orion.IpSla.NodeToVoipGateway (System.Hosting) |
| Apic | [Cortex.Orion.CiscoAci.Apic](./../Cortex.Orion.CiscoAci/Apic) | Defined by relationship Cortex.Orion.CiscoAci.NodeToApic (System.Reference) |
| Firewall | [Cortex.Orion.NetMan.Firewalls.Firewall](./../Cortex.Orion.NetMan.Firewalls/Firewall) | Defined by relationship Cortex.Orion.NetMan.Firewalls.NodeToFirewall (System.Reference) |
| Interfaces | [Cortex.Orion.Interface](./../Cortex.Orion/Interface) | Defined by relationship Cortex.Orion.NodeToInterfaces (System.Hosting) |
| CPUs | [Cortex.Orion.Cpu](./../Cortex.Orion/Cpu) | Defined by relationship Cortex.Orion.NodeToCpus (System.Hosting) |
| Credentials | [Cortex.Orion.Credential](./../Cortex.Orion/Credential) | Defined by relationship Cortex.Orion.NodeToCredentials (System.Reference) |
| PCUs | [Cortex.Orion.PowerControlUnit](./../Cortex.Orion/PowerControlUnit) | Defined by relationship Cortex.Orion.NodeToPCUs (System.Reference) |
| Volumes | [Cortex.Orion.Volume](./../Cortex.Orion/Volume) | Defined by relationship Cortex.Orion.NodeToVolumes (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Host | [Cortex.Orion.Virtualization.Host](./../Cortex.Orion.Virtualization/Host) | Defined by relationship Cortex.Orion.Virtualization.HostToNode (System.Reference) |
| VCenter | [Cortex.Orion.Virtualization.VCenter](./../Cortex.Orion.Virtualization/VCenter) | Defined by relationship Cortex.Orion.Virtualization.VCenterToNode (System.Reference) |

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


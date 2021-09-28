---
id: Engines
slug: Engines
---

# Orion.Engines

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains main poller and all additional pollers list.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,update,delete | system |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PrimaryServers | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| KeepAlive | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FailOverActive | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SysLogKeepAlive | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TrapsKeepAlive | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Restart | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Elements | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Nodes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Interfaces | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Volumes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Pollers | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxPollsPerSecond | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MaxStatPollsPerSecond | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| NodePollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| InterfacePollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| VolumePollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| NodeStatPollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| InterfaceStatPollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| VolumeStatPollInterval | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| LicensedElements | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LicenseKey | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CompanyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CustomerID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Evaluation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EvalDaysLeft | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| PackageName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EngineVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WindowsVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServicePack | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AvgCPUUtil | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| MemoryUtil | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PollingCompletion | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| StatPollInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BusinessLayerPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FIPSModeEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| MinutesSinceKeepAlive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceFailOverActive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceSysLogKeepAlive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceTrapsKeepAlive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceRestart | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceStartTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MasterEngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsFree | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agents | [Orion.AgentManagement.Agent](./../Orion.AgentManagement/Agent) | Defined by relationship Orion.AgentManagement.EngineReferencesAgent (System.Reference) |
| PoolMember | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.EnginesReferencesPoolMembers (System.Reference) |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NPM.NetPath.EnginesReferencesProbes (System.Reference) |
| NutanixDiscoveryMetadata | [Orion.Nutanix.DiscoveryMetadata](./../Orion.Nutanix/DiscoveryMetadata) | Defined by relationship Orion.Nutanix.DiscoveryMetadataReferencesPollingEngine (System.Reference) |
| AssignedNodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.EngineHostsNodes (System.Reference) |
| EngineProperties | [Orion.EngineProperties](./../Orion/EngineProperties) | Defined by relationship Orion.EnginesHostsEngineProperties (System.Hosting) |
| PollingUsage | [Orion.PollingUsage](./../Orion/PollingUsage) | Defined by relationship Orion.EnginesHostsPollingUsage (System.Hosting) |
| Events | [Orion.Events](./../Orion/Events) | Defined by relationship Orion.EnginesHostsEvents (System.Reference) |
| ReachabilityInfo | [Orion.ReachabilityInfo](./../Orion/ReachabilityInfo) | Defined by relationship Orion.EnginesReferencesReachabilityInfo (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNode | [IPAM.GroupNode](./../IPAM/GroupNode) | Defined by relationship IPAM.GroupNodeReferenceEngine (System.Reference) |
| FlowEngine | [Orion.Netflow.FlowEngines](./../Orion.Netflow/FlowEngines) | Defined by relationship Orion.Netflow.FlowEnginesReferencesEngines (System.Reference) |
| SEUMAgents | [Orion.SEUM.Agents](./../Orion.SEUM/Agents) | Defined by relationship Orion.SEUM.AgentReferencesEngine (System.Reference) |


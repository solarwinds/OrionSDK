---
id: OrionServers
slug: OrionServers
---

# Orion.OrionServers

SolarWinds Information Service 2020.2 Schema Documentation Index

Represents Orion servers (MPE, APE, AW).

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| OrionServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AgentAutoDeploy | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SWAKeepAlive | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SWAVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Details | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PoolMember | [Orion.HA.PoolMembers](./../Orion.HA/PoolMembers) | Defined by relationship Orion.OrionServersReferencesPoolMembers (System.Reference) |
| LicenseAssignments | [Orion.Licensing.LicenseAssignments](./../Orion.Licensing/LicenseAssignments) | Defined by relationship Orion.OrionServersReferencesLicenseAssignments (System.Reference) |
| ReachabilityInfo | [Orion.ReachabilityInfo](./../Orion/ReachabilityInfo) | Defined by relationship Orion.OrionServersReferencesReachabilityInfo (System.Reference) |
| SettingOverride | [Orion.SettingOverride](./../Orion/SettingOverride) | Defined by relationship Orion.EnginesReferencesSettingOverride (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsOrionServers (System.Reference) |


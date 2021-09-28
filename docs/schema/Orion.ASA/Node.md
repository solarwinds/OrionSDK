---
id: Node
slug: Node
---

# Orion.ASA.Node

SolarWinds Information Service 2020.2 Schema Documentation Index

List of ASA Nodes

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SystemID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ContextID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FirewallMode | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ConfigSyncState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ConnectionSyncState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| StandbyState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| HAMode | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| HAPeerNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastFailover | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HAOverallState | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| FirewallModeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConfigSyncStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionSyncStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StandbyStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HAModeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HAOverallStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionsInUse | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Context | [Orion.ASA.Context](./../Orion.ASA/Context) | Defined by relationship Orion.ASA.NodeReferencesASAContext (System.Reference) |
| SiteToSiteTunnels | [Orion.VPN.L2LTunnel](./../Orion.VPN/L2LTunnel) | Defined by relationship Orion.AsaDeviceHostsVpnSiteToSiteTunnels (System.Hosting) |
| RemoteAccessDetail | [Orion.ASA.RemoteAccessDetail](./../Orion.ASA/RemoteAccessDetail) | Defined by relationship Orion.AsaDeviceHostsASARemoteAccessDetail (System.Hosting) |
| RemoteAccessSessions | [Orion.ASA.RemoteAccessSessions](./../Orion.ASA/RemoteAccessSessions) | Defined by relationship Orion.AsaDeviceHostsASARemoteAccessSessions (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsASANode (System.Hosting) |
| System | [Orion.ASA.System](./../Orion.ASA/System) | Defined by relationship Orion.ASA.SystemReferencesASANode (System.Reference) |

## Verbs

### ExecuteCliCommand

Execute CLI command using SSH protocol on port 22Hostname or ip address of the target deviceUsername to login to the devicePassword used to login to the deviceActual command to be executed(optional) Enable password to access privileged mode

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


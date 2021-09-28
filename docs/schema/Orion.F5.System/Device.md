---
id: Device
slug: Device
---

# Orion.F5.System.Device

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductBuild | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductEdition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CPUActive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CPUTotal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsInMaintenanceMode | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsRedundant | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| FailoverStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| FailoverStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverStatusColor | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SyncStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SyncStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SyncStatusColor | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| In_Throughput | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Out_Throughput | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Connections | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ConnectionsNew | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| ConnectionsSSL | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastApiPollingError | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsPollerEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Stats | [Orion.F5.System.DeviceStats](./../Orion.F5.System/DeviceStats) | Defined by relationship Orion.F5.DeviceHostsDeviceStats (System.Hosting) |
| Modules | [Orion.F5.System.Module](./../Orion.F5.System/Module) | Defined by relationship Orion.F5DeviceHostsModules (System.Hosting) |
| VLANs | [Orion.F5.System.VLAN](./../Orion.F5.System/VLAN) | Defined by relationship Orion.F5DeviceHostsVLANs (System.Hosting) |
| Failovers | [Orion.F5.System.Failover](./../Orion.F5.System/Failover) | Defined by relationship Orion.F5DeviceHostsFailover (System.Hosting) |
| VirtualServers | [Orion.F5.LTM.VirtualServer](./../Orion.F5.LTM/VirtualServer) | Defined by relationship Orion.F5DeviceHostsVirtualServers (System.Hosting) |
| Pools | [Orion.F5.LTM.Pool](./../Orion.F5.LTM/Pool) | Defined by relationship Orion.F5DeviceHostsLTMPools (System.Hosting) |
| F5Servers | [Orion.F5.LTM.Server](./../Orion.F5.LTM/Server) | Defined by relationship Orion.F5DeviceReferencesF5Servers (System.Hosting) |
| VirtualIPAddresses | [Orion.F5.LTM.VirtualIPAddress](./../Orion.F5.LTM/VirtualIPAddress) | Defined by relationship Orion.F5DeviceReferencesVirtualIPAddresses (System.Reference) |
| WideIPs | [Orion.F5.GTM.WideIP](./../Orion.F5.GTM/WideIP) | Defined by relationship Orion.F5DeviceHostsWideIP (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsF5Device (System.Hosting) |

## Verbs

### TestApiPolling

#### Access control

everyone

### EnableApiPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DisableApiPolling

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


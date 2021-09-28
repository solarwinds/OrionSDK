---
id: VirtualServer
slug: VirtualServer
---

# Orion.F5.LTM.VirtualServer

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VirtualServerIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WildIPMask | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VLAN | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ServerType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| DefaultPoolIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5StatusReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnabledState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_In | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BPS_Out | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Connections | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| RequestsPerSec | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| F5StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnabledDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Pool | [Orion.F5.LTM.Pool](./../Orion.F5.LTM/Pool) | Defined by relationship Orion.F5VirtualServerReferencePool (System.Reference) |
| Stats | [Orion.F5.LTM.VirtualServerStats](./../Orion.F5.LTM/VirtualServerStats) | Defined by relationship Orion.F5.LTM.VirtualServerHostsVirtualServerStats (System.Hosting) |
| Map | [Orion.F5.Map.VirtualServer](./../Orion.F5.Map/VirtualServer) | Defined by relationship Orion.F5LTMVirtualServerReferenceMap (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| F5Device | [Orion.F5.System.Device](./../Orion.F5.System/Device) | Defined by relationship Orion.F5DeviceHostsVirtualServers (System.Hosting) |
| VirtualIPAddress | [Orion.F5.LTM.VirtualIPAddress](./../Orion.F5.LTM/VirtualIPAddress) | Defined by relationship Orion.F5VirtualIPAddressReferenceVirtualServer (System.Reference) |


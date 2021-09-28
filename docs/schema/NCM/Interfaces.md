---
id: Interfaces
slug: Interfaces
---

# NCM.Interfaces

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceTypeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceTypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceSpeed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AdminStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceMTU | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastChange | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| PhysicalInterface | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| Promiscuous | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| InterfaceID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| VLANID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VlanType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceHighSpeed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ArpTables | [NCM.ArpTables](./../NCM/ArpTables) | Defined by relationship NCM.InterfacesRefArpTables (System.Reference) |
| BridgePorts | [NCM.BridgePorts](./../NCM/BridgePorts) | Defined by relationship NCM.InterfacesRefBridgePorts (System.Reference) |
| CiscoCdp | [NCM.CiscoCdp](./../NCM/CiscoCdp) | Defined by relationship NCM.InterfacesRefCiscoCdp (System.Reference) |
| RouteTable | [NCM.RouteTable](./../NCM/RouteTable) | Defined by relationship NCM.InterfacesRefRouteTable (System.Reference) |
| IpAddresses | [NCM.IpAddresses](./../NCM/IpAddresses) | Defined by relationship NCM.InterfaceHostsIpAddresses (System.Hosting) |
| CATOSPorts | [NCM.CATOSPorts](./../NCM/CATOSPorts) | Defined by relationship NCM.InterfacesRefCATOSPorts (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefInterfaces (System.Reference) |
| Node | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodeHostsInterfaces (System.Hosting) |


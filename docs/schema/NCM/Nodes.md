---
id: Nodes
slug: Nodes
---

# NCM.Nodes

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| read,update,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| CoreNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentIPv6 | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ManagedProtocol | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| AgentIPSort | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReverseDNS | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Community | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CommunityReadWrite | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPLevel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysDescr | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysContact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysLocation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemOID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OSImage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConfigTypes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeComments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Username | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnableLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnablePassword | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ExecProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CommandProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TransferProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgorithm | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LoginStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UseHTTPS | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UseUserDeviceCredentials | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastInventory | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SNMPContext | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPUsername | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPAuthType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPAuthPass | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPEncryptType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPEncryptPass | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowIntermediary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UseKeybInteractiveAuth | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ResponseError | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interfaces | [NCM.Interfaces](./../NCM/Interfaces) | Defined by relationship NCM.NodeHostsInterfaces (System.Hosting) |
| MacForwarding | [NCM.MacForwarding](./../NCM/MacForwarding) | Defined by relationship NCM.NodeHostsMacForwarding (System.Hosting) |
| VLANs | [NCM.VLANs](./../NCM/VLANs) | Defined by relationship NCM.NodeHostsVLANs (System.Hosting) |
| BridgePorts | [NCM.BridgePorts](./../NCM/BridgePorts) | Defined by relationship NCM.NodeHostsBridgePorts (System.Hosting) |
| ArpTables | [NCM.ArpTables](./../NCM/ArpTables) | Defined by relationship NCM.NodeHostsArpTables (System.Hosting) |
| CatalystCards | [NCM.CatalystCards](./../NCM/CatalystCards) | Defined by relationship NCM.NodeHostsCatalystCards (System.Hosting) |
| CiscoCards | [NCM.CiscoCards](./../NCM/CiscoCards) | Defined by relationship NCM.NodeHostsCiscoCards (System.Hosting) |
| CiscoCdp | [NCM.CiscoCdp](./../NCM/CiscoCdp) | Defined by relationship NCM.NodeHostsCiscoCdp (System.Hosting) |
| CiscoChassis | [NCM.CiscoChassis](./../NCM/CiscoChassis) | Defined by relationship NCM.NodeHostsCiscoChassis (System.Hosting) |
| CiscoFlash | [NCM.CiscoFlash](./../NCM/CiscoFlash) | Defined by relationship NCM.NodeHostsCiscoFlash (System.Hosting) |
| CiscoFlashFiles | [NCM.CiscoFlashFiles](./../NCM/CiscoFlashFiles) | Defined by relationship NCM.NodeHostsCiscoFlashFiles (System.Hosting) |
| CiscoImageMIB | [NCM.CiscoImageMIB](./../NCM/CiscoImageMIB) | Defined by relationship NCM.NodeHostsCiscoImageMIB (System.Hosting) |
| CiscoMemoryPools | [NCM.CiscoMemoryPools](./../NCM/CiscoMemoryPools) | Defined by relationship NCM.NodeHostsCiscoMemoryPools (System.Hosting) |
| EntityLogical | [NCM.EntityLogical](./../NCM/EntityLogical) | Defined by relationship NCM.NodeHostsEntityLogical (System.Hosting) |
| EntityPhysical | [NCM.EntityPhysical](./../NCM/EntityPhysical) | Defined by relationship NCM.NodeHostsEntityPhysical (System.Hosting) |
| PortsTcp | [NCM.PortsTcp](./../NCM/PortsTcp) | Defined by relationship NCM.NodeHostsPortsTcp (System.Hosting) |
| PortsUdp | [NCM.PortsUdp](./../NCM/PortsUdp) | Defined by relationship NCM.NodeHostsPortsUdp (System.Hosting) |
| RouteTable | [NCM.RouteTable](./../NCM/RouteTable) | Defined by relationship NCM.NodeHostsRouteTable (System.Hosting) |
| CiscoFruPowerStatus | [NCM.CiscoFruPowerStatus](./../NCM/CiscoFruPowerStatus) | Defined by relationship NCM.NodesHostsCiscoFruPowerStatus (System.Hosting) |
| CiscoFruFanTrayStatus | [NCM.CiscoFruFanTrayStatus](./../NCM/CiscoFruFanTrayStatus) | Defined by relationship NCM.NodesHostsCiscoFruFanTrayStatus (System.Hosting) |
| CiscoFruPowerSupplyGroups | [NCM.CiscoFruPowerSupplyGroups](./../NCM/CiscoFruPowerSupplyGroups) | Defined by relationship NCM.NodesHostsCiscoFruPowerSupplyGroups (System.Hosting) |
| CiscoBootloadImages | [NCM.CiscoBootloadImages](./../NCM/CiscoBootloadImages) | Defined by relationship NCM.NodesHostsCiscoBootloadImages (System.Hosting) |


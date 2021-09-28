---
id: NodeProperties
slug: NodeProperties
---

# NCM.NodeProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| CoreNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeComments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Username | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnablePassword | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnableLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ExecProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CommandProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TransferProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgorithm | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LoginStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UseHTTPS | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UseUserDeviceCredentials | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastInventory | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AllowIntermediary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| TelnetPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SSHPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UseKeybInteractiveAuth | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ConfigTypes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionProfile | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EndOfSupport | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndOfSales | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndOfSoftware | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EosLink | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EosType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EosComments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReplacementPartNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OldVulnerabilitiesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VulnerabilitiesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VulnerabilitiesAnnouncementsNodes | [NCM.VulnerabilitiesAnnouncementsNodes](./../NCM/VulnerabilitiesAnnouncementsNodes) | Defined by relationship NCM.NodePropertiesRefVulnerabilitiesAnnouncementsNodes (System.Reference) |
| ArpTables | [NCM.ArpTables](./../NCM/ArpTables) | Defined by relationship NCM.NodePropertiesRefArpTables (System.Reference) |
| BridgePorts | [NCM.BridgePorts](./../NCM/BridgePorts) | Defined by relationship NCM.NodePropertiesRefBridgePorts (System.Reference) |
| CatalystCards | [NCM.CatalystCards](./../NCM/CatalystCards) | Defined by relationship NCM.NodePropertiesRefCatalystCards (System.Reference) |
| CiscoCards | [NCM.CiscoCards](./../NCM/CiscoCards) | Defined by relationship NCM.NodePropertiesRefCiscoCards (System.Reference) |
| CiscoCdp | [NCM.CiscoCdp](./../NCM/CiscoCdp) | Defined by relationship NCM.NodePropertiesRefCiscoCdp (System.Reference) |
| CiscoChassis | [NCM.CiscoChassis](./../NCM/CiscoChassis) | Defined by relationship NCM.NodePropertiesRefCiscoChassis (System.Reference) |
| CiscoFlash | [NCM.CiscoFlash](./../NCM/CiscoFlash) | Defined by relationship NCM.NodePropertiesRefCiscoFlash (System.Reference) |
| CiscoFlashFiles | [NCM.CiscoFlashFiles](./../NCM/CiscoFlashFiles) | Defined by relationship NCM.NodePropertiesRefCiscoFlashFiles (System.Reference) |
| CiscoImageMIB | [NCM.CiscoImageMIB](./../NCM/CiscoImageMIB) | Defined by relationship NCM.NodePropertiesRefCiscoImageMIB (System.Reference) |
| CiscoMemoryPools | [NCM.CiscoMemoryPools](./../NCM/CiscoMemoryPools) | Defined by relationship NCM.NodePropertiesRefCiscoMemoryPools (System.Reference) |
| EntityLogical | [NCM.EntityLogical](./../NCM/EntityLogical) | Defined by relationship NCM.NodePropertiesRefEntityLogical (System.Reference) |
| EntityPhysical | [NCM.EntityPhysical](./../NCM/EntityPhysical) | Defined by relationship NCM.NodePropertiesRefEntityPhysical (System.Reference) |
| Interfaces | [NCM.Interfaces](./../NCM/Interfaces) | Defined by relationship NCM.NodePropertiesRefInterfaces (System.Reference) |
| IpAddresses | [NCM.IpAddresses](./../NCM/IpAddresses) | Defined by relationship NCM.NodePropertiesRefIpAddresses (System.Reference) |
| MacForwarding | [NCM.MacForwarding](./../NCM/MacForwarding) | Defined by relationship NCM.NodePropertiesRefMacForwarding (System.Reference) |
| PortsTcp | [NCM.PortsTcp](./../NCM/PortsTcp) | Defined by relationship NCM.NodePropertiesRefPortsTcp (System.Reference) |
| PortsUdp | [NCM.PortsUdp](./../NCM/PortsUdp) | Defined by relationship NCM.NodePropertiesRefPortsUdp (System.Reference) |
| RouteTable | [NCM.RouteTable](./../NCM/RouteTable) | Defined by relationship NCM.NodePropertiesRefRouteTable (System.Reference) |
| VLANs | [NCM.VLANs](./../NCM/VLANs) | Defined by relationship NCM.NodePropertiesRefVLANs (System.Reference) |
| TransferResults | [NCM.TransferResults](./../NCM/TransferResults) | Defined by relationship NCM.NodePropertiesRefTransferResults (System.Reference) |
| WindowsAccounts | [NCM.WindowsAccounts](./../NCM/WindowsAccounts) | Defined by relationship NCM.NodePropertiesRefWindowsAccounts (System.Reference) |
| WindowsServices | [NCM.WindowsServices](./../NCM/WindowsServices) | Defined by relationship NCM.NodePropertiesRefWindowsServices (System.Reference) |
| WindowsSoftware | [NCM.WindowsSoftware](./../NCM/WindowsSoftware) | Defined by relationship NCM.NodePropertiesRefWindowsSoftware (System.Reference) |
| CATOSPorts | [NCM.CATOSPorts](./../NCM/CATOSPorts) | Defined by relationship NCM.NodePropertiesRefCATOSPorts (System.Hosting) |
| ConfigArchive | [NCM.ConfigArchive](./../NCM/ConfigArchive) | Defined by relationship NCM.NodePropertiesRefConfigArchive (System.Reference) |
| RTNAudit | [NCM.RTNAudit](./../NCM/RTNAudit) | Defined by relationship NCM.NodePropertiesRefRTNAudit (System.Reference) |
| EntityPhysicalJuniper | [NCM.EntityPhysicalJuniper](./../NCM/EntityPhysicalJuniper) | Defined by relationship NCM.NodePropertiesRefEntityPhysicalJuniper (System.Reference) |
| BrocadeAgentConfigModule | [NCM.BrocadeAgentConfigModule](./../NCM/BrocadeAgentConfigModule) | Defined by relationship NCM.NodePropertiesRefBrocadeAgentConfigModule (System.Reference) |
| BrocadeChassis | [NCM.BrocadeChassis](./../NCM/BrocadeChassis) | Defined by relationship NCM.NodePropertiesRefBrocadeChassis (System.Reference) |
| BrocadeChassisUnit | [NCM.BrocadeChassisUnit](./../NCM/BrocadeChassisUnit) | Defined by relationship NCM.NodePropertiesRefBrocadeChassisUnit (System.Reference) |
| F5System | [NCM.F5System](./../NCM/F5System) | Defined by relationship NCM.NodePropertiesRefF5System (System.Reference) |
| F5LTMVirtualServers | [NCM.F5LTMVirtualServers](./../NCM/F5LTMVirtualServers) | Defined by relationship NCM.NodePropertiesRefF5LTMVirtualServers (System.Reference) |
| F5GTMVirtualServers | [NCM.F5GTMVirtualServers](./../NCM/F5GTMVirtualServers) | Defined by relationship NCM.NodePropertiesRefF5GTMVirtualServers (System.Reference) |
| F5LTMNodeAddresses | [NCM.F5LTMNodeAddresses](./../NCM/F5LTMNodeAddresses) | Defined by relationship NCM.NodePropertiesRefF5LTMNodeAddresses (System.Reference) |
| CiscoFruPowerStatus | [NCM.CiscoFruPowerStatus](./../NCM/CiscoFruPowerStatus) | Defined by relationship NCM.NodePropertiesRefCiscoFruPowerStatus (System.Reference) |
| CiscoFruFanTrayStatus | [NCM.CiscoFruFanTrayStatus](./../NCM/CiscoFruFanTrayStatus) | Defined by relationship NCM.NodePropertiesRefCiscoFruFanTrayStatus (System.Reference) |
| CiscoFruPowerSupplyGroups | [NCM.CiscoFruPowerSupplyGroups](./../NCM/CiscoFruPowerSupplyGroups) | Defined by relationship NCM.NodePropertiesRefCiscoFruPowerSupplyGroups (System.Reference) |
| CiscoBootloadImages | [NCM.CiscoBootloadImages](./../NCM/CiscoBootloadImages) | Defined by relationship NCM.NodePropertiesHostsCiscoBootloadImages (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsNodeProperties (System.Hosting) |


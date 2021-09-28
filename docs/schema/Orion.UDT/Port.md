---
id: Port
slug: Port
---

# Orion.UDT.Port

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsMonitored | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PortIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Speed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Duplex | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| TrunkMode | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| PortDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperationalStatus | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| AdministrativeStatus | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IgnorePortRules | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Flag | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsMissing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsExcluded | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPAddresses | [Orion.UDT.IPAddressCurrent](./../Orion.UDT/IPAddressCurrent) | Defined by relationship Orion.UDT.PortReferencesIPAddresses (System.Reference) |
| IPAddressesHistory | [Orion.UDT.IPAddressHistory](./../Orion.UDT/IPAddressHistory) | Defined by relationship Orion.UDT.PortReferencesIPAddressesHistory (System.Reference) |
| WebUri | [Orion.UDT.PortWebUri](./../Orion.UDT/PortWebUri) | Defined by relationship Orion.UDT.PortsHostsWebUri (System.Hosting) |
| PortVLANs | [Orion.UDT.VLAN](./../Orion.UDT/VLAN) | Defined by relationship Orion.UDT.PortHostsVLAN (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.UDT.NodeHostsPorts (System.Hosting) |
| Endpoints | [Orion.UDT.PortToEndpointCurrent](./../Orion.UDT/PortToEndpointCurrent) | Defined by relationship Orion.UDT.PortToEndpointReferencesPort (System.Reference) |
| EndpointsHistory | [Orion.UDT.PortToEndpointHistory](./../Orion.UDT/PortToEndpointHistory) | Defined by relationship Orion.UDT.PortToEndpointHistoryReferencesPort (System.Reference) |

## Verbs

### AdministrativeShutdown

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### AdministrativeEnable

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


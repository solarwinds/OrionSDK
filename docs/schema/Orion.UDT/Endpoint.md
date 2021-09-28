---
id: Endpoint
slug: Endpoint
---

# Orion.UDT.Endpoint

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EndpointID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MACAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FirstSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Rogue | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPAddresses | [Orion.UDT.IPAddressCurrent](./../Orion.UDT/IPAddressCurrent) | Defined by relationship Orion.UDT.EndpointHostsIPAddress (System.Hosting) |
| IPAddressesHistory | [Orion.UDT.IPAddressHistory](./../Orion.UDT/IPAddressHistory) | Defined by relationship Orion.UDT.EndpointHostsIPAddressHistory (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Ports | [Orion.UDT.PortToEndpointCurrent](./../Orion.UDT/PortToEndpointCurrent) | Defined by relationship Orion.UDT.PortToEndpointReferencesEndpoint (System.Reference) |
| PortsHistory | [Orion.UDT.PortToEndpointHistory](./../Orion.UDT/PortToEndpointHistory) | Defined by relationship Orion.UDT.PortToEndpointHistoryReferencesEndpoint (System.Reference) |


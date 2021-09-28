---
id: PortToEndpointHistory
slug: PortToEndpointHistory
---

# Orion.UDT.PortToEndpointHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FirstSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| PortID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EndpointID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VlanID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConnectionType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Port | [Orion.UDT.Port](./../Orion.UDT/Port) | Defined by relationship Orion.UDT.PortToEndpointHistoryReferencesPort (System.Reference) |
| Endpoint | [Orion.UDT.Endpoint](./../Orion.UDT/Endpoint) | Defined by relationship Orion.UDT.PortToEndpointHistoryReferencesEndpoint (System.Reference) |


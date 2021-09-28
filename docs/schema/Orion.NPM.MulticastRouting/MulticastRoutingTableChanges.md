---
id: MulticastRoutingTableChanges
slug: MulticastRoutingTableChanges
---

# Orion.NPM.MulticastRouting.MulticastRoutingTableChanges

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastChangeUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SourceInterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamNeighborIPGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| MulticastProtocolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamIPAddressGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| UpstreamIPMask | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| UpstreamRoutingProtocolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamRIBType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| InLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Flags | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPVersion | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ChangeType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ChangeFlags | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| UpstreamNeighborIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UpstreamIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MulticastRoutingTableChanges | [Orion.NPM.MulticastRouting.RoutingTable](./../Orion.NPM.MulticastRouting/RoutingTable) | Defined by relationship Orion.NPM.MulticastRouting.RoutingTableReferencesMulticastRoutingTableChanges (System.Reference) |
| MulticastRoutingTableReport | [Orion.NPM.MulticastRouting.MulticastRoutingTableReport](./../Orion.NPM.MulticastRouting/MulticastRoutingTableReport) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsRoutingTableChanges (System.Hosting) |


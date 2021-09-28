---
id: MulticastRoutingTableReport
slug: MulticastRoutingTableReport
---

# Orion.NPM.MulticastRouting.MulticastRoutingTableReport

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MulticastGroupNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MulticastSourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourceInterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamNeighborIPGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| UpTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ExpiryTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MulticastProtocolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamIPAddressGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| UpstreamIPMask | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| UpstreamRoutingProtocolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UpstreamRIBType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| InTotalPkts | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| SourceTotalPkts | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InTotalOctets | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InCurrentBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InSourcePps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Flags | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPVersion | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ChangeType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| LastChangeUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UpstreamNeighborIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UpstreamIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNodeInterfaces | [Orion.NPM.MulticastRouting.GroupNodeInterfaces](./../Orion.NPM.MulticastRouting/GroupNodeInterfaces) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsGroupNodeInterfaces (System.Hosting) |
| Source | [Orion.NPM.MulticastRouting.Sources](./../Orion.NPM.MulticastRouting/Sources) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportReferencesSources (System.Reference) |
| MulticastRoutingTableChanges | [Orion.NPM.MulticastRouting.MulticastRoutingTableChanges](./../Orion.NPM.MulticastRouting/MulticastRoutingTableChanges) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsRoutingTableChanges (System.Hosting) |
| MulticastDataHistory | [Orion.NPM.MulticastRouting.DataHistory](./../Orion.NPM.MulticastRouting/DataHistory) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsDataHistory (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNode | [Orion.NPM.MulticastRouting.GroupNodes](./../Orion.NPM.MulticastRouting/GroupNodes) | Defined by relationship Orion.NPM.MulticastRouting.GroupNodesHostsMulticastRoutingTableReport (System.Hosting) |


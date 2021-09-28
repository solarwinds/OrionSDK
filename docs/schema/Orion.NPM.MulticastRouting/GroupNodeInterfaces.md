---
id: GroupNodeInterfaces
slug: GroupNodeInterfaces
---

# Orion.NPM.MulticastRouting.GroupNodeInterfaces

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastReporterIPGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| OutTotalPkts | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OutPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IPVersion | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| LastReporterIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RoutingTable | [Orion.NPM.MulticastRouting.RoutingTable](./../Orion.NPM.MulticastRouting/RoutingTable) | Defined by relationship Orion.NPM.MulticastRouting.RoutingTableReferencesGroupNodeInterfaces (System.Reference) |
| MulticastRoutingTableReport | [Orion.NPM.MulticastRouting.MulticastRoutingTableReport](./../Orion.NPM.MulticastRouting/MulticastRoutingTableReport) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsGroupNodeInterfaces (System.Hosting) |


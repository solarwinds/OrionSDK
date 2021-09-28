---
id: DataHistory
slug: DataHistory
---

# Orion.NPM.MulticastRouting.DataHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastChangeUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| InPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InSourcePps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MulticastRoutingTable | [Orion.NPM.MulticastRouting.RoutingTable](./../Orion.NPM.MulticastRouting/RoutingTable) | Defined by relationship Orion.NPM.MulticastRouting.RoutingTableReferencesDataHistory (System.Reference) |
| MulticastRoutingTableReport | [Orion.NPM.MulticastRouting.MulticastRoutingTableReport](./../Orion.NPM.MulticastRouting/MulticastRoutingTableReport) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportHostsDataHistory (System.Hosting) |


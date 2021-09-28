---
id: Sources
slug: Sources
---

# Orion.NPM.MulticastRouting.Sources

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastSourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourceIPGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| SourceMask | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| IPVersion | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SourceIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MulticastRoutingTables | [Orion.NPM.MulticastRouting.RoutingTable](./../Orion.NPM.MulticastRouting/RoutingTable) | Defined by relationship Orion.NPM.MulticastRouting.RoutingTableReferencesSources (System.Reference) |
| MulticastRoutingTablesReport | [Orion.NPM.MulticastRouting.MulticastRoutingTableReport](./../Orion.NPM.MulticastRouting/MulticastRoutingTableReport) | Defined by relationship Orion.NPM.MulticastRouting.MulticastRoutingTableReportReferencesSources (System.Reference) |


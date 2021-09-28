---
id: InterfaceTraffic
slug: InterfaceTraffic
---

# Orion.NPM.InterfaceTraffic

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
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| InAveragebps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMinbps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMaxbps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InTotalBytes | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InTotalPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InAvgUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMinUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMaxUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InAvgMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMinMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InMaxMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutAveragebps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMinbps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMaxbps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutTotalBytes | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutTotalPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutAvgUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMaxUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMinUniCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutAvgMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMinMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutMaxMultiCastPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| TotalBytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalPackets | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Averagebps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OutPercentUtil | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InPercentUtil | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| PercentUtil | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Errors | [Orion.NPM.InterfaceErrors](./../Orion.NPM/InterfaceErrors) | Defined by relationship Orion.NPM.TrafficToErrors (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.NPM.InterfacesHostsInterfaceTraffic (System.Hosting) |


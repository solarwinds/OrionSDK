---
id: AccessPoints
slug: AccessPoints
---

# Orion.Packages.Wireless.AccessPoints

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Packages.Wireless.Entity](./../Orion.Packages.Wireless/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ControllerID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Clients | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WirelessType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WirelessTypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Pps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ControllerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HistoricalAccessPoints | [Orion.Packages.Wireless.HistoricalAccessPoints](./../Orion.Packages.Wireless/HistoricalAccessPoints) | Defined by relationship Orion.AccessPointHostsHistoricalWirelessAccessPoints (System.Hosting) |
| WirelessInterfaces | [Orion.Packages.Wireless.Interfaces](./../Orion.Packages.Wireless/Interfaces) | Defined by relationship Orion.AccessPointHostsWirelessInterfaces (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsWirelessAccessPoints (System.Hosting) |


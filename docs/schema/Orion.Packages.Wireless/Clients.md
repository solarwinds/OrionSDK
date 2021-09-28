---
id: Clients
slug: Clients
---

# Orion.Packages.Wireless.Clients

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Packages.Wireless.Entity](./../Orion.Packages.Wireless/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InterfaceID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RDNS | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SignalStrength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InDataRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutDataRate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InTotalBytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OutTotalBytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InTotalPackets | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OutTotalPackets | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalBytes | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalPackets | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Pps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HistoricalClients | [Orion.Packages.Wireless.HistoricalClients](./../Orion.Packages.Wireless/HistoricalClients) | Defined by relationship Orion.ClientHostsHistoricalWirelessClients (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WirelessInterface | [Orion.Packages.Wireless.Interfaces](./../Orion.Packages.Wireless/Interfaces) | Defined by relationship Orion.WirelessInterfacesHostsWirelessClients (System.Hosting) |


---
id: Interfaces
slug: Interfaces
---

# Orion.Packages.Wireless.Interfaces

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Packages.Wireless.Entity](./../Orion.Packages.Wireless/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AccessPointID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| SSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Channel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AutoChannel | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Clients | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WEPEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| BeaconPeriod | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RadioType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutPps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Bps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Pps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InAckFailure | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutFailures | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InFCSError | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HistoricalInterfaces | [Orion.Packages.Wireless.HistoricalInterfaces](./../Orion.Packages.Wireless/HistoricalInterfaces) | Defined by relationship Orion.InterfaceHostsHistoricalWirelessInterfaces (System.Hosting) |
| WirelessClients | [Orion.Packages.Wireless.Clients](./../Orion.Packages.Wireless/Clients) | Defined by relationship Orion.WirelessInterfacesHostsWirelessClients (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AccessPoint | [Orion.Packages.Wireless.AccessPoints](./../Orion.Packages.Wireless/AccessPoints) | Defined by relationship Orion.AccessPointHostsWirelessInterfaces (System.Hosting) |


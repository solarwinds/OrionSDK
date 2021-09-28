---
id: Rogues
slug: Rogues
---

# Orion.Packages.Wireless.Rogues

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Packages.Wireless.Entity](./../Orion.Packages.Wireless/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ControllerID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| SSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Channel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SignalStrength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HistoricalRogues | [Orion.Packages.Wireless.HistoricalRogues](./../Orion.Packages.Wireless/HistoricalRogues) | Defined by relationship Orion.RogueHostsHistoricalWirelessRogues (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Controller | [Orion.Packages.Wireless.Controllers](./../Orion.Packages.Wireless/Controllers) | Defined by relationship Orion.ControllerHostsWirelessRogues (System.Hosting) |


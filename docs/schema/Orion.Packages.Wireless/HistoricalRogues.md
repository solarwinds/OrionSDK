---
id: HistoricalRogues
slug: HistoricalRogues
---

# Orion.Packages.Wireless.HistoricalRogues

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

↳ [Orion.Packages.Wireless.HistoryEntity](./../Orion.Packages.Wireless/HistoryEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ControllerIndex | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| SSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Channel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SignalStrength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Rogue | [Orion.Packages.Wireless.Rogues](./../Orion.Packages.Wireless/Rogues) | Defined by relationship Orion.RogueHostsHistoricalWirelessRogues (System.Hosting) |


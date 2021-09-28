---
id: Controllers
slug: Controllers
---

# Orion.Packages.Wireless.Controllers

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
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ThinAPsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RogueAPsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Rogues | [Orion.Packages.Wireless.Rogues](./../Orion.Packages.Wireless/Rogues) | Defined by relationship Orion.ControllerHostsWirelessRogues (System.Hosting) |
| WirelessSwitchPortMappings | [Orion.Packages.Wireless.SwitchPortMapping](./../Orion.Packages.Wireless/SwitchPortMapping) | Defined by relationship Orion.ControllerReferencesWirelessSwitchPortMappings (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsWirelessController (System.Hosting) |


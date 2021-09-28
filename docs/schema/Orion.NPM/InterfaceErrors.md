---
id: InterfaceErrors
slug: InterfaceErrors
---

# Orion.NPM.InterfaceErrors

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
| InErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| InDiscards | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OutDiscards | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Errors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Discards | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PercentDiscards | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PercentErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReceivePercentErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TransmitPercentErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CRCAlignErrors | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LateCollisions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.NPM.InterfacesHostsInterfaceErrors (System.Hosting) |
| Traffic | [Orion.NPM.InterfaceTraffic](./../Orion.NPM/InterfaceTraffic) | Defined by relationship Orion.NPM.TrafficToErrors (System.Reference) |


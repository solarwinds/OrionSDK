---
id: Device
slug: Device
---

# Orion.NPM.EW.Device

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OrigID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RecordID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| NPMNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OrionLink | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Available | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvailablePercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| FirstUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DomainName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MaximumImportance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaximumImportanceEntityName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NumberOfNeighbors | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CurrentEnergySaving | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySavingPercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaximumEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| isEwEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Entities | [Orion.NPM.EW.Entity](./../Orion.NPM.EW/Entity) | Defined by relationship Orion.EWDeviceHostsEWEntity (System.Hosting) |
| Neighbors | [Orion.NPM.EW.Neighbor](./../Orion.NPM.EW/Neighbor) | Defined by relationship Orion.EWDeviceHostsEWNeighbor (System.Hosting) |
| Statistics | [Orion.NPM.EW.DeviceStats](./../Orion.NPM.EW/DeviceStats) | Defined by relationship Orion.EWDeviceReferencesEWDeviceStats (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsEWDevice (System.Hosting) |


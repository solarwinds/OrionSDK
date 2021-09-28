---
id: DeviceStats
slug: DeviceStats
---

# Orion.NPM.EW.DeviceStats

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
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OrigID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
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
| CurrentEnergySaving | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySavingPercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySaving_MAX | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySavingPercent_MAX | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySaving_MIN | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergySavingPercent_MIN | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergyUsageWatts_MAX | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CurrentEnergyUsageWatts_MIN | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MaximumEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| IsEWEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| EnergyWiseDevice | [Orion.NPM.EW.Device](./../Orion.NPM.EW/Device) | Defined by relationship Orion.EWDeviceReferencesEWDeviceStats (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeHostsEWDeviceStats (System.Hosting) |


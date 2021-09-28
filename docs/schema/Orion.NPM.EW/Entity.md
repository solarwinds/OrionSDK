---
id: Entity
slug: Entity
---

# Orion.NPM.EW.Entity

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
| EnergyWiseAdminStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseCaliber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseCurrentEnergyUsage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseCurrentEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EnergyWiseCurrentLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseCurrentLevelAlerting | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseCurrentLevelText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseEntityImportance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseFullName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseKeywords | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseMaximumPowerDraw | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseMostImportantEntityID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseNannyBitVector | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseNeighborID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseOperationalStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseParentID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWisePowerUnits | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EnergyWiseRelativeImportance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseRole | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnergyWiseSumEntityImportance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InterfaceStatus | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| EventsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EnergyWiseCurrentEnergySaving | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EnergyWiseCurrentEnergySavingPercent | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| EnergyWiseMaximumEnergyUsageWatts | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.EWEntityReferencesInterface (System.Reference) |
| Events | [Orion.NPM.EW.Event](./../Orion.NPM.EW/Event) | Defined by relationship Orion.EWEntityHostsEWEvent (System.Hosting) |
| Statistics | [Orion.NPM.EW.EntityStats](./../Orion.NPM.EW/EntityStats) | Defined by relationship Orion.EWEntityReferencesEWEntityStats (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Device | [Orion.NPM.EW.Device](./../Orion.NPM.EW/Device) | Defined by relationship Orion.EWDeviceHostsEWEntity (System.Hosting) |


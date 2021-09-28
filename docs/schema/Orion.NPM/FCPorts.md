---
id: FCPorts
slug: FCPorts
---

# Orion.NPM.FCPorts

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| UnitID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Index | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WWN | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PhysicalNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HWState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HWStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VsanID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnitIDIndex | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.NPM.PortsReferenceInterfaces (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Vsan | [Orion.NPM.VSANs](./../Orion.NPM/VSANs) | Defined by relationship Orion.NPM.VsanReferencesPorts (System.Reference) |
| FCUnit | [Orion.NPM.FCUnits](./../Orion.NPM/FCUnits) | Defined by relationship Orion.FCUnitsHostsFCPorts (System.Hosting) |


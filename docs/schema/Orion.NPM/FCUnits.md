---
id: FCUnits
slug: FCUnits
---

# Orion.NPM.FCUnits

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConnUnitID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Product | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| State | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| FCPorts | [Orion.NPM.FCPorts](./../Orion.NPM/FCPorts) | Defined by relationship Orion.FCUnitsHostsFCPorts (System.Hosting) |
| FCRevisions | [Orion.NPM.FCRevisions](./../Orion.NPM/FCRevisions) | Defined by relationship Orion.FCUnitsHostsFCRevisions (System.Hosting) |
| FCSensors | [Orion.NPM.FCSensors](./../Orion.NPM/FCSensors) | Defined by relationship Orion.FCUnitsHostsFCSensors (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsFCUnits (System.Hosting) |


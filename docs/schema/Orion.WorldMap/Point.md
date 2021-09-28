---
id: Point
slug: Point
---

# Orion.WorldMap.Point

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PointId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Instance | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InstanceID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Latitude | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Longitude | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AutoAdded | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| StreetAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Group | [Orion.Groups](./../Orion/Groups) | Defined by relationship Orion.GroupsReferencesWorldMapPoints (System.Reference) |
| Label | [Orion.WorldMap.PointLabel](./../Orion.WorldMap/PointLabel) | Defined by relationship Orion.WorldMapPointLabelToWorldMapPoint (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesToWorldMapPoint (System.Reference) |


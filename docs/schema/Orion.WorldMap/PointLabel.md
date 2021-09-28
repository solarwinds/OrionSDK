---
id: PointLabel
slug: PointLabel
---

# Orion.WorldMap.PointLabel

SolarWinds Information Service 2020.2 Schema Documentation Index

Location name for World Map point.

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
| LabelId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Title | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WorldMapPoint | [Orion.WorldMap.Point](./../Orion.WorldMap/Point) | Defined by relationship Orion.WorldMapPointLabelToWorldMapPoint (System.Reference) |


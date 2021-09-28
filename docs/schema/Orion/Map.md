---
id: Map
slug: Map
---

# Orion.Map

SolarWinds Information Service 2020.2 Schema Documentation Index

Abstract entity for generic Map object.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MapID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Width | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Height | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MapStudioFileID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MapStudioFile | [Orion.MapStudioFiles](./../Orion/MapStudioFiles) | Defined by relationship Orion.MapToMapStudioFiles (System.Reference) |
| Point | [Orion.Map.Point](./../Orion.Map/Point) | Defined by relationship Orion.MapHostsMapPoint (System.Hosting) |


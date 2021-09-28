---
id: Map
slug: Map
---

# Orion.WirelessHeatMap.Map

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.Map](./../Orion/Map)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MapID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Scale | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ScaleUnit | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| PercentProgress | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ProcessingEngine | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GenerateStarted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastGenerationStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastGenerationFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ErrorCode | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| MapStudioFileID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ClientLocation | [Orion.WirelessHeatMap.ClientLocation](./../Orion.WirelessHeatMap/ClientLocation) | Defined by relationship Orion.WirelessHeatMap.MapHostsClientLocation (System.Hosting) |

## Verbs

### InsertMap

#### Access control

everyone

### DeleteMap

#### Access control

everyone

### SetMapError

#### Access control

everyone

### FireMapGenerationIndication

#### Access control

everyone

### PollAPSignalStrengthNow

#### Access control

everyone

### PollRPSignalStrengthNow

#### Access control

everyone

### StartClientSignalPoll

#### Access control

everyone

### GetProgress

#### Access control

everyone

### DeleteReferencePoints

#### Access control

everyone


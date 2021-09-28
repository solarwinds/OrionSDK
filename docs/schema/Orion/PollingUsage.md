---
id: PollingUsage
slug: PollingUsage
---

# Orion.PollingUsage

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity contains information about each polling usage (in percent).

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScaleFactor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CurrentUsage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsExceeded | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.EnginesHostsPollingUsage (System.Hosting) |


---
id: EngineProperties
slug: EngineProperties
---

# Orion.EngineProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

Property and their values for each engine.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,update,delete | system |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PropertyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PropertyValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.EnginesHostsEngineProperties (System.Hosting) |


---
id: ResponseTimeBreakdown
slug: ResponseTimeBreakdown
---

# Orion.SamAppOptics.Service.ResponseTimeBreakdown

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Service | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LayerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LayerType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship AppOptics.ApplicationPoolToResponseTimeBreakdown (System.Hosting) |


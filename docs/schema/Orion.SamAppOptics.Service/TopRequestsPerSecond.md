---
id: TopRequestsPerSecond
slug: TopRequestsPerSecond
---

# Orion.SamAppOptics.Service.TopRequestsPerSecond

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
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ApplicationPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Service | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TopRequestsPerSecondValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ApplicationPoolName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.IIS.Application](./../Orion.APM.IIS/Application) | Defined by relationship AppOptics.ApplicationToTopRequestsPerSecond (System.Reference) |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship AppOptics.ApplicationPoolToTopRequestsPerSecond (System.Reference) |


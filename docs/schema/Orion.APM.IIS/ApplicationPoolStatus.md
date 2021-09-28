---
id: ApplicationPoolStatus
slug: ApplicationPoolStatus
---

# Orion.APM.IIS.ApplicationPoolStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of application pool's status.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of request target application pool. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The time stamp. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The application pool status. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship Orion.APM.IIS.ApplicationPoolHostsStatus (System.Hosting) |


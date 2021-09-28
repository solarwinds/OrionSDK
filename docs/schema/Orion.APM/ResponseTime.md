---
id: ResponseTime
slug: ResponseTime
---

# Orion.APM.ResponseTime

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents response time.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Date | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| ComponentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the component availability. | everyone |
| ResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the response time. | everyone |
| StatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the statistic data. | everyone |
| ApplicationAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the application availability. | everyone |
| ComponentStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component status. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains response time entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentResponseTime (System.Hosting) |


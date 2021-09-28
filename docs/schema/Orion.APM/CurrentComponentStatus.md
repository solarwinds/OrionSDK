---
id: CurrentComponentStatus
slug: CurrentComponentStatus
---

# Orion.APM.CurrentComponentStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component status.

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
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component availability. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for component. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component status. | everyone |
| LastTimeUp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when component has Up status. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component error code. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component error message. | everyone |
| PercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains component percent CPU usage. | everyone |
| PercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains component percent memory usage. | everyone |
| PercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains component percent virtual memory usage. | everyone |
| IsFallbackUsed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Information that fallback for component was used | everyone |
| PrimaryPollingProtocol | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Primary polling method for component | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsCurrentStatus (System.Hosting) |


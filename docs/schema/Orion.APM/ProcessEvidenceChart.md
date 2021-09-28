---
id: ProcessEvidenceChart
slug: ProcessEvidenceChart
---

# Orion.APM.ProcessEvidenceChart

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents process evidence statistics. Used in charts.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| MinPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum CPU usage for process in percent. | everyone |
| MaxPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum CPU usage for process in percent. | everyone |
| AvgPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average CPU usage for process in percent. | everyone |
| MinPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum memory usage for process in percent. | everyone |
| MaxPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum memory usage for process in percent. | everyone |
| AvgPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average memory usage for process in percent. | everyone |
| MinMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains minimum memory usage for process. | everyone |
| MaxMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains maximum memory usage for process. | everyone |
| AvgMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains average memory usage for process. | everyone |
| MinPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum virtual memory usage for process in percent. | everyone |
| MaxPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum virtual memory usage for process in percent. | everyone |
| AvgPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average virtual memory usage for process in percent. | everyone |
| MinVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains minimum virtual memory usage for process. | everyone |
| MaxVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains maximum virtual memory usage for process. | everyone |
| AvgVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains average virtual memory usage for process. | everyone |
| MinInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimum instances count for process. | everyone |
| MaxInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximum instances count for process. | everyone |
| AvgInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average instances count for process. | everyone |
| MinIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum IO read operations per second for process. | everyone |
| MaxIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum IO read operations per second for process. | everyone |
| AvgIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average IO read operations per second for process. | everyone |
| MinIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains minimum IO write operations per second for process. | everyone |
| MaxIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains maximum IO write operations per second for process. | everyone |
| AvgIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains average IO write operations per second for process. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsProcessEvidenceChart (System.Hosting) |


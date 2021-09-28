---
id: CurrentStatistics
slug: CurrentStatistics
---

# Orion.APM.CurrentStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ApplicationAvailability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the application availability. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| ComponentName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of component. | everyone |
| ComponentType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component type. | everyone |
| ComponentAvailability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component availability. | everyone |
| ComponentErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component error code. | everyone |
| ComponentPortNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the port number. | everyone |
| ComponentResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the response time. | everyone |
| ComponentStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component statistic. | everyone |
| ComponentPID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the process ID. | everyone |
| ComponentProcessName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of process. | everyone |
| ComponentPercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component CPU usage. | everyone |
| ComponentPercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component memory usage. | everyone |
| ComponentMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the component memory used. | everyone |
| ComponentPercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component virtual memory usage. | everyone |
| ComponentVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the component virtual memory used. | everyone |
| ComponentIOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component IO read operations per second. | everyone |
| ComponentIOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component IO write operations per second. | everyone |
| ComponentIOTotalOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component IO total operations per second. | everyone |
| InstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the instance count. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component error message. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component statistics entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentCurrentStatistics (System.Hosting) |


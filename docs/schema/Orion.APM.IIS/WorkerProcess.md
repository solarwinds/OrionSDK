---
id: WorkerProcess
slug: WorkerProcess
---

# Orion.APM.IIS.WorkerProcess

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of worker process.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of application component. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for worker process. | everyone |
| ApplicationPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application pool. | everyone |
| ProcessName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates worker process name. | everyone |
| ProcessId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of worker process ID. | everyone |
| PercentCPU | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of worker process CPU usage. | everyone |
| PercentMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of worker process memory usage. | everyone |
| MemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer representation of worker process memory usage. | everyone |
| PercentVirtualMemory | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of worker process virtual memory usage. | everyone |
| VirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer representation of worker process virtual memory usage. | everyone |
| IOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The number of I/O read operations per second for worker process. | everyone |
| IOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The number of I/O write operations per second for worker process. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship Orion.APM.IIS.ApplicationPoolReferencesWorkerProcess (System.Reference) |


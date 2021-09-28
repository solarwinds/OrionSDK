---
id: ProcessEvidence
slug: ProcessEvidence
---

# Orion.APM.ProcessEvidence

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents process evidence statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of process evidence statistics. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component status. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains process name | everyone |
| MinPercentCPU | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimum CPU usage for process in percent. | everyone |
| MaxPercentCPU | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximum CPU usage for process in percent. | everyone |
| AvgPercentCPU | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average CPU usage for process in percent. | everyone |
| MinPercentMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimum memory usage for process in percent. | everyone |
| MaxPercentMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximum memory usage for process in percent. | everyone |
| AvgPercentMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average memory usage for process in percent. | everyone |
| MinMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains minimum memory usage for process. | everyone |
| MaxMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains maximum memory usage for process. | everyone |
| AvgMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains average memory usage for process. | everyone |
| MinPercentVirtualMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimum virtual memory usage for process in percent. | everyone |
| MaxPercentVirtualMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximum virtual memory usage for process in percent. | everyone |
| AvgPercentVirtualMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average virtual memory usage for process in percent. | everyone |
| MinVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains minimum virtual memory usage for process. | everyone |
| MaxVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains maximum virtual memory usage for process. | everyone |
| AvgVirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains average virtual memory usage for process. | everyone |
| MinInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimum instances count for process. | everyone |
| MaxInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximum instances count for process. | everyone |
| AvgInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average instances count for process. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the process evidence error code. | everyone |
| OSErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the operation system error code. | everyone |
| StatusCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the process evidence status code. | everyone |
| StatusCodeType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the process evidence status code type. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains error message. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of process evidence records that was archived. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The boolean value that specifies if process evidence data was archived. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ComponentStatus | [Orion.APM.ComponentStatus](./../Orion.APM/ComponentStatus) | Defined by relationship Orion.APM.ComponentStatusHostsProcessEvidence (System.Hosting) |


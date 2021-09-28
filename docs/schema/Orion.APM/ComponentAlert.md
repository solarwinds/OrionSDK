---
id: ComponentAlert
slug: ComponentAlert
---

# Orion.APM.ComponentAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| ApplicationAvailability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application availability. | everyone |
| ComponentName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of component. | everyone |
| ComponentType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component type. | everyone |
| ComponentAvailability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The availability of a component. | everyone |
| ResponseTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the component response time. | everyone |
| StatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the component statistic data. | everyone |
| ProcessName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of process. | everyone |
| ProcessInstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the process instance count. | everyone |
| PercentCPU | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains CPU usage in percent. | everyone |
| PercentMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The double value that contains memory usage in percent. | everyone |
| MemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The double value that contains memory usage. | everyone |
| PercentVirtualMemory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The double value that contains virtual memory usage in percent. | everyone |
| VirtualMemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The double value that contains virtual memory used. | everyone |
| ComponentMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component message. | everyone |
| UserDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component user description. | everyone |
| UserNotes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component user notes. | everyone |
| IOReadOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains IO read operations per second for process. | everyone |
| IOWriteOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains IO write operations per second for process. | everyone |
| IOTotalOperationsPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains IO read/write operations per second for process. | everyone |
| StatusOrErrorDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the component status or status description. | everyone |
| DisplayType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Provides the display type, for example, Windows Service, for the specific monitor. | everyone |
| LastTimeUp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Provides the date and time a component was last seen in the Up state. | everyone |
| MultiValueMessages | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Message sent when alerting on Multiple Value Chart. | everyone |
| MultiValueStatistics | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Statistics sent when alerting on Multiple Value Chart. | everyone |
| PercentApplicationAvailability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Provides the availability of an application as a percentage. | everyone |
| PercentComponentAvailability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Provides the availability of a component as a percentage. | everyone |
| WindowsEventMessages | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Full details of the corresponding event. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentAlertReferencesComponent (System.Reference) |


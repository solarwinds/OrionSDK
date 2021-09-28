---
id: ComponentAlertThresholds
slug: ComponentAlertThresholds
---

# Orion.APM.ComponentAlertThresholds

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component thresholds. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| ThresholdCPUCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of CPU critical threshold. | everyone |
| ThresholdCPUWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of CPU warning threshold. | everyone |
| ThresholdIOReadOperationsPerSecCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO read operations per second critical threshold. | everyone |
| ThresholdIOReadOperationsPerSecWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO read operations per second warning threshold. | everyone |
| ThresholdIOTotalOperationsPerSecCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO total operations per second critical threshold. | everyone |
| ThresholdIOTotalOperationsPerSecWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO total operations per second warning threshold. | everyone |
| ThresholdIOWriteOperationsPerSecCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO write operations per second critical threshold. | everyone |
| ThresholdIOWriteOperationsPerSecWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of IO write operations per second warning threshold. | everyone |
| ThresholdPhysicalMemoryCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of physical memory critical threshold. | everyone |
| ThresholdPhysicalMemoryWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of physical memory warning threshold. | everyone |
| ThresholdResponseTimeCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of response time critical threshold. | everyone |
| ThresholdResponseTimeWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of response time warning threshold. | everyone |
| ThresholdStatisticCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of statistic critical threshold. | everyone |
| ThresholdStatisticWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of statistic warning threshold. | everyone |
| ThresholdVirtualMemoryCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of virtual memory critical threshold. | everyone |
| ThresholdVirtualMemoryWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Value of virtual memory warning threshold. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of entity. Returns no value. Used to hide inherited field from alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentAlertThresholdsReferencesComponent (System.Reference) |


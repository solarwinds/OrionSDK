---
id: InstanceStatus
slug: InstanceStatus
---

# Orion.Cloud.InstanceStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

Cloud vritual machine from Azure and Amazon Elastic Compute Cloud Web Service partial statuses of an instance.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| VirtualMachineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CpuLoadStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetworkReceiveRateStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetworkTransmitRateStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NetworkUsageRateStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOPSReadStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOPSWriteStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOPSTotalStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DiskReadStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DiskWriteStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemoryStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Managed status calculated from related Node PercentMemoryUsed, if this instance is mapped to Node. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Instance | [Orion.Cloud.Instances](./../Orion.Cloud/Instances) | Defined by relationship Orion.Cloud.InstanceHostsInstanceStatus (System.Hosting) |


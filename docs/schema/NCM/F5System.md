---
id: F5System
slug: F5System
---

# NCM.F5System

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| CpuCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActiveCpuCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AvgCpuUsageRatio | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MemoryTotal | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ClientBytesIn | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ClientBytesOut | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ServerBytesIn | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ServerBytesOut | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| SystemUptime | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemUptimeInSec | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PlatformInfoName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PlatformInfoMarketingName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GeneralChassisSerialNum | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverStatusId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FailoverStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverStatusColor | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FailoverStatusSummary | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverActiveMode | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverForceActive | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConfigSyncState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductBuild | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductEdition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductDate | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefF5System (System.Reference) |


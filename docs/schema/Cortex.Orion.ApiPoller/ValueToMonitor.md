---
id: ValueToMonitor
slug: ValueToMonitor
---

# Cortex.Orion.ApiPoller.ValueToMonitor

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Path | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Key | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ThresholdRule | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WarningThresholdValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| CriticalThresholdValue | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Metric | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedApiPoller | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedRequestDetails | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.ApiPoller.ValueToMonitor.Metrics](./../Cortex.Orion.ApiPoller.ValueToMonitor/Metrics) | Defined by relationship Cortex.Orion.ApiPoller.ValueToMonitorToMetrics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApiPoller | [Cortex.Orion.ApiPoller.ApiPoller](./../Cortex.Orion.ApiPoller/ApiPoller) | Defined by relationship Cortex.Orion.ApiPoller.ApiPollerToValueToMonitorRelation (System.Hosting) |
| RequestDetails | [Cortex.Orion.ApiPoller.RequestDetails](./../Cortex.Orion.ApiPoller/RequestDetails) | Defined by relationship Cortex.Orion.ApiPoller.RequestDetailsToValueToMonitorRelation (System.Reference) |


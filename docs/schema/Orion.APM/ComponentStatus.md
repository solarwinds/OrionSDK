---
id: ComponentStatus
slug: ComponentStatus
---

# Orion.APM.ComponentStatus

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
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component status. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component availability. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the component availability in percent. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of status records that was archived. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The boolean value that specifies if status data was archived. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PortEvidence | [Orion.APM.PortEvidence](./../Orion.APM/PortEvidence) | Defined by relationship Orion.APM.ComponentStatusHostsPortEvidence (System.Hosting) |
| DynamicEvidence | [Orion.APM.DynamicEvidence](./../Orion.APM/DynamicEvidence) | Defined by relationship Orion.APM.ComponentStatusHostsDynamicEvidence (System.Hosting) |
| ProcessEvidence | [Orion.APM.ProcessEvidence](./../Orion.APM/ProcessEvidence) | Defined by relationship Orion.APM.ComponentStatusHostsProcessEvidence (System.Hosting) |
| ChartEvidence | [Orion.APM.ChartEvidence](./../Orion.APM/ChartEvidence) | Defined by relationship Orion.APM.ComponentStatusHostsChartEvidence (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsStatus (System.Hosting) |


---
id: MultipleStatisticData
slug: MultipleStatisticData
---

# Orion.APM.MultipleStatisticData

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents multiple statistic data.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the multiple statistic data name. | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the multiple statistic data label. | everyone |
| NumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the numeric multiple statistic data. | everyone |
| StringData | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the string multiple statistic data. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.MultipleStatisticDataReferencesComponent (System.Reference) |


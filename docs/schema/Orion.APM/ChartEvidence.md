---
id: ChartEvidence
slug: ChartEvidence
---

# Orion.APM.ChartEvidence

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents chart evidence statistic.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| MinStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the minimum statistic data. | everyone |
| AvgStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the average statistic data. | everyone |
| MaxStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum statistic data. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the chart evidence error code. | everyone |
| OSErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the operation system error code. | everyone |
| StatusCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the chart evidence status code. | everyone |
| StatusCodeType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the chart evidence status code type. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains error message. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of chart evidence records that was archived. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The boolean value that specifies if chart evidence data was archived. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ComponentStatus | [Orion.APM.ComponentStatus](./../Orion.APM/ComponentStatus) | Defined by relationship Orion.APM.ComponentStatusHostsChartEvidence (System.Hosting) |


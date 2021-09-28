---
id: EntityStatistics
slug: EntityStatistics
---

# Orion.APM.Exchange.EntityStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the exchange entity statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ParentEntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent entity. | everyone |
| ComponentTemplateID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component template. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for exchange entity statistics. | everyone |
| MinStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the minimum exchange entity statistic data. | everyone |
| MaxStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum exchange entity statistic data. | everyone |
| AvgStatisticData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the average exchange entity statistic data. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of exchange entity statistic records that was archived. | everyone |
| Archive | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The boolean value that specifies if exchange entity statistic was archived. | everyone |


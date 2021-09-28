---
id: DynamicEvidenceChart
slug: DynamicEvidenceChart
---

# Orion.APM.DynamicEvidenceChart

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents dynamic evidence statistics. Used in charts.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| ColumnSchemaID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent column schema. | everyone |
| ColumnDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if column is disabled. | everyone |
| ColumnName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of column. | everyone |
| ColumnLabel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the column label. | everyone |
| RowNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains column position. | everyone |
| MinNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the minimum numeric data. | everyone |
| AvgNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the average numeric data. | everyone |
| MaxNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum numeric data. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsDynamicEvidenceChart (System.Hosting) |


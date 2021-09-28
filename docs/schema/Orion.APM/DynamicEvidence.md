---
id: DynamicEvidence
slug: DynamicEvidence
---

# Orion.APM.DynamicEvidence

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents dynamic evidence statistics. Used to present script monitors statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentStatusID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component status. | everyone |
| ColumnSchemaID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent column schema. | everyone |
| RowNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains column position. | everyone |
| ColumnType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | The integer value that contains column type(string or numeric). | everyone |
| ColumnDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if column is disabled. | everyone |
| ColumnName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of column. | everyone |
| ColumnLabel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the column label. | everyone |
| ColumnThresholdWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold warning level. | everyone |
| ColumnThresholdCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold critical level. | everyone |
| ColumnThresholdOperator | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | The integer value that contains the threshold operator(0 -greater than;1 - greater than or equal to;2 - equal to;3 - less than or equal to;4 - less than;5 - not equal to.). | everyone |
| MinNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the minimum numeric data. | everyone |
| AvgNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the average numeric data. | everyone |
| MaxNumericData | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum numeric data. | everyone |
| StringData | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the string column output. | everyone |
| ErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the dynamic evidence error code. | everyone |
| OSErrorCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the operation system error code. | everyone |
| StatusCode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the dynamic evidence status code. | everyone |
| StatusCodeType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the dynamic evidence status code type. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains error message. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of dynamic evidence records that was archived. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The boolean value that specifies if dynamic evidence data was archived. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ComponentStatus | [Orion.APM.ComponentStatus](./../Orion.APM/ComponentStatus) | Defined by relationship Orion.APM.ComponentStatusHostsDynamicEvidence (System.Hosting) |


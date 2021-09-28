---
id: DynamicEvidenceColumnSchema
slug: DynamicEvidenceColumnSchema
---

# Orion.APM.DynamicEvidenceColumnSchema

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents dynamic evidence column schema. Used to present script monitors output.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ColumnSchemaID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of column schema. | everyone |
| ParentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent column schema. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| ComponentTemplateID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component template. | everyone |
| Type | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | The integer value that contains the component type. | everyone |
| IsDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if dynamic evidence output is disabled. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of dynamic evidence output. | everyone |
| Label | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the dynamic evidence output label. | everyone |
| IsLabelOverridden | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if dynamic evidence output label is overridden. | everyone |
| ThresholdOperator | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | The integer value that contains the threshold operator(0 -greater than;1 - greater than or equal to;2 - equal to;3 - less than or equal to;4 - less than;5 - not equal to.). | everyone |
| ThresholdWarning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold warning level. | everyone |
| ThresholdCritical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold critical level. | everyone |
| IsThresholdOverridden | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if threshold is overridden. | everyone |
| DataTransformExpression | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the data transformation expression. | everyone |
| DataTransformEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if data transformation is enabled. | everyone |
| DataTransformCheckedRadioButton | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains data transformation radio button value. | everyone |
| DataTransformFormulaIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains data transformation formula index. | everyone |
| DataTransformFormulaOptions | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the data transformation formula options. | everyone |
| IsDataTransformOverridden | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if data transform expression is overridden. | everyone |
| ComputeBaseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if compute baseline option is enabled for threshold. | everyone |
| UseBaseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if use baseline option is enabled for threshold. | everyone |
| WarningFormula | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the warning formula. | everyone |
| CriticalFormula | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the critical formula. | everyone |
| BaselineFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which baseline data is calculated. | everyone |
| BaselineTo | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which baseline data is calculated. | everyone |
| BaselineApplied | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when baseline calculation was enabled for threshold. | everyone |
| BaselineApplyError | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the baseline apply error. | everyone |
| WarningPolls | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the number of warning polls. | everyone |
| WarningPollsInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the warning polls interval. | everyone |
| CriticalPolls | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the number of critical polls. | everyone |
| CriticalPollsInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the critical polls interval. | everyone |


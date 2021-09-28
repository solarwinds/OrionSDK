---
id: Threshold
slug: Threshold
---

# Orion.APM.Threshold

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents SAM thresholds defined for components and their templates

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique integer threshold representation. | everyone |
| IsTemplate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if threshold is template. | everyone |
| ThresholdName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of threshold. | everyone |
| Warning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold warning level. | everyone |
| Critical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold critical level. | everyone |
| ThresholdOperator | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the threshold operator(0 -greater than;1 - greater than or equal to;2 - equal to;3 - less than or equal to;4 - less than;5 - not equal to.). | everyone |
| ComputeBaseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if compute baseline option is enabled for threshold. | everyone |
| UseBaseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if use baseline option is enabled for threshold. | everyone |
| WarningFormula | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the warning formula for threshold. | everyone |
| CriticalFormula | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the critical formula for threshold. | everyone |
| BaselineFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which baseline data is calculated. | everyone |
| BaselineTo | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which baseline data is calculated. | everyone |
| BaselineApplied | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when baseline calculation was enabled for threshold. | everyone |
| BaselineApplyError | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the baseline apply error. | everyone |
| WarningPolls | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the number of warning polls. | everyone |
| WarningPollsInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the warning polls interval. | everyone |
| CriticalPolls | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the number of critical polls. | everyone |
| CriticalPollsInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the critical polls interval. | everyone |


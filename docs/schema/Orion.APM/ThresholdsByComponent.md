---
id: ThresholdsByComponent
slug: ThresholdsByComponent
---

# Orion.APM.ThresholdsByComponent

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents threshold to component relation.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ComponentId | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| ThresholdName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of threshold. | everyone |
| Warning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold warning level. | everyone |
| Critical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the threshold critical level. | everyone |
| ThresholdOperator | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the threshold operator(0 -greater than;1 - greater than or equal to;2 - equal to;3 - less than or equal to;4 - less than;5 - not equal to.). | everyone |


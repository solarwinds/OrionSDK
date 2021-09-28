---
id: Frequencies
slug: Frequencies
---

# Orion.Frequencies

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FrequencyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CronExpression | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Duration | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EnabledDuringTimePeriod | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CronExpressionTimeZoneInfo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### SaveReportFrequencies

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageReports |

### SaveTimePeriodFrequencies

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |

### DeleteFrequencies

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |
| invoke | manageAlerts |
| invoke | manageReports |


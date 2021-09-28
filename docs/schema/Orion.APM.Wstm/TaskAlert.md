---
id: TaskAlert
slug: TaskAlert
---

# Orion.APM.Wstm.TaskAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the windows scheduler task. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique integer windows scheduler task representation. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the windows scheduler task. | everyone |
| NextRunTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task will be executed next time. | everyone |
| LastRunTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task was executed last time. | everyone |
| DateOfCreation | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task was created. | everyone |
| TaskState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The integer value that contains the windows scheduler task state(0 - Failed; 1 - Succeeded; 2 - Retry; 3 -Cancelled). | everyone |
| LastRunResult | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The long value that contains the windows scheduler task last run result. | everyone |
| Author | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the windows scheduler task author name. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the windows scheduler task description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ScheduledTask | [Orion.APM.Wstm.Task](./../Orion.APM.Wstm/Task) | Defined by relationship Orion.APM.ScheduledTaskAlertReferencesScheduledTask (System.Reference) |


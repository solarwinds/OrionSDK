---
id: Task
slug: Task
---

# Orion.APM.Wstm.Task

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the windows scheduler task.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique integer windows scheduler task representation. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of parent component. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the windows scheduler task. | everyone |
| State | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the windows scheduler task state(0 - Failed; 1 - Succeeded; 2 - Retry; 3 -Cancelled). | everyone |
| LastRunResult | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the windows scheduler task last run result. | everyone |
| LastRunTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task was executed last time. | everyone |
| NextRunTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task will be executed next time. | everyone |
| DateOfCreation | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when windows scheduler task was created. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the windows scheduler task description. | everyone |
| Author | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the windows scheduler task author name. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to task details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ScheduledTaskAlert | [Orion.APM.Wstm.TaskAlert](./../Orion.APM.Wstm/TaskAlert) | Defined by relationship Orion.APM.ScheduledTaskAlertReferencesScheduledTask (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationHostsScheduledTasks (System.Hosting) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.NodeReferencesScheduledTasks (System.Reference) |


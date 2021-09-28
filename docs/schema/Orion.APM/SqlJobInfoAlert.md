---
id: SqlJobInfoAlert
slug: SqlJobInfoAlert
---

# Orion.APM.SqlJobInfoAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL agent job information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL job. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the agent job name. | everyone |
| LastRunDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last SQL agent job execution. | everyone |
| LastRunDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the last SQL agent job execution duration. | everyone |
| LastRunStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the last SQL agent job execution status. | everyone |
| JobStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The status of an SQL agent job. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlJobInfo | [Orion.APM.SqlJobInfo](./../Orion.APM/SqlJobInfo) | Defined by relationship Orion.APM.SqlJobInfoAlertReferencesSqlJobInfo (System.Reference) |


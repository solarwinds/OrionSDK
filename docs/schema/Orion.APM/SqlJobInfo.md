---
id: SqlJobInfo
slug: SqlJobInfo
---

# Orion.APM.SqlJobInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SQL agent job information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| JobInfoID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of SQL job. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| LastRunDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last SQL agent job execution. | everyone |
| LastRunDuration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the last SQL agent job execution duration. | everyone |
| LastRunStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the last SQL agent job execution status. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the agent job name. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of an SQL agent job. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to agent job details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlJobInfoAlert | [Orion.APM.SqlJobInfoAlert](./../Orion.APM/SqlJobInfoAlert) | Defined by relationship Orion.APM.SqlJobInfoAlertReferencesSqlJobInfo (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlApplication | [Orion.APM.SqlServerApplication](./../Orion.APM/SqlServerApplication) | Defined by relationship Orion.APM.SqlServerApplicationHostsSqlJobInfo (System.Hosting) |


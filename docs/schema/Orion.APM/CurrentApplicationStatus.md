---
id: CurrentApplicationStatus
slug: CurrentApplicationStatus
---

# Orion.APM.CurrentApplicationStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents current application status.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the application availability. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for application. | everyone |
| LastTimeUp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when application has Up status. | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application error message. | everyone |
| LastSuccessfulPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last successful poll for application. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationHostsCurrentStatus (System.Hosting) |


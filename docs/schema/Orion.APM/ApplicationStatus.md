---
id: ApplicationStatus
slug: ApplicationStatus
---

# Orion.APM.ApplicationStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents application status.

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
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| Availability | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the application availability. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The integer value that contains the application availability in percent. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the number of status records that was archived. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The boolean value that specifies if status data was archived. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application status entity description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationHostsStatus (System.Hosting) |


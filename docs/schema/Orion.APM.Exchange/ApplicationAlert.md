---
id: ApplicationAlert
slug: ApplicationAlert
---

# Orion.APM.Exchange.ApplicationAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the exchange application information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent application. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application name. | everyone |
| Availability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The integer value that contains the application availability. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll. | everyone |
| LastTimeUp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The last date and time when application has Up status. | everyone |
| TemplateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application template description. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ExchangeApplication | [Orion.APM.Exchange.Application](./../Orion.APM.Exchange/Application) | Defined by relationship Orion.APM.Exchange.ApplicationAlertReferencesApplication (System.Reference) |


---
id: NamingContextStatus
slug: NamingContextStatus
---

# Orion.APM.ActiveDirectory.NamingContextStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory Naming Context Status information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NamingContextID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of Naming Context Status entity. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Status Time Stamp. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Naming Context Status (Orion Status). | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application status description. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NamingContext | [Orion.APM.ActiveDirectory.NamingContext](./../Orion.APM.ActiveDirectory/NamingContext) | Defined by relationship Orion.APM.ActiveDirectory.NamingContextsHostsStatus (System.Hosting) |


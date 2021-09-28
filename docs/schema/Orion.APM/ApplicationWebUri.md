---
id: ApplicationWebUri
slug: ApplicationWebUri
---

# Orion.APM.ApplicationWebUri

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents application web Uri.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application web Uri. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationHostsWebUri (System.Hosting) |


---
id: ComponentWebUri
slug: ComponentWebUri
---

# Orion.APM.ComponentWebUri

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component web Uri.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of component. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component web Uri. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Component | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentHostsWebUri (System.Hosting) |


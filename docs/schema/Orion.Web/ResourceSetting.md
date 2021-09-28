---
id: ResourceSetting
slug: ResourceSetting
---

# Orion.Web.ResourceSetting

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines web site resource default configuration

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| WebResourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Resource | [Orion.Web.Resource](./../Orion.Web/Resource) | Defined by relationship Orion.Web.ResourceResourceSettings (System.Reference) |


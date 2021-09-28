---
id: Resource
slug: Resource
---

# Orion.Web.Resource

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines web site resource types

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
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| UserSettings | [Orion.Web.ResourceSetting](./../Orion.Web/ResourceSetting) | Defined by relationship Orion.Web.ResourceResourceSettings (System.Reference) |
| UserSettings | [Orion.Web.ResourceUserSetting](./../Orion.Web/ResourceUserSetting) | Defined by relationship Orion.Web.ResourceResourceUserSettings (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Views | [Orion.Web.View](./../Orion.Web/View) | Defined by relationship Orion.Web.ViewResourceReference (System.Reference) |


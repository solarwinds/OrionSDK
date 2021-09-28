---
id: ComponentCategory
slug: ComponentCategory
---

# Orion.APM.ComponentCategory

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents component category.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of component category. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component category name. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains component category display name. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ComponentTemplates | [Orion.APM.ComponentTemplate](./../Orion.APM/ComponentTemplate) | Defined by relationship Orion.APM.ComponentTemplateReferencesCategory (System.Reference) |


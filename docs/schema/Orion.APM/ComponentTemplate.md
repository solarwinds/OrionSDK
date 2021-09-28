---
id: ComponentTemplate
slug: ComponentTemplate
---

# Orion.APM.ComponentTemplate

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents component template.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,update | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique integer representation of component template. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of component template. | everyone |
| ComponentType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component type. | everyone |
| ApplicationTemplateID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique integer representation of parent application template. | everyone |
| ComponentOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component position. | everyone |
| ComponentCategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique integer representation of parent component category. | everyone |
| IsApplicationItemSpecific | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if component template is application item specific. | everyone |
| UniqueId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Unique Guid representation of component template. | everyone |
| VisibilityMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component template visibility mode. | everyone |
| IsDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if component is disabled. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Category | [Orion.APM.ComponentCategory](./../Orion.APM/ComponentCategory) | Defined by relationship Orion.APM.ComponentTemplateReferencesCategory (System.Reference) |


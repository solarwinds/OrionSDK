---
id: ApplicationTemplate
slug: ApplicationTemplate
---

# Orion.APM.ApplicationTemplate

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents application template.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,update,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationTemplateID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application template. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application template. | everyone |
| IsMockTemplate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if application template is mock template. | everyone |
| Created | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when application template was created. | everyone |
| LastModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last application template modification. | everyone |
| ViewID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application template view. | everyone |
| HasImportedView | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if application template has imported view. | everyone |
| ViewXml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application template view Xml. | everyone |
| CustomApplicationType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application template custom type. | everyone |
| UniqueId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Unique Guid representation of application template. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Applications | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationTemplateReferencesApplication (System.Reference) |

## Verbs

### UpdateApplicationTemplateSettings

Update application template settings.

#### Access control

everyone

### DeleteTemplate

Delete existed application template.

#### Access control

everyone

### ExportTemplate

Export existed application template to stream.ID of template to export.Returns template in XML format

#### Access control

everyone

### ImportTemplate

Import application templateTemplate definition as string

#### Access control

everyone


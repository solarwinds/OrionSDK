---
id: ApplicationTemplateToProfileMapping
slug: ApplicationTemplateToProfileMapping
---

# Orion.SCM.ApplicationTemplateToProfileMapping

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity provides mapping between SAM application templates and SCM profiles. It allows to recommend SCM profiles based on existing SAM applications assigned to node.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationTemplateId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of SAM template. | everyone |
| ProfileId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Profile entity. | everyone |
| ApplicationTemplateUniqueId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | GUID of SAM template. | everyone |
| ApplicationTemplateName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of SAM template. | everyone |
| ProfileUniqueId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | GUID of Profile entity. | everyone |
| ProfileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of Profile entity. | everyone |
| AgentLess | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Whether the profile doesn't require agent. | everyone |


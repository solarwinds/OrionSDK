---
id: ComponentDefinition
slug: ComponentDefinition
---

# Orion.APM.ComponentDefinition

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents component definition.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of definition. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of definition. | everyone |
| ComponentType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component type. | everyone |
| ComponentEvidenceType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the component evidence type. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Components | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ComponentDefinitionReferencesComponent (System.Reference) |


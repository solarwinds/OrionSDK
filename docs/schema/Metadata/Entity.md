---
id: Entity
slug: Entity
---

# Metadata.Entity

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FullName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayNamePlural | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Aliases | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Namespace | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| BaseType | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| IsAbstract | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsSingleton | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsDynamic | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsFederated | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Federate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CanCreate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CanRead | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CanUpdate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CanDelete | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| CanInvoke | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsObsolete | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ObsolescenceReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsInternal | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Events | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Summary | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Arguments | [Metadata.EntityArgument](./../Metadata/EntityArgument) | Defined by relationship Metadata.EntityHostsArgument (System.Hosting) |
| Properties | [Metadata.Property](./../Metadata/Property) | Defined by relationship Metadata.EntityHostsProperty (System.Hosting) |
| EntityAliases | [Metadata.EntityAlias](./../Metadata/EntityAlias) | Defined by relationship Metadata.EntityHostsAlias (System.Hosting) |
| Verbs | [Metadata.Verb](./../Metadata/Verb) | Defined by relationship Metadata.EntityHostsVerb (System.Hosting) |
| Metadata | [Metadata.EntityMetadata](./../Metadata/EntityMetadata) | Defined by relationship Metadata.EntityHostsMetadata (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Dependents | [Metadata.Relationship](./../Metadata/Relationship) | Defined by relationship Metadata.RelationshipReferencesStartEntity (System.Reference) |
| Antecedents | [Metadata.Relationship](./../Metadata/Relationship) | Defined by relationship Metadata.RelationshipReferencesTargetEntity (System.Reference) |

## Verbs

### GetAliases

#### Access control

everyone

### GetSchemaLoadTime

#### Access control

everyone


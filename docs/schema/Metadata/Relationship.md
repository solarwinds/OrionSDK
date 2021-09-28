---
id: Relationship
slug: Relationship
---

# Metadata.Relationship

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| BaseType | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| IsInjected | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| SourceType | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| TargetType | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| SourcePropertyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePropertyDisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetPropertyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetPropertyDisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourcePrimaryKeyNames | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceForeignKeyNames | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetPrimaryKeyNames | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetForeignKeyNames | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceCardinalityMin | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceCardinalityMax | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetCardinalityMin | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetCardinalityMax | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsObsolete | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ObsolescenceReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsInternal | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Source | [Metadata.Entity](./../Metadata/Entity) | Defined by relationship Metadata.RelationshipReferencesStartEntity (System.Reference) |
| Target | [Metadata.Entity](./../Metadata/Entity) | Defined by relationship Metadata.RelationshipReferencesTargetEntity (System.Reference) |
| Metadata | [Metadata.RelationshipMetadata](./../Metadata/RelationshipMetadata) | Defined by relationship Metadata.RelationshipHostsMetadata (System.Hosting) |


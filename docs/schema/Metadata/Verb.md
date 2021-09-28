---
id: Verb
slug: Verb
---

# Metadata.Verb

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MethodName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CodeBehind | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CanInvoke | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Summary | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsObsolete | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ObsolescenceReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsInternal | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Arguments | [Metadata.VerbArgument](./../Metadata/VerbArgument) | Defined by relationship Metadata.VerbHostsVerbArgument (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Entity | [Metadata.Entity](./../Metadata/Entity) | Defined by relationship Metadata.EntityHostsVerb (System.Hosting) |


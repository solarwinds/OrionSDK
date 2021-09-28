---
id: DeletedAutoDependencies
slug: DeletedAutoDependencies
---

# Orion.DeletedAutoDependencies

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains Auto Dependencies ignored by user

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DependencyId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ParentUri | [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri) |  | everyone |
| ChildUri | [System.Uri](https://docs.microsoft.com/en-us/dotnet/api/system.uri) |  | everyone |
| LastUpdateUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AutoManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IncludeInStatusCalculation | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Category | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentEntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ParentNetObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChildEntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ChildNetObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FoundAsAutoManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Verbs

### RemoveIgnoredAutoDependencies

Removes ignored dependencies.

#### Access control

| Operations | Right |
| ------ | ------ |
| delete,invoke | admin |


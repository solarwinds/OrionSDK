---
id: Dependencies
slug: Dependencies
---

# Orion.Dependencies

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains dependencies defined by user and generated automatically

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
| LastUpdateUTC | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | read: everyone |
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

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DependencyTcpStatistics | [Orion.APM.DependencyTcpStatistics](./../Orion.APM/DependencyTcpStatistics) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesDependencies (System.Reference) |
| ApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesDependency (System.Reference) |

## Verbs

### RemoveDependencies

Ignore dependencies. Such dependencies are ingored in Autodependency calculation.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


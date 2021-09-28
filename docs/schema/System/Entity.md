---
id: Entity
slug: Entity
---

# System.Entity

SolarWinds Information Service 2020.2 Schema Documentation Index

System.Entity is the root of the SWIS type hierarchy. It carries no particular meaning or semantics. Choose System.Entity as your base type when no other type makes sense.
It does define four properties that will be inherited by every other entity type in SWIS: DisplayName, Description, InstanceType, and Uri. The values for InstanceType and Uri will be filled in by SWIS, so you should not map those to storage properties. If you have a property that makes sense to call "DisplayName" or "Description", then you should map accordingly.

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InstanceType | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |
| Uri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | All entity types have the Uri property which value is uniquely identifying an entity instance in the system. The value may be blank if the entity type doesn't define an identity for its instances. | everyone |
| InstanceSiteId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionSite | [Orion.Sites](./../Orion/Sites) | Defined by relationship Orion.SitesReferencesSystemEntity (System.Reference) |


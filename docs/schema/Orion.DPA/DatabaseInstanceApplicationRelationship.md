---
id: DatabaseInstanceApplicationRelationship
slug: DatabaseInstanceApplicationRelationship
---

# Orion.DPA.DatabaseInstanceApplicationRelationship

SolarWinds Information Service 2020.2 Schema Documentation Index

All relationships between Orion Application and Database Instance

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of SAM Application (Orion.APM.Application) | everyone |
| RelationshipType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numeric value for type of relationship | everyone |
| RelationshipTypeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Text representation of relationship type | everyone |
| NoRelationship | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if the relationship was removed | everyone |
| UserDefined | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if the relationship is defined by user | everyone |


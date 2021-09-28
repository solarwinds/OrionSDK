---
id: DatabaseInstanceData
slug: DatabaseInstanceData
---

# Orion.DPA.DatabaseInstanceData

SolarWinds Information Service 2020.2 Schema Documentation Index

Relationship between DPA Database Instance and Orion Node

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of Node (Orion.Nodes) | everyone |
| UserDefined | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if the relationship is defined by user | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceDataDatabaseInstance (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesDatabaseInstanceData (System.Reference) |


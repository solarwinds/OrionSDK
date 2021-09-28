---
id: DatabaseInstanceLun
slug: DatabaseInstanceLun
---

# Orion.DPA.DatabaseInstanceLun

SolarWinds Information Service 2020.2 Schema Documentation Index

All relationships between Orion LUN and Database Instance

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
| LunId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of LUN | everyone |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| UserDefined | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if the relationship is defined by user | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Lun | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.DatabaseInstanceLunLun (System.Reference) |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceLunDatabaseInstance (System.Reference) |


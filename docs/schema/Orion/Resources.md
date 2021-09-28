---
id: Resources
slug: Resources
---

# Orion.Resources

SolarWinds Information Service 2020.2 Schema Documentation Index

All resources added to the Orion views.

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
| ResourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ViewID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ViewColumn | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Position | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ResourceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResourceFile | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResourceTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResourceSubTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### CheckResourceMigration

This verb checks, whether it is possible to migrate classic resources (charts) to its modern version.

#### Access control

everyone

### MigrateClassicToModernResources

This verb migrates classic resources (charts) to its modern version.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### MigrateModernToClassicResources

This verb reverts migration back to classic resources (charts).

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### GetModernResourceName

Returns new apollo chart name for given classic chart name

#### Access control

everyone


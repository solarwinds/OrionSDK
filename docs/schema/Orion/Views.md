---
id: Views
slug: Views
---

# Orion.Views

SolarWinds Information Service 2020.2 Schema Documentation Index

Orion's UI Views

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
| ViewID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ViewKey | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ViewTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ViewGroupName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ViewGroup | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ViewType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ViewGroupPosition | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ViewIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Columns | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column1Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column2Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column3Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column4Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column5Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Column6Width | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| System | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Customizable | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LimitationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NOCView | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NOCViewRotationInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Verbs

### CloneView

Creates a clone of an existing view

#### Access control

everyone

### AddViewToGroup

Adds an existing view as a subview to another view and enables subviews on target if needed

#### Access control

everyone

### CloneViewContents

Creates a copy of all resources including properties of source view to a destination view

#### Access control

everyone

### AddResourceToView

Adds a resource to existing view by using resource configuration xml fragment

#### Access control

everyone


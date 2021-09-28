---
id: MenuBars
slug: MenuBars
---

# Orion.Web.MenuBars

SolarWinds Information Service 2020.2 Schema Documentation Index

Connects MenuItems into MenuBars, specifies item positions.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MenuName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MenuItemID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Position | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MenuItem | [Orion.Web.MenuItems](./../Orion.Web/MenuItems) | Defined by relationship Orion.Web.MenuBarReferencesMenuItem (System.Reference) |


---
id: HardwareCategoryStatusBase
slug: HardwareCategoryStatusBase
---

# Orion.HardwareHealth.HardwareCategoryStatusBase

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Category Status Base.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Category Status Base. | everyone |
| HardwareInfoID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Info Base. | everyone |
| HardwareCategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Category Base. | everyone |
| ItemsWithProblems | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a list of items with problems. | everyone |
| ItemsWithStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a list of categories with status. | everyone |
| FullyQualifiedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a fully qualified name for entity. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if entity is unmanaged. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which entity is unmanaged. | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which entity is unmanaged. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a status description. | everyone |
| HardwareCategoryName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a Hardware Category name. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to Hardware Category Status Base details page. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareCategory | [Orion.HardwareHealth.HardwareCategory](./../Orion.HardwareHealth/HardwareCategory) | Defined by relationship Orion.HardwareHealth.HardwareCategoryStatusBaseReferenceHardwareCategory (System.Reference) |


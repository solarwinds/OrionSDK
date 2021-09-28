---
id: View
slug: View
---

# Orion.Web.View

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines web site view types

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LimitationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DefaultTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TemplateUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Icon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsCustom | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| OpenInNewWindow | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| SortOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FeatureDependencies | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Resources | [Orion.Web.Resource](./../Orion.Web/Resource) | Defined by relationship Orion.Web.ViewResourceReference (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ViewGroups | [Orion.Web.ViewGroup](./../Orion.Web/ViewGroup) | Defined by relationship Orion.Web.ViewGroupViewReference (System.Reference) |
| Account | [Orion.Accounts](./../Orion/Accounts) | Defined by relationship Orion.Web.AccountUserWebViews (System.Reference) |


---
id: ViewGroup
slug: ViewGroup
---

# Orion.Web.ViewGroup

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines web site view group types

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
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DefaultTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Tags | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SortOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrionFeatureName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Views | [Orion.Web.View](./../Orion.Web/View) | Defined by relationship Orion.Web.ViewGroupViewReference (System.Reference) |
| OrionFeature | [Orion.Features](./../Orion/Features) | Defined by relationship Orion.Web.ViewGroupOrionFeatures (System.Reference) |


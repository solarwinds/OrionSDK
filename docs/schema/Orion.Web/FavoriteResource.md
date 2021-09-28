---
id: FavoriteResource
slug: FavoriteResource
---

# Orion.Web.FavoriteResource

SolarWinds Information Service 2020.2 Schema Documentation Index

All resources marked as favorite by a user account.

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
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResourcePath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Accounts | [Orion.Accounts](./../Orion/Accounts) | Defined by relationship Orion.Web.AccountFavoriteResources (System.Reference) |


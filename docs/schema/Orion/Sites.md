---
id: Sites
slug: Sites
---

# Orion.Sites

SolarWinds Information Service 2020.2 Schema Documentation Index

Represents Sites to be used by SWIS(f) to fetch data from.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Host | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Website | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsLocal | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Tag | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Entity | [System.Entity](./../System/Entity) | Defined by relationship Orion.SitesReferencesSystemEntity (System.Reference) |

## Verbs

### ApplyServerIDToQuerySelectStatement

Extends a specified query with a Site info the data originates from.

#### Access control

everyone


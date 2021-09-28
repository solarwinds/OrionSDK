---
id: ResourceUserSetting
slug: ResourceUserSetting
---

# Orion.Web.ResourceUserSetting

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines web site resource user configuration

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
| WebResourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Resource | [Orion.Web.Resource](./../Orion.Web/Resource) | Defined by relationship Orion.Web.ResourceResourceUserSettings (System.Reference) |
| Account | [Orion.Accounts](./../Orion/Accounts) | Defined by relationship Orion.Web.AccountResourceUserSettings (System.Reference) |


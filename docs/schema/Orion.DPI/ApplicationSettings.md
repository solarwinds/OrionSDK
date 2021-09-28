---
id: ApplicationSettings
slug: ApplicationSettings
---

# Orion.DPI.ApplicationSettings

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SettingID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.DPI.Applications](./../Orion.DPI/Applications) | Defined by relationship Orion.DPI.ApplicationToSettings (System.Reference) |


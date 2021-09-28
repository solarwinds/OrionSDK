---
id: SettingOverride
slug: SettingOverride
---

# Orion.SettingOverride

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Override | [Orion.Setting](./../Orion/Setting) | Defined by relationship Orion.SettingReferencesSettingOverride (System.Reference) |
| OrionServer | [Orion.OrionServers](./../Orion/OrionServers) | Defined by relationship Orion.EnginesReferencesSettingOverride (System.Reference) |


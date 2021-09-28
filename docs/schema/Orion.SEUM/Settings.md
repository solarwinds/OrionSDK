---
id: Settings
slug: Settings
---

# Orion.SEUM.Settings

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Settings information.

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
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string value that contains setting name. | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains setting name. | everyone |

## Verbs

### CheckRecorderCompatibility

Checks version compatibilityrecorder Versionreturns VersionCompatibility enum { NotCompatible = 0, Compatible = 1, NewerCompatibleVersionExist = 2 }

#### Access control

everyone

### GetRecorderCompatibility

Returns api version and installed recorder version.Returns RecorderCompatibility objects

#### Access control

everyone

### GetRecorderInstaller

Gets installerMemory stream with installer

#### Access control

everyone


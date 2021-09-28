---
id: Interfaces
slug: Interfaces
---

# Orion.ASA.Interfaces

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SecurityLevel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| NameIf | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StandbyIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.InterfaceHostsASAInterface (System.Hosting) |

## Verbs

### SetFavorite

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### RemoveFavorite

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


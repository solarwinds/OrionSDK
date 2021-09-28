---
id: LunMasking
slug: LunMasking
---

# Orion.SRM.LunMasking

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines LUN masking

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LunID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InitiatorLunID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InitiatorEndpoint | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetEndpoint | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UUID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Lun | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.SRM.LUNsReferencesLunMasking (System.Reference) |


---
id: LicenseAssignments
slug: LicenseAssignments
---

# Orion.Licensing.LicenseAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LicenseKey | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LicenseVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OrionPoolID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionServer | [Orion.OrionServers](./../Orion/OrionServers) | Defined by relationship Orion.OrionServersReferencesLicenseAssignments (System.Reference) |
| OrionPool | [Orion.HA.Pools](./../Orion.HA/Pools) | Defined by relationship Orion.HAPoolsReferencesLicenseAssignments (System.Reference) |


---
id: PathHops
slug: PathHops
---

# Orion.IpSla.PathHops

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PathID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HopIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpAddressV4 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CurrentStats | [Orion.IpSla.PathHopOperationCurrentStats](./../Orion.IpSla/PathHopOperationCurrentStats) | Defined by relationship Orion.IpSla.PathHopsReferencesCurrentStats (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Path | [Orion.IpSla.Paths](./../Orion.IpSla/Paths) | Defined by relationship Orion.IpSla.PathsHostsHops (System.Hosting) |


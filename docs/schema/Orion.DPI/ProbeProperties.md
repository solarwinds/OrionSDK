---
id: ProbeProperties
slug: ProbeProperties
---

# Orion.DPI.ProbeProperties

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
| PropertyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Probe | [Orion.DPI.Probes](./../Orion.DPI/Probes) | Defined by relationship Orion.DPI.ProbeToProperties (System.Reference) |


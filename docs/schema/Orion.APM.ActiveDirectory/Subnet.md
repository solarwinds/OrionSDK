---
id: Subnet
slug: Subnet
---

# Orion.APM.ActiveDirectory.Subnet

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory subnet.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of the subnet. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the subnet. | everyone |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the owning subnet. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.ActiveDirectory.Site](./../Orion.APM.ActiveDirectory/Site) | Defined by relationship Orion.APM.ActiveDirectory.SiteSubnets (System.Reference) |


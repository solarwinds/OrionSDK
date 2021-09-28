---
id: DomainController
slug: DomainController
---

# Orion.APM.ActiveDirectory.DomainController

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory Domain Controller.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of the Domain Controller. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of parent application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of site. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the Domain Controller. | everyone |
| WhenCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | When Domain Controller was created. | everyone |
| WhenChanged | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | When Domain Controller was changed last time. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of the Domain Controller. | everyone |
| Roles | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Flexible Single-Master Operations (FSMO) Roles. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.ActiveDirectory.Application](./../Orion.APM.ActiveDirectory/Application) | Defined by relationship Orion.APM.ActiveDirectory.Application (System.Reference) |


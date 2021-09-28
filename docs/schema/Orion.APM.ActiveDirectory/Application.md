---
id: Application
slug: Application
---

# Orion.APM.ActiveDirectory.Application

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory BlackBox Application.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.Application](./../Orion.APM/Application)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DomainName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the owning domain. | everyone |
| DomainDisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User-friendly name of the domain. | everyone |
| RootDomainName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the root domain. | everyone |
| RootDomainDisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User-friendly name of the root domain. | everyone |
| WhenCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Creation date of the domain. | everyone |
| WhenChanged | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date of last modification of the domain. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DomainControllers | [Orion.APM.ActiveDirectory.DomainController](./../Orion.APM.ActiveDirectory/DomainController) | Defined by relationship Orion.APM.ActiveDirectory.Application (System.Reference) |
| Sites | [Orion.APM.ActiveDirectory.Site](./../Orion.APM.ActiveDirectory/Site) | Defined by relationship Orion.APM.ActiveDirectory.ApplicationHostsSite (System.Hosting) |
| NamingContexts | [Orion.APM.ActiveDirectory.NamingContext](./../Orion.APM.ActiveDirectory/NamingContext) | Defined by relationship Orion.APM.ActiveDirectory.ApplicationHostsNamingContext (System.Hosting) |

## Verbs

### AssignApplication

Assign Active Directory application to the specified node.

#### Access control

everyone


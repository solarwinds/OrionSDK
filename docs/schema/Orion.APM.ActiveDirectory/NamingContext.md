---
id: NamingContext
slug: NamingContext
---

# Orion.APM.ActiveDirectory.NamingContext

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory Naming Context information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NamingContextID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of Naming Context entity. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of Naming Context. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Naming Context status (Orion Status) as last seen. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Naming Context status as string. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the Naming Context details page URL. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the Naming Context details page URL. It is used by Network Atlas. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type of Application item. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Naming Context name displayed on resource. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NamingContextStatus | [Orion.APM.ActiveDirectory.NamingContextStatus](./../Orion.APM.ActiveDirectory/NamingContextStatus) | Defined by relationship Orion.APM.ActiveDirectory.NamingContextsHostsStatus (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.ActiveDirectory.Application](./../Orion.APM.ActiveDirectory/Application) | Defined by relationship Orion.APM.ActiveDirectory.ApplicationHostsNamingContext (System.Hosting) |
| Replications | [Orion.APM.ActiveDirectory.Replication](./../Orion.APM.ActiveDirectory/Replication) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationNamingContext (System.Reference) |


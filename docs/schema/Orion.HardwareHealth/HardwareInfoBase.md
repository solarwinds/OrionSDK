---
id: HardwareInfoBase
slug: HardwareInfoBase
---

# Orion.HardwareHealth.HardwareInfoBase

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Info Base.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Info Base. | everyone |
| ParentObjectEntity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a name of the parent Entity Type. | everyone |
| ParentObjectType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a object Entity Type. | everyone |
| ParentObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent. | everyone |
| ParentObjectName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a parent object name. | everyone |
| ParentObjectStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of parent object status. | everyone |
| ParentObjectVendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a parent object vendor. | everyone |
| ParentObjectVendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a parent object vendor icon. | everyone |
| PollingMethod | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of polling method. | everyone |
| Manufacturer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a manufacturer. | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a model. | everyone |
| ServiceTag | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a service tag. | everyone |
| IsDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicates if the entity is disabled. | everyone |
| LastPollTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of poll for entity. | everyone |
| LastPollStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of last poll status. | everyone |
| LastPollStatusName | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer representation of last poll status. | everyone |
| LastPollMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a last poll message. | everyone |
| CategoriesWithProblems | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a list of categories with problems. | everyone |
| CategoriesWithStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a list of categories with statuses. | everyone |
| FullyQualifiedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a fully qualified name for entity. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to Hardware Info Base details page. | everyone |
| AgentVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a agent version. | everyone |
| AgentUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a url to agent. | everyone |
| AgentName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a agent name. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if entity is unmanaged. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which entity is unmanaged. | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which entity is unmanaged. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains entity status description. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |

## Verbs

### EnableHardwareHealth

Enable Hardware Health for given entity.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DisableHardwareHealth

Disable Hardware Health for given entity.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DeleteHardwareHealth

Delete Hardware Health for given entity.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### IsHardwareHealthEnabled

Check if the Hardware Health is enabled for given entity.

#### Access control

everyone


---
id: HardwareItemBase
slug: HardwareItemBase
---

# Orion.HardwareHealth.HardwareItemBase

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Hardware Item Base.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Item Base. | everyone |
| HardwareInfoID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent Hardware Info Base. | everyone |
| HardwareCategoryStatusID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Category Status Base. | everyone |
| UniqueName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing unique name for entity. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a name for entity. | everyone |
| Value | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Double value containing a latest polled value for entity. | everyone |
| Unit | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Unit. | everyone |
| OriginalStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a original status. | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a last poll message. | everyone |
| IsDeleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value containing a information if entity is deleted. | everyone |
| FullyQualifiedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a fully qualified name for entity. | everyone |
| HasHistoricalData | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value containing a information if entity has historical data. | everyone |
| HardwareCategoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Hardware Category. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if entity is unmanaged. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time from which entity is unmanaged. | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time until which entity is unmanaged. | everyone |
| IsDisabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value containing a information if entity is disabled. | everyone |
| HardwareUnitDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a description of unit. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String value containing a status description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to Hardware Item Base details page. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | This property is not used. | everyone |
| ParentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Parent | [Orion.HardwareHealth.HardwareHierarchy](./../Orion.HardwareHealth/HardwareHierarchy) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareHierarchy (System.Hosting) |
| HardwareCategory | [Orion.HardwareHealth.HardwareCategory](./../Orion.HardwareHealth/HardwareCategory) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseReferenceHardwareCategory (System.Reference) |
| HardwareItemStatistics | [Orion.HardwareHealth.HardwareItemStatistics](./../Orion.HardwareHealth/HardwareItemStatistics) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemStatistics (System.Hosting) |
| HardwareItemValueStatistics | [Orion.HardwareHealth.HardwareItemValueStatistics](./../Orion.HardwareHealth/HardwareItemValueStatistics) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemValueStatistics (System.Hosting) |
| HardwareItemStatusStatistics | [Orion.HardwareHealth.HardwareItemStatusStatistics](./../Orion.HardwareHealth/HardwareItemStatusStatistics) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemStatusStatistics (System.Hosting) |
| HardwareItemThreshold | [Orion.HardwareHealth.HardwareItemThreshold](./../Orion.HardwareHealth/HardwareItemThreshold) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseHostsHardwareItemThreshold (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HardwareUnit | [Orion.HardwareHealth.HardwareUnit](./../Orion.HardwareHealth/HardwareUnit) | Defined by relationship Orion.HardwareHealth.HardwareItemBaseReferenceHardwareUnit (System.Reference) |

## Verbs

### EnableSensors

Enable sensors for given Hardware Health Items.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DisableSensors

Disable sensors for given Hardware Health Items.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


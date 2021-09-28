---
id: StorageControllerPorts
slug: StorageControllerPorts
---

# Orion.SRM.StorageControllerPorts

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about port elements on a storage controller

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| StorageControllerPortID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StorageControllerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LinkType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortIdentifier | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortSpeed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| BytesPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.SRM.StorageControllerPortStatistics](./../Orion.SRM/StorageControllerPortStatistics) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerPortStatistics (System.Hosting) |
| CustomProperties | [Orion.SRM.StorageControllerPortCustomProperties](./../Orion.SRM/StorageControllerPortCustomProperties) | Defined by relationship Orion.SRM.StorageControllerPortHostsCustomProperties (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageControllers | [Orion.SRM.StorageControllers](./../Orion.SRM/StorageControllers) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerPorts (System.Hosting) |


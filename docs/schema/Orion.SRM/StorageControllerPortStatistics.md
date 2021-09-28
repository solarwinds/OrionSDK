---
id: StorageControllerPortStatistics
slug: StorageControllerPortStatistics
---

# Orion.SRM.StorageControllerPortStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

Stores storage controller port statistics.
		
					Namely:
							IOTotal
							IOPS Distribution
              IOPSTotal
							BytesTotal
							Bytes PS Distribution
							BytesPSTotal

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StorageControllerPortID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOTotal | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesTotal | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| BytesPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| BytesPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageControllerPort | [Orion.SRM.StorageControllerPorts](./../Orion.SRM/StorageControllerPorts) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerPortStatistics (System.Hosting) |


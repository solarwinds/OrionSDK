---
id: StorageControllers
slug: StorageControllers
---

# Orion.SRM.StorageControllers

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains information about all Storage Controllers

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| StorageControllerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StorageArrayID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UserCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Manufacturer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Firmware | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HAConfigurationState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TotalMemory | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MemoryUsed | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CPUFrequency | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| CPUCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalCacheSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IOPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| IOPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOSizeTotal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeRead | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IOSizeWrite | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| BytesPSDistribution | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| BytesPSTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BytesPSWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyTotal | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyRead | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| IOLatencyWrite | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| Utilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemoryUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FcPortCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EthernetPortCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| iSCSIPortCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IOPSTotalThreshold | [Orion.SRM.StorageControllerIOPSTotalThreshold](./../Orion.SRM/StorageControllerIOPSTotalThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOPSTotalThreshold (System.Hosting) |
| IOPSReadThreshold | [Orion.SRM.StorageControllerIOPSReadThreshold](./../Orion.SRM/StorageControllerIOPSReadThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOPSReadThreshold (System.Hosting) |
| IOPSWriteThreshold | [Orion.SRM.StorageControllerIOPSWriteThreshold](./../Orion.SRM/StorageControllerIOPSWriteThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOPSWriteThreshold (System.Hosting) |
| IOPSDistributionThreshold | [Orion.SRM.StorageControllerIOPSDistributionThreshold](./../Orion.SRM/StorageControllerIOPSDistributionThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOPSDistributionThreshold (System.Hosting) |
| IOLatencyTotalThreshold | [Orion.SRM.StorageControllerIOLatencyTotalThreshold](./../Orion.SRM/StorageControllerIOLatencyTotalThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOLatencyTotalThreshold (System.Hosting) |
| IOLatencyReadThreshold | [Orion.SRM.StorageControllerIOLatencyReadThreshold](./../Orion.SRM/StorageControllerIOLatencyReadThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOLatencyReadThreshold (System.Hosting) |
| IOLatencyWriteThreshold | [Orion.SRM.StorageControllerIOLatencyWriteThreshold](./../Orion.SRM/StorageControllerIOLatencyWriteThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOLatencyWriteThreshold (System.Hosting) |
| IOSizeTotalThreshold | [Orion.SRM.StorageControllerIOSizeTotalThreshold](./../Orion.SRM/StorageControllerIOSizeTotalThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOSizeTotalThreshold (System.Hosting) |
| IOSizeReadThreshold | [Orion.SRM.StorageControllerIOSizeReadThreshold](./../Orion.SRM/StorageControllerIOSizeReadThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOSizeReadThreshold (System.Hosting) |
| IOSizeWriteThreshold | [Orion.SRM.StorageControllerIOSizeWriteThreshold](./../Orion.SRM/StorageControllerIOSizeWriteThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerIOSizeWriteThreshold (System.Hosting) |
| BytesPSTotalThreshold | [Orion.SRM.StorageControllerBytesPSTotalThreshold](./../Orion.SRM/StorageControllerBytesPSTotalThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerBytesPSTotalThreshold (System.Hosting) |
| BytesPSReadThreshold | [Orion.SRM.StorageControllerBytesPSReadThreshold](./../Orion.SRM/StorageControllerBytesPSReadThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerBytesPSReadThreshold (System.Hosting) |
| BytesPSWriteThreshold | [Orion.SRM.StorageControllerBytesPSWriteThreshold](./../Orion.SRM/StorageControllerBytesPSWriteThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerBytesPSWriteThreshold (System.Hosting) |
| BytesPSDistributionThreshold | [Orion.SRM.StorageControllerBytesPSDistributionThreshold](./../Orion.SRM/StorageControllerBytesPSDistributionThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerBytesPSDistributionThreshold (System.Hosting) |
| UtilizationThreshold | [Orion.SRM.StorageControllerUtilizationThreshold](./../Orion.SRM/StorageControllerUtilizationThreshold) | Defined by relationship Orion.StorageControllersHostsStorageControllerUtilizationThreshold (System.Hosting) |
| Statistics | [Orion.SRM.StorageControllerStatistics](./../Orion.SRM/StorageControllerStatistics) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerStatistics (System.Hosting) |
| CustomProperties | [Orion.SRM.StorageControllerCustomProperties](./../Orion.SRM/StorageControllerCustomProperties) | Defined by relationship Orion.SRM.StorageControllerHostsCustomProperties (System.Hosting) |
| IPAddresses | [Orion.SRM.StorageControllerIPs](./../Orion.SRM/StorageControllerIPs) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerIPs (System.Hosting) |
| Ports | [Orion.SRM.StorageControllerPorts](./../Orion.SRM/StorageControllerPorts) | Defined by relationship Orion.SRM.StorageControllersHostsStorageControllerPorts (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| StorageArrays | [Orion.SRM.StorageArrays](./../Orion.SRM/StorageArrays) | Defined by relationship Orion.SRM.StorageArraysHostsStorageControllers (System.Hosting) |


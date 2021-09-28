---
id: ServerInformation
slug: ServerInformation
---

# Orion.AssetInventory.ServerInformation

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Domain | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DomainRole | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AssetType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperatingSystem | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OSArchitecture | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServicePack | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| OSLanguage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| HardwareSerialNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProductNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Manufacturer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastLoggedInUser | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WarrantyDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CountryCode | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastWarrantyPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DeviceTimeZone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AntivirusStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Contact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SerialPortsNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParallelPortsNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| USBPortsNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProcessorCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalMemoryB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| FreeMemoryB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| VirtualMemoryB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| FreeVirtualMemoryB | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| MemorySlotsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FirewallStandartProfile | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FirewallDomainProfile | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FirewallPublicProfile | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PartOfDomain | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| FirewallServiceStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| HardwareAgent | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WarrantyStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DaysUntilExpiration | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DeviceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Polling | [Orion.AssetInventory.Polling](./../Orion.AssetInventory/Polling) | Defined by relationship Orion.AssetInventory.NodesAIServerInformation (System.Reference) |


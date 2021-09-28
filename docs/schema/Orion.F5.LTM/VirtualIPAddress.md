---
id: VirtualIPAddress
slug: VirtualIPAddress
---

# Orion.F5.LTM.VirtualIPAddress

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IPAddressID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddressIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5StatusReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| F5StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnabledDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VirtualServer | [Orion.F5.LTM.VirtualServer](./../Orion.F5.LTM/VirtualServer) | Defined by relationship Orion.F5VirtualIPAddressReferenceVirtualServer (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Device | [Orion.F5.System.Device](./../Orion.F5.System/Device) | Defined by relationship Orion.F5DeviceReferencesVirtualIPAddresses (System.Reference) |
| LTM | [Orion.F5.System.ModuleLTM](./../Orion.F5.System/ModuleLTM) | Defined by relationship Orion.F5LTMReferencesVirtualIPAddresses (System.Reference) |


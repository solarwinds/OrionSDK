---
id: IPNodeReport
slug: IPNodeReport
---

# IPAM.IPNodeReport

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IPNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SubnetId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPOrdinal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressn | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| IPMappedn | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| IPMapped | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Alias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DnsBackward | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DhcpClientName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Sysname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Contact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysObjectId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SkipScan | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LeaseExpires | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ConflictReport | [IPAM.IPConflict](./../IPAM/IPConflict) | Defined by relationship IPAM.IPConflictNode (System.Reference) |
| NodeGroupReport | [IPAM.GroupReport](./../IPAM/GroupReport) | Defined by relationship IPAM.IPNodeGroupReport (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPHistoryToNode | [IPAM.IPHistory](./../IPAM/IPHistory) | Defined by relationship IPAM.IPHistoryToNodeReport (System.Reference) |


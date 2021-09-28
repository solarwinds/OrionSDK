---
id: IPNodeWithHistory
slug: IPNodeWithHistory
---

# IPAM.IPNodeWithHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SubnetName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SubnetId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPOrdinal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| IPMapped | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPMappedN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Alias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DnsBackward | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DhcpClientName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Contact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastCredential | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AllocPolicy | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SkipScan | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LeaseExpires | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| HistoryTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IsHistory | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CustomProperties | [IPAM.NodesCustomProperties](./../IPAM/NodesCustomProperties) | Defined by relationship IPAM.IPNodeWithHistoryHostsNodesCustomProperties (System.Reference) |


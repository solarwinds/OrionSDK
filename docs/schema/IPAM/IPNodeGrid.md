---
id: IPNodeGrid
slug: IPNodeGrid
---

# IPAM.IPNodeGrid

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
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
| Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| AllocPolicy | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SkipScan | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LeaseExpires | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPAddress4 | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress6 | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SubnetId4 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SubnetId6 | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DnsBy | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MacBy | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| StatusBy | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| SystemDataBy | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ScopeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ScopeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DhcpLease | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| DnsRecords | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsConflict | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConflictTypeIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| History | [IPAM.IPHistory](./../IPAM/IPHistory) | Defined by relationship IPAM.IPNodeGridRefIPHistory (System.Reference) |
| CustomProperties | [IPAM.NodesCustomProperties](./../IPAM/NodesCustomProperties) | Defined by relationship IPAM.IpNodeGridRefCustomProperties (System.Reference) |


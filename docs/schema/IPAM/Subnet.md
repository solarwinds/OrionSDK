---
id: Subnet
slug: Subnet
---

# IPAM.Subnet

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SubnetId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| ParentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Address | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | read: everyone |
| AddressMask | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| CIDR | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AllocSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| AllocSizeN | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| FriendlyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VLAN | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | read: everyone |
| Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ScanInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | read: everyone |
| TotalCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| UsedCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| AvailableCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| ReservedCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| TransientCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | read: everyone |
| HasLicenceOverflow | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | read: everyone |
| GroupIconPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| StatusName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| StatusShortDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| StatusRanking | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| StatusIconPostfix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| GroupTypeText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | read: everyone |
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Role | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Distance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SubnetStructureChanged | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | read: everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPNode | [IPAM.IPNode](./../IPAM/IPNode) | Defined by relationship IPAM.IPNodeSubnet (System.Reference) |


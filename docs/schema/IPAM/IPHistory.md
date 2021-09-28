---
id: IPHistory
slug: IPHistory
---

# IPAM.IPHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| HistoryId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPNodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| HistoryType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HistoryTypeN | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FromValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IntoValue | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Source | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SourceN | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ModifiedBy | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ICMP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| SNMP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DNS | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DHCP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ARP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPHistoryNodeReport | [IPAM.IPNodeReport](./../IPAM/IPNodeReport) | Defined by relationship IPAM.IPHistoryToNodeReport (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPNode | [IPAM.IPNode](./../IPAM/IPNode) | Defined by relationship IPAM.IPNodeHostsIPHistory (System.Hosting) |
| IPNodeGrid | [IPAM.IPNodeGrid](./../IPAM/IPNodeGrid) | Defined by relationship IPAM.IPNodeGridRefIPHistory (System.Reference) |


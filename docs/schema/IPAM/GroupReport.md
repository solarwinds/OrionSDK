---
id: GroupReport
slug: GroupReport
---

# IPAM.GroupReport

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GroupId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Address | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| AddressEnd | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| AddressMask | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CIDR | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AllocSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IPsAllocated | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| FriendlyName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VLAN | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ScanInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TransientPeriod | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RetainUserData | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NodeExpungeInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentUsed | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) |  | everyone |
| PercentageUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| TotalCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| UsedCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| AvailableCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ReservedCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| TransientCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| DisableAutoScanning | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| HasLicenceOverflow | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| GroupTypeText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupIconPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusShortDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusRanking | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusIconPostfix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisableNeighborScanning | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NeighborScanAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NeighborScanInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DnsZoneId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupTypeN | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SubnetID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Role | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Distance | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClusterId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Custom | [IPAM.GroupNodeAttr](./../IPAM/GroupNodeAttr) | Defined by relationship IPAM.GroupNodeAttrGroupReport (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship IPAM.GroupReportNodes (System.Reference) |
| DhcpServer | [IPAM.DhcpServer](./../IPAM/DhcpServer) | Defined by relationship IPAM.GroupReportDhcpServer (System.Reference) |
| NodeScope | [IPAM.DhcpScope](./../IPAM/DhcpScope) | Defined by relationship IPAM.GroupReportScope (System.Reference) |
| NodeDns | [IPAM.DnsServer](./../IPAM/DnsServer) | Defined by relationship IPAM.GroupReportDns (System.Reference) |
| ZoneDetail | [IPAM.DnsZone](./../IPAM/DnsZone) | Defined by relationship IPAM.GroupReportDnsZoneDetails (System.Reference) |
| CustomProperties | [IPAM.GroupsCustomProperties](./../IPAM/GroupsCustomProperties) | Defined by relationship IPAM.GroupsCustomPropertiesGroupReport (System.Reference) |
| IPNodeReportGroupReport | [IPAM.IPNodeReport](./../IPAM/IPNodeReport) | Defined by relationship IPAM.IPNodeGroupReport (System.Reference) |


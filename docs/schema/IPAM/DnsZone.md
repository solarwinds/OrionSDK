---
id: DnsZone
slug: DnsZone
---

# IPAM.DnsZone

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DnsZoneId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ZoneType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DynamicUpdate | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LookUpType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IncrementalZoneTransfer | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IncrementalZoneTransferSN | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| DataFileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MasterDnsServers | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DsIntegrated | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DnsViewId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FileInfo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupReportDnsZone | [IPAM.GroupReport](./../IPAM/GroupReport) | Defined by relationship IPAM.GroupReportDnsZoneDetails (System.Reference) |
| DnsRecord | [IPAM.DnsRecord](./../IPAM/DnsRecord) | Defined by relationship IPAM.DnsZoneHostsDnsRecord (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ZoneRecord | [IPAM.DnsRecord](./../IPAM/DnsRecord) | Defined by relationship IPAM.GroupReportDnsRecord (System.Reference) |
| GroupNode | [IPAM.GroupNode](./../IPAM/GroupNode) | Defined by relationship IPAM.GroupNodeHostsDnsZone (System.Hosting) |


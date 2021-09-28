---
id: DnsRecord
slug: DnsRecord
---

# IPAM.DnsRecord

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DnsRecordId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DnsZoneId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Data | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupReportDnsRecord | [IPAM.DnsZone](./../IPAM/DnsZone) | Defined by relationship IPAM.GroupReportDnsRecord (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DnsZone | [IPAM.DnsZone](./../IPAM/DnsZone) | Defined by relationship IPAM.DnsZoneHostsDnsRecord (System.Hosting) |


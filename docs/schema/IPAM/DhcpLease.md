---
id: DhcpLease
slug: DhcpLease
---

# IPAM.DhcpLease

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ScopeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientIpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientIpAddressN | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ClientMAC | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientLeaseExpires | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ClientStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| LeaseType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ClientName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReservationType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| FileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupReportLeases | [IPAM.DhcpScope](./../IPAM/DhcpScope) | Defined by relationship IPAM.DhcpScopeLeases (System.Reference) |


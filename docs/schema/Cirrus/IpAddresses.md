---
id: IpAddresses
slug: IpAddresses
---

# Cirrus.IpAddresses

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| InterfaceIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddrIPSort | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| SubnetMask | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReverseDNS | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ICMPReachable | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPReachable | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interfaces | [Cirrus.Interfaces](./../Cirrus/Interfaces) | Defined by relationship Cirrus.InterfaceHostsIpAddresses (System.Hosting) |


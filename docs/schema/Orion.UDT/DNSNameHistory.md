---
id: DNSNameHistory
slug: DNSNameHistory
---

# Orion.UDT.DNSNameHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FirstSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IPAddressID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DNSNameID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPAddresses | [Orion.UDT.IPAddressCurrent](./../Orion.UDT/IPAddressCurrent) | Defined by relationship Orion.UDT.IPAddressHostsDNSNameHistory (System.Hosting) |
| IPAddressesHistory | [Orion.UDT.IPAddressHistory](./../Orion.UDT/IPAddressHistory) | Defined by relationship Orion.UDT.IPAddressHistoryHostsDNSNameHistory (System.Reference) |


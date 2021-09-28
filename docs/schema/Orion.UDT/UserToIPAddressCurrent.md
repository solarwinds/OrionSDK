---
id: UserToIPAddressCurrent
slug: UserToIPAddressCurrent
---

# Orion.UDT.UserToIPAddressCurrent

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogonDateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UserID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LogonCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IP | [Orion.UDT.IPAddressCurrent](./../Orion.UDT/IPAddressCurrent) | Defined by relationship Orion.UDT.UserToIPAddressReferencesIPAddress (System.Reference) |
| User | [Orion.UDT.User](./../Orion.UDT/User) | Defined by relationship Orion.UDT.UserToIPAddressReferencesUser (System.Reference) |
| IPHistory | [Orion.UDT.IPAddressHistory](./../Orion.UDT/IPAddressHistory) | Defined by relationship Orion.UDT.UserToIPAddressReferencesIPAddressHistory (System.Reference) |


---
id: User
slug: User
---

# Orion.UDT.User

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| UserID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AccountSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AccountName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FirstName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Alias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Title | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Department | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Office | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Company | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Manager | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Assistant | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EmailAddressList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MemberOfList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Phone | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Address | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| City | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| State | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ZipCode | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CountryRegion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PrimaryGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPAddresses | [Orion.UDT.UserToIPAddressCurrent](./../Orion.UDT/UserToIPAddressCurrent) | Defined by relationship Orion.UDT.UserToIPAddressReferencesUser (System.Reference) |
| IPAddressesHistory | [Orion.UDT.UserToIPAddressHistory](./../Orion.UDT/UserToIPAddressHistory) | Defined by relationship Orion.UDT.UserToIPAddressHistoryReferencesUser (System.Reference) |


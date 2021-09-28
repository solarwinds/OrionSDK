---
id: IPAddressCurrent
slug: IPAddressCurrent
---

# Orion.UDT.IPAddressCurrent

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FirstSeen | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndpointID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IPAddressID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RouterNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RouterPortID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VrfID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DNSNames | [Orion.UDT.DNSNameCurrent](./../Orion.UDT/DNSNameCurrent) | Defined by relationship Orion.UDT.IPAddressHostsDNSName (System.Hosting) |
| DNSNamesHistory | [Orion.UDT.DNSNameHistory](./../Orion.UDT/DNSNameHistory) | Defined by relationship Orion.UDT.IPAddressHostsDNSNameHistory (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RouterNodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesReferencesIPAddresses (System.Reference) |
| RouterPorts | [Orion.UDT.Port](./../Orion.UDT/Port) | Defined by relationship Orion.UDT.PortReferencesIPAddresses (System.Reference) |
| Endpoint | [Orion.UDT.Endpoint](./../Orion.UDT/Endpoint) | Defined by relationship Orion.UDT.EndpointHostsIPAddress (System.Hosting) |
| Users | [Orion.UDT.UserToIPAddressCurrent](./../Orion.UDT/UserToIPAddressCurrent) | Defined by relationship Orion.UDT.UserToIPAddressReferencesIPAddress (System.Reference) |
| UsersHistory | [Orion.UDT.UserToIPAddressHistory](./../Orion.UDT/UserToIPAddressHistory) | Defined by relationship Orion.UDT.UserToIPAddressHistoryReferencesIPAddress (System.Reference) |


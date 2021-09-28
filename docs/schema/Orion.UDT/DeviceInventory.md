---
id: DeviceInventory
slug: DeviceInventory
---

# Orion.UDT.DeviceInventory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MacAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PortOperationalStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConnectedTo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DnsName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FirstName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UserId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ConnectionType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| VendorIconName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EndpointType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.UDT.NodesReferencesDeviceInventory (System.Reference) |


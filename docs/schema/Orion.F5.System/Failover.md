---
id: Failover
slug: Failover
---

# Orion.F5.System.Failover

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeviceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FailoverStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| FailoverStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ManagementIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeviceShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| F5Device | [Orion.F5.System.Device](./../Orion.F5.System/Device) | Defined by relationship Orion.F5DeviceHostsFailover (System.Hosting) |


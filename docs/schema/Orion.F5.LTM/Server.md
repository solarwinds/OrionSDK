---
id: Server
slug: Server
---

# Orion.F5.LTM.Server

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| F5ServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| F5ServerIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| F5StatusReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatus | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| ShortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| F5StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnabledDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Monitors | [Orion.F5.LTM.Monitor](./../Orion.F5.LTM/Monitor) | Defined by relationship Orion.F5ServerReferenceF5Monitor (System.Reference) |
| PoolMembers | [Orion.F5.LTM.PoolMember](./../Orion.F5.LTM/PoolMember) | Defined by relationship Orion.F5ServerReferencePoolMember (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Device | [Orion.F5.System.Device](./../Orion.F5.System/Device) | Defined by relationship Orion.F5DeviceReferencesF5Servers (System.Hosting) |

## Verbs

### LinkNode

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UnlinkNode

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


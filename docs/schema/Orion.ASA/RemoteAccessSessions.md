---
id: RemoteAccessSessions
slug: RemoteAccessSessions
---

# Orion.ASA.RemoteAccessSessions

SolarWinds Information Service 2020.2 Schema Documentation Index

List of Remote Access Tunnels on VPN device

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| SessionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SessionIndex | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisconnectedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SessionGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SessionStatus | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| EncryptionAlgorithm | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| AuthenticationAlgorithm | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| RasProtocol | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ClientInfo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| InTotalBytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OutTotalBytes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InTotalPkts | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| OutTotalPkts | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| InBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Detail | [Orion.ASA.RemoteAccessSessionDetail](./../Orion.ASA/RemoteAccessSessionDetail) | Defined by relationship Orion.ASA.RemoteAccessSessionsHostsRemoteAccessSessionDetail (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeReferencesASARemoteAccessSessions (System.Reference) |
| AsaDevice | [Orion.ASA.Node](./../Orion.ASA/Node) | Defined by relationship Orion.AsaDeviceHostsASARemoteAccessSessions (System.Hosting) |


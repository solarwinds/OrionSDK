---
id: RemoteAccessDetail
slug: RemoteAccessDetail
---

# Orion.ASA.RemoteAccessDetail

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ObservationTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActiveUsers | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActiveSessions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SessionFailRate | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InBytes | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutBytes | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutPkts | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutBps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| InPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| OutPps | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodeReferencesASARemoteAccessDetail (System.Reference) |
| AsaDevice | [Orion.ASA.Node](./../Orion.ASA/Node) | Defined by relationship Orion.AsaDeviceHostsASARemoteAccessDetail (System.Hosting) |


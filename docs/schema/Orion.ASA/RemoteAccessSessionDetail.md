---
id: RemoteAccessSessionDetail
slug: RemoteAccessSessionDetail
---

# Orion.ASA.RemoteAccessSessionDetail

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
| SessionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
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
| Session | [Orion.ASA.RemoteAccessSessions](./../Orion.ASA/RemoteAccessSessions) | Defined by relationship Orion.ASA.RemoteAccessSessionsHostsRemoteAccessSessionDetail (System.Hosting) |


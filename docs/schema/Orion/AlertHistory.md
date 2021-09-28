---
id: AlertHistory
slug: AlertHistory
---

# Orion.AlertHistory

SolarWinds Information Service 2020.2 Schema Documentation Index

Information about all actions done for active alerts such as Alert reset, Alert triggered and so on.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AlertHistoryID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EventType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AlertActiveID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| AlertObjectID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertObjects | [Orion.AlertObjects](./../Orion/AlertObjects) | Defined by relationship Orion.AlertHistoryToAlertObjects (System.Reference) |


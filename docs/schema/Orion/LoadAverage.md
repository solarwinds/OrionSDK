---
id: LoadAverage
slug: LoadAverage
---

# Orion.LoadAverage

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains historical load average data

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| LoadAverage1Min | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage1Max | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage1Avg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage5Min | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage5Max | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage5Avg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage15Min | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage15Max | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage15Avg | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsLoadAverage (System.Hosting) |


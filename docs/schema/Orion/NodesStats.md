---
id: NodesStats
slug: NodesStats
---

# Orion.NodesStats

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AvgResponseTime | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MinResponseTime | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MaxResponseTime | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ResponseTime | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| PercentLoss | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| CPUCount | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| CPULoad | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| MemoryUsed | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| LoadAverage1 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage5 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage15 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PercentMemoryUsed | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalMemory | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| BufferSmMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferSmMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferBgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferBgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferNoMemThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferNoMemToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferHgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferHgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferLgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferLgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferMdMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferMdMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SystemUpTime | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsNodesStats (System.Hosting) |


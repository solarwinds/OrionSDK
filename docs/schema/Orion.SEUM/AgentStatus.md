---
id: AgentStatus
slug: AgentStatus
---

# Orion.SEUM.AgentStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Agent status information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains agent id. | everyone |
| DateTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime value that contains date time stamp. | everyone |
| MinLoadPercentage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal load percentage. | everyone |
| MaxLoadPercentage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal load percentage. | everyone |
| AvgLoadPercentage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average load percentage. | everyone |
| MinNumManagedTransactions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal number of managed transactions. | everyone |
| MaxNumManagedTransactions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal number of managed transactions. | everyone |
| AvgNumManagedTransactions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average number of managed transactions. | everyone |
| MinQueueLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains minimal queue length. | everyone |
| MaxQueueLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains maximal queue length. | everyone |
| AvgQueueLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average queue length. | everyone |
| PercentAvailability | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains agent availability percentage. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains agent status id. | everyone |
| RecordCount | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains record count. | everyone |
| Archive | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | The bolean value that specifies if archive. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agent | [Orion.SEUM.Agents](./../Orion.SEUM/Agents) | Defined by relationship Orion.SEUM.AgentReferencesAgentStatus (System.Reference) |


---
id: Cpu
slug: Cpu
---

# Cortex.Orion.Cpu

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [Cortex.System.ElementInstance](./../Cortex.System/ElementInstance)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Index | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentUtilization | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RelatedNode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Metrics | [Cortex.Orion.Cpu.Metrics](./../Cortex.Orion.Cpu/Metrics) | Defined by relationship Cortex.Orion.CpuToMetrics (System.Hosting) |
| Statistics | [Cortex.Orion.Cpu.Statistics](./../Cortex.Orion.Cpu/Statistics) | Defined by relationship Cortex.Orion.CpuToStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Cortex.Orion.Node](./../Cortex.Orion/Node) | Defined by relationship Cortex.Orion.NodeToCpus (System.Hosting) |


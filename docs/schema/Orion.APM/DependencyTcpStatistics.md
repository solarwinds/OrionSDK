---
id: DependencyTcpStatistics
slug: DependencyTcpStatistics
---

# Orion.APM.DependencyTcpStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DependencyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeToNodeLinkID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Latency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LatencyStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLossStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LatencyStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PacketLossStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.DependencyTcpStatisticsHostsApplicationTcpConnections (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeToNodeLink | [Orion.APM.NodeToNodeLink](./../Orion.APM/NodeToNodeLink) | Defined by relationship Orion.APM.NodeToNodeLinkHostsDependencyTcpStatistics (System.Hosting) |
| Dependency | [Orion.Dependencies](./../Orion/Dependencies) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesDependencies (System.Reference) |
| ClientApplication | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesClientApplication (System.Reference) |
| ServerApplication | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.DependencyTcpStatisticsReferencesServerApplication (System.Reference) |


---
id: ApplicationTcpConnection
slug: ApplicationTcpConnection
---

# Orion.APM.ApplicationTcpConnection

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
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ParentDependencyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientProcessName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientCmdlineArgs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientServiceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ClientInterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ClientApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientNodeIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerProcessName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerCmdlineArgs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerServiceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerInterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ServerPortComponentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| ServerApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ServerNodeIPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerPort | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClientDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServerDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastSeenTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Latency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LatencyStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PacketLossStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastStatisticPollTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LatencyStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| PacketLossStatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DependencyTcpStatistics | [Orion.APM.DependencyTcpStatistics](./../Orion.APM/DependencyTcpStatistics) | Defined by relationship Orion.APM.DependencyTcpStatisticsHostsApplicationTcpConnections (System.Hosting) |
| Dependency | [Orion.Dependencies](./../Orion/Dependencies) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesDependency (System.Reference) |
| ClientInterface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientInterface (System.Reference) |
| ServerInterface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerInterface (System.Reference) |
| ClientApplication | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientApplication (System.Reference) |
| ServerApplication | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerApplication (System.Reference) |
| ClientNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientNode (System.Reference) |
| ServerNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerNode (System.Reference) |
| ClientProcessComponent | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientProcessComponent (System.Reference) |
| ServerProcessComponent | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerProcessComponent (System.Reference) |
| ServerPortComponent | [Orion.APM.Component](./../Orion.APM/Component) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerPortComponent (System.Reference) |


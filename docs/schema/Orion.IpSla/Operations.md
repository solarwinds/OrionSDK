---
id: Operations
slug: Operations
---

# Orion.IpSla.Operations

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationTypeID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| OperationType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperationStateID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| OperationStatusID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| SourceNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TargetNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsAutoConfigured | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Frequency | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LifeTimeUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IpSlaOperationNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OperationNameFull | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplaySource | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayTarget | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DateChangedUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OperationResultRecordTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OperationResultID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| Deleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WebUri | [Orion.IpSla.OperationWebUri](./../Orion.IpSla/OperationWebUri) | Defined by relationship Orion.IpSla.OperationInstanceHostsWebUri (System.Hosting) |
| CurrentStats | [Orion.IpSla.OperationCurrentStats](./../Orion.IpSla/OperationCurrentStats) | Defined by relationship Orion.IpSla.OperationsHostsCurrentStats (System.Hosting) |
| PathHopStats | [Orion.IpSla.PathHopOperationResults](./../Orion.IpSla/PathHopOperationResults) | Defined by relationship Orion.IpSla.OperationsReferencesPathHopOperationResults (System.Hosting) |
| PathHopCurrentStats | [Orion.IpSla.PathHopOperationCurrentStats](./../Orion.IpSla/PathHopOperationCurrentStats) | Defined by relationship Orion.IpSla.OperationsReferencesPathHopOperationCurrentStats (System.Hosting) |
| ParameterInfo | [Orion.IpSla.VoipOperationParameterInfo](./../Orion.IpSla/VoipOperationParameterInfo) | Defined by relationship Orion.IpSla.OperationsHostsVoipOperationParameterInfo (System.Hosting) |
| NonPathOperationStats | [Orion.IpSla.NonPathOperationStats](./../Orion.IpSla/NonPathOperationStats) | Defined by relationship Orion.IpSla.OperationsReferencesNonPathOperationStats (System.Hosting) |
| UdpJitterOperationStats | [Orion.IpSla.UdpJitterOperationStats](./../Orion.IpSla/UdpJitterOperationStats) | Defined by relationship Orion.IpSla.OperationsReferencesUdpJitterOperationStats (System.Hosting) |
| NonMOSUdpJitterOperationStats | [Orion.IpSla.NonMOSUdpJitterOperationStats](./../Orion.IpSla/NonMOSUdpJitterOperationStats) | Defined by relationship Orion.IpSla.OperationsReferencesNonMOSUdpJitterOperationStats (System.Hosting) |
| IcmpPathJitterOperationStats | [Orion.IpSla.IcmpPathJitterOperationStats](./../Orion.IpSla/IcmpPathJitterOperationStats) | Defined by relationship Orion.IpSla.OperationsReferencesIcmpPathJitterOperationStats (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.IpSla.NodeHostsIpSlaOperations (System.Hosting) |
| TargetNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.IpSla.IpSlaOperationsReferencesTargetNode (System.Reference) |
| OperationStatus | [Orion.IpSla.OperationStatuses](./../Orion.IpSla/OperationStatuses) | Defined by relationship Orion.IpSla.IpSlaOperationsReferencesOperationStatus (System.Reference) |
| OperationTypes | [Orion.IpSla.OperationTypes](./../Orion.IpSla/OperationTypes) | Defined by relationship Orion.IpSla.IpSlaOperationsReferencesOperationTypes (System.Reference) |
| OperationStates | [Orion.IpSla.OperationStates](./../Orion.IpSla/OperationStates) | Defined by relationship Orion.IpSla.IpSlaOperationsReferencesOperationStates (System.Reference) |


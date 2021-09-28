---
id: CBQoSPolicy
slug: CBQoSPolicy
---

# Orion.Netflow.CBQoSPolicy

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| InterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolicyMapID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ClassMapID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolicyActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RateBps | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DirectionID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| IsActive | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| HasChildren | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PolicyFullPathName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ParentPolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RootPolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StartDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Statistics | [Orion.Netflow.CBQoSStatistics](./../Orion.Netflow/CBQoSStatistics) | Defined by relationship Orion.Netflow.CBQoSPolicyReferencesCBQoSStatistics (System.Reference) |
| PolicyAction | [Orion.Netflow.CBQoSPolicyAction](./../Orion.Netflow/CBQoSPolicyAction) | Defined by relationship Orion.Netflow.CBQoSPolicyActionReferencesCBQoSPolicy (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Netflow.NodeReferencesCBQoSPolicy (System.Reference) |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.Netflow.InterfaceReferencesCBQoSPolicy (System.Reference) |
| PolicyMetric | [Orion.Netflow.CBQoSPolicyMetric](./../Orion.Netflow/CBQoSPolicyMetric) | Defined by relationship Orion.Netflow.CBQoSPolicyMetricReferencesCBQoSPolicy (System.Reference) |
| ClassMap | [Orion.Netflow.CBQoSClassMap](./../Orion.Netflow/CBQoSClassMap) | Defined by relationship Orion.Netflow.CBQoSClassMapReferencesCBQoSPolicy (System.Reference) |
| PolicyMap | [Orion.Netflow.CBQoSPolicyMap](./../Orion.Netflow/CBQoSPolicyMap) | Defined by relationship Orion.Netflow.CBQoSPolicyMapReferencesCBQoSPolicy (System.Reference) |
| DirectionDescription | [Orion.Netflow.CBQoSDirectionDescription](./../Orion.Netflow/CBQoSDirectionDescription) | Defined by relationship Orion.Netflow.CBQoSDirectionDescriptionReferencesCBQoSPolicy (System.Reference) |


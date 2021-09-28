---
id: CBQoSPolicyAction
slug: CBQoSPolicyAction
---

# Orion.Netflow.CBQoSPolicyAction

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolicyActionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RateType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Rate | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Netflow.NodeReferencesCBQoSPolicyAction (System.Reference) |
| Policy | [Orion.Netflow.CBQoSPolicy](./../Orion.Netflow/CBQoSPolicy) | Defined by relationship Orion.Netflow.CBQoSPolicyActionReferencesCBQoSPolicy (System.Reference) |


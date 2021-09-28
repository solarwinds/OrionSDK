---
id: AssignedPolicyRule
slug: AssignedPolicyRule
---

# Orion.SCM.AssignedPolicyRule

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolicyRuleID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PolicyRulesStatistics | [Orion.SCM.PolicyRuleStatistics](./../Orion.SCM/PolicyRuleStatistics) | Defined by relationship Orion.SCM.AssignedPolicyRuleHostsStatistics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.SCM.NodesHostsAssignedPolicyRules (System.Hosting) |
| PolicyRule | [Orion.SCM.PolicyRule](./../Orion.SCM/PolicyRule) | Defined by relationship Orion.SCM.PolicyRuleReferencesAssignedPolicyRules (System.Reference) |


---
id: AssignedRule
slug: AssignedRule
---

# Orion.PolicyEngine.AssignedRule

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,delete | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RuleID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityIDs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastUpdate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Policy | [Orion.PolicyEngine.Policy](./../Orion.PolicyEngine/Policy) | Defined by relationship Orion.PolicyEngine.PolicyReferencesAssignedRule (System.Reference) |


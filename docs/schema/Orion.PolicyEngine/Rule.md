---
id: Rule
slug: Rule
---

# Orion.PolicyEngine.Rule

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
| RuleID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UniqueId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| PreconditionYAML | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConditionYAML | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Policy | [Orion.PolicyEngine.Policy](./../Orion.PolicyEngine/Policy) | Defined by relationship Orion.PolicyEngine.PolicyHostsRule (System.Hosting) |


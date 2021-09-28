---
id: Policy
slug: Policy
---

# Orion.SCM.Policy

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.SCM.AssignedPolicy](./../Orion.SCM/AssignedPolicy) | Defined by relationship Orion.SCM.PolicyReferencesAssignedPolicy (System.Reference) |
| Rules | [Orion.SCM.PolicyRule](./../Orion.SCM/PolicyRule) | Defined by relationship Orion.SCM.PolicyHostsPolicyRule (System.Hosting) |


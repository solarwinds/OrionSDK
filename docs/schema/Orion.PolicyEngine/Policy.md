---
id: Policy
slug: Policy
---

# Orion.PolicyEngine.Policy

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
| PluginName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UniqueId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.PolicyEngine.AssignedRule](./../Orion.PolicyEngine/AssignedRule) | Defined by relationship Orion.PolicyEngine.PolicyReferencesAssignedRule (System.Reference) |
| Rules | [Orion.PolicyEngine.Rule](./../Orion.PolicyEngine/Rule) | Defined by relationship Orion.PolicyEngine.PolicyHostsRule (System.Hosting) |

## Verbs

### ExportPolicy

#### Access control

everyone

### ImportPolicy

#### Access control

everyone

### AssignToEntity

#### Access control

everyone


---
id: MaintenancePlanAssignment
slug: MaintenancePlanAssignment
---

# Orion.MaintenancePlanAssignment

SolarWinds Information Service 2020.2 Schema Documentation Index

Defines entity which is included in maintenance plan.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete | allowUnmanage |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MaintenancePlanID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Plan | [Orion.MaintenancePlan](./../Orion/MaintenancePlan) | Defined by relationship Orion.MaintenancePlanHostsAssignments (System.Hosting) |


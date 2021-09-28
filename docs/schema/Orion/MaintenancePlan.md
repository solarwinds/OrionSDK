---
id: MaintenancePlan
slug: MaintenancePlan
---

# Orion.MaintenancePlan

SolarWinds Information Service 2020.2 Schema Documentation Index

Plan defining maintenance schedule for entities being unmanaged.

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
| AccountID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Reason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| KeepPolling | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Favorite | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnmanageDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RemanageDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.MaintenancePlanAssignment](./../Orion/MaintenancePlanAssignment) | Defined by relationship Orion.MaintenancePlanHostsAssignments (System.Hosting) |


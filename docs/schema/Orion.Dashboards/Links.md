---
id: Links
slug: Links
---

# Orion.Dashboards.Links

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| WidgetID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DashboardID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Dashboards | [Orion.Dashboards.Instances](./../Orion.Dashboards/Instances) | Defined by relationship Orion.Dashboard.DashboardReferencesLinks (System.Reference) |
| Widgets | [Orion.Dashboards.Widgets](./../Orion.Dashboards/Widgets) | Defined by relationship Orion.Dashboard.WidgetReferencesLinks (System.Reference) |


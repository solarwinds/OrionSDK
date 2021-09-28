---
id: Pollers
slug: Pollers
---

# Orion.DeviceStudio.Pollers

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PollerID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| TechnologyID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Author | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Tags | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Priority | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| TechnologyPollingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Assignments | [Orion.DeviceStudio.PollerAssignments](./../Orion.DeviceStudio/PollerAssignments) | Defined by relationship Orion.DeviceStudio.PollersHostsPollerAssignments (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Technology | [Orion.DeviceStudio.Technologies](./../Orion.DeviceStudio/Technologies) | Defined by relationship Orion.DeviceStudio.TechnologiesHostsPollers (System.Hosting) |


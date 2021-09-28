---
id: NodeInventory
slug: NodeInventory
---

# Orion.ADM.NodeInventory

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Plugins | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsClusterVIP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.ADM.NodeHostsNodeInventory (System.Hosting) |

## Verbs

### PollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### Enable

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### Disable

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### SchedulePollNow

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### ScheduleEnable

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UninstallConnectionQualityAgentPlugin

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


---
id: TechnologyPollingAssignments
slug: TechnologyPollingAssignments
---

# Orion.TechnologyPollingAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| TechnologyPollingID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TargetEntity | [System.Type](https://docs.microsoft.com/en-us/dotnet/api/system.type) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TechnologyPolling | [Orion.TechnologyPolling](./../Orion/TechnologyPolling) | Defined by relationship Orion.TechnologyPollingHostTechnologyPollingAssignments (System.Hosting) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesReferenceTechnologyPollingAssignments (System.Reference) |
| Volume | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.VolumesReferenceTechnologyPollingAssignments (System.Reference) |

## Verbs

### EnableAssignments

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DisableAssignments

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### EnableAssignmentsOnNetObjects

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |

### DisableAssignmentsOnNetObjects

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | admin |


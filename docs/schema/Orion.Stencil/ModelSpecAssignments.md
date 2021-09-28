---
id: ModelSpecAssignments
slug: ModelSpecAssignments
---

# Orion.Stencil.ModelSpecAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ModelSpecAssignmentID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ModelSpecID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ModelSpec | [Orion.Stencil.ModelSpecs](./../Orion.Stencil/ModelSpecs) | Defined by relationship Orion.ModelSpecAssignmentsSpecs (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeSpecAssignments | [Orion.Stencil.NodeSpecAssignments](./../Orion.Stencil/NodeSpecAssignments) | Defined by relationship Orion.NodeSpecAssignmentsModelSpecAssignment (System.Reference) |


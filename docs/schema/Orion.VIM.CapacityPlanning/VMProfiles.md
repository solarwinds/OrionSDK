---
id: VMProfiles
slug: VMProfiles
---

# Orion.VIM.CapacityPlanning.VMProfiles

SolarWinds Information Service 2020.2 Schema Documentation Index

Virtual machine profile used for workload simulation. It can be existing virtual machine or custom virtual machine profile.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of virtual machine profile | everyone |
| ReportDefinitionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of appropriate report definition | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Profile name | everyone |
| InstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | How many instances of the profile will be used in computation | everyone |
| Counters | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Information about counters and utilization | everyone |
| VirtualMachineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | When profile represents existing virtual machine, it contains unique identifier of existing virtual machine | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReportDefinition | [Orion.VIM.CapacityPlanning.ReportDefinitions](./../Orion.VIM.CapacityPlanning/ReportDefinitions) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionsHostVMProfiles (System.Hosting) |


---
id: HostProfiles
slug: HostProfiles
---

# Orion.VIM.CapacityPlanning.HostProfiles

SolarWinds Information Service 2020.2 Schema Documentation Index

Host profile used for resources simulation. It can be existing host or custom host profile.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of host profile | everyone |
| ReportDefinitionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of appropriate report definition | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Host profile name | everyone |
| InstanceCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | How many instances of the profile will be used in computation | everyone |
| CpuCoreCount | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | CPU core count | everyone |
| CpuCoreFrequency | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | CPU core frequency | everyone |
| MemoryCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Memory capacity | everyone |
| DiskSpaceCapacity | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Disk space capacity | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReportDefinition | [Orion.VIM.CapacityPlanning.ReportDefinitions](./../Orion.VIM.CapacityPlanning/ReportDefinitions) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionsHostHostProfiles (System.Hosting) |


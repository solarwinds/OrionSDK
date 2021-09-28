---
id: ReportDefinitions
slug: ReportDefinitions
---

# Orion.VIM.CapacityPlanning.ReportDefinitions

SolarWinds Information Service 2020.2 Schema Documentation Index

Capacity Planning report definition containing necessary data for calculation

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of report definition | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Report name | everyone |
| EntityNetObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Entity netObjectID, that Capacity Planning is computed for | everyone |
| EntityCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Entity caption, that Capacity Planning is computed for | everyone |
| UtilizationPeriodInDays | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Amount of historical data used for computation | everyone |
| Runway | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Number of projected days | everyone |
| FailoverReservation | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Failover reservation | everyone |
| Counters | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Information about counters used in computation | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time of definition creation | everyone |
| SimulatedResourcesEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag whether Capacity Planning simulates resources | everyone |
| SimulatedWorkloadsEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag whether Capacity Planning simulates workload | everyone |
| ResourceAllocationType | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) | Type of Capacity Planning computation | everyone |
| ComputeTotalUtilizationTrend | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag whether trend should be computed from total utilization of all VMs or from each VM separately | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Result | [Orion.VIM.CapacityPlanning.ReportResults](./../Orion.VIM.CapacityPlanning/ReportResults) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionHostResults (System.Hosting) |
| VMProfiles | [Orion.VIM.CapacityPlanning.VMProfiles](./../Orion.VIM.CapacityPlanning/VMProfiles) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionsHostVMProfiles (System.Hosting) |
| HostProfiles | [Orion.VIM.CapacityPlanning.HostProfiles](./../Orion.VIM.CapacityPlanning/HostProfiles) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionsHostHostProfiles (System.Hosting) |


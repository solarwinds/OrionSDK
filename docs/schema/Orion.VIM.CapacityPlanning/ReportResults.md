---
id: ReportResults
slug: ReportResults
---

# Orion.VIM.CapacityPlanning.ReportResults

SolarWinds Information Service 2020.2 Schema Documentation Index

Capacity Planning report result containing all computed data

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of report result | everyone |
| ReportDefinitionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of appropriate report definition | everyone |
| ReportStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status of computation | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Contains error message in case that Capacity Planning computation failed | everyone |
| ComputationDateStarted | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time of computation start | everyone |
| ComputationDateFinished | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time of computation end | everyone |
| SimulationResult | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Contains computed data in JSON format | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Definition | [Orion.VIM.CapacityPlanning.ReportDefinitions](./../Orion.VIM.CapacityPlanning/ReportDefinitions) | Defined by relationship Orion.VIM.CapacityPlanning.ReportDefinitionHostResults (System.Hosting) |


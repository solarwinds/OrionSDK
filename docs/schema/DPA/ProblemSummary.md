---
id: ProblemSummary
slug: ProblemSummary
---

# DPA.ProblemSummary

SolarWinds Information Service 2020.2 Schema Documentation Index

Represents single problem summary in relation to analysis (Advisors)

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProblemId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Unique identifier of the problem. | everyone |
| AnalysisId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Analysis (entity not available yet). | everyone |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| Category | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Currently SQL only. | everyone |
| AlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Problem alarm level string (Unknown, Normal, Warning, Critical, None or Freeware) | everyone |
| Score | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Score of the problem. | everyone |
| Item | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Item identifier (e.g. 4845492118). | everyone |
| ItemDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Item descriprion (e.g. Query 4845492118). | everyone |
| Summary | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Summary of the problem. | everyone |
| RunTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Run Time of analysis. | everyone |
| StartTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Start Time of analysis. Default is 30 days ago from current time (Now - 30 days). | everyone |
| EndTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | End Time of analysis. Default is the current time. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseInstance | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.DatabaseInstanceProblemSummary (System.Reference) |


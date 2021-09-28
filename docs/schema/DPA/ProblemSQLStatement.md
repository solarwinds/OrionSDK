---
id: ProblemSQLStatement
slug: ProblemSQLStatement
---

# DPA.ProblemSQLStatement

SolarWinds Information Service 2020.2 Schema Documentation Index

Single problem related to SQL Statement execution

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
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| Category | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Currently SQL only. | everyone |
| SqlHash | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SQL hash. | everyone |
| SqlText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SQL text | everyone |
| TotalSqlWaitTime | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Total SQL wait time (across all executions) | everyone |
| PercentOfTotalDatabaseWaitTime | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | % of total instance execution time. | everyone |


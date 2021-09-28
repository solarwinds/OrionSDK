---
id: ApplicationAlert
slug: ApplicationAlert
---

# Orion.APM.ApplicationAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents all applications. Used in alerting

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ApplicationName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application. | everyone |
| ApplicationAvailability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application availability. | everyone |
| ComponentsWithProblemsFormatted | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the components with problems. | everyone |
| SystemSummaryFormatted | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the system summary. | everyone |
| ComponentsWithProblems | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Provides a comma-delimited list of components in a down, unknown, warning, or critical state. | everyone |
| ComponentsWithStatusFormattedHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | List of components with component status Formatted with html tags for events that appear on the web console. | everyone |
| ComponentsWithStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Provides a comma-delimited list of all components and their current status. | everyone |
| ComponentsWithStatusFormatted | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | List of components with component status included formatted with html tags. Html formatting is used for send e-mail action to provide improved appearance of listed components. | everyone |
| ComponentsWithProblemsFormattedHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | List of components that are not up along with component status included. Formatted with html tags for events that appear on the web console. | everyone |
| SystemSummaryFormattedHtml | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | System summary. Formatted with html tags for events that appear on the web console. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.ApplicationAlertReferencesApplication (System.Reference) |


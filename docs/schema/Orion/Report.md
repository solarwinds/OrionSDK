---
id: Report
slug: Report
---

# Orion.Report

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| read,update | manageReports |
| read,update,invoke | manageReports |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ReportID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Category | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Title | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SubTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LegacyPath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Definition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ModuleTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RecipientList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LimitationCategory | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastRenderDuration | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionFeatureName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionFeature | [Orion.Features](./../Orion/Features) | Defined by relationship Orion.ReportOrionFeatures (System.Reference) |
| CustomProperties | [Orion.ReportsCustomProperties](./../Orion/ReportsCustomProperties) | Defined by relationship Orion.ReportsHostsCustomProperties (System.Hosting) |

## Verbs

### DuplicateReport

#### Access control

everyone

### CreateReport

#### Access control

everyone

### UpdateReport

#### Access control

everyone


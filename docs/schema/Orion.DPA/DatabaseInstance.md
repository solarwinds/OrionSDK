---
id: DatabaseInstance
slug: DatabaseInstance
---

# Orion.DPA.DatabaseInstance

SolarWinds Information Service 2020.2 Schema Documentation Index

Represents single monitored database instance

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of the monitored database. | everyone |
| GlobalDatabaseInstanceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| GroupId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to DatabaseGroup.Id. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Monitored database name/label. | everyone |
| Host | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Host/machine name on which the database is running. | everyone |
| IP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP address on which the database is running. | everyone |
| Port | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Port on which the database is running. | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of database. Possible values: Unknown, Oracle, SQL Server, DB2, Sybase. | everyone |
| Version | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The vendor version of this database or "" if version information has not been collected for database. | everyone |
| VersionSuffix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Version suffix | everyone |
| MonitorStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Possible values 0..7. Reference to DPA.MonitorStatus.Id | everyone |
| MonitorStatusText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Text representation of MonitorStatus | everyone |
| IsLicensed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag if DB instance is licensed | everyone |
| OverallAlarmLevel | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Overall alarm level. Max from performance overview. | everyone |
| DefaultDatabase | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Default database | everyone |
| OracleSID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SID for Oracle | everyone |
| ServiceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Service name for Oracle database | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numerical value of status | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of status | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | DB Instance detail url | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of DB instance with name of DPA server monitoring this DB instance | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type of DB Instance including version | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.Rely.DPA.DatabaseInstanceRelyOnNodes (System.Reliance) |
| TimeSeriesDefinition | [DPA.TimeSeriesDefinition](./../DPA/TimeSeriesDefinition) | Defined by relationship Orion.DatabaseInstanceTimeSeriesDefinition (System.Reference) |
| TimeSeriesData | [DPA.TimeSeriesData](./../DPA/TimeSeriesData) | Defined by relationship Orion.DatabaseInstanceTimeSeriesData (System.Reference) |
| PerformanceOverview | [DPA.PerformanceOverview](./../DPA/PerformanceOverview) | Defined by relationship Orion.DatabaseInstancePerformanceOverview (System.Reference) |
| DpaServer | [Orion.DPA.DpaServer](./../Orion.DPA/DpaServer) | Defined by relationship Orion.DpaServerDatabaseInstance (System.Reference) |
| ProblemSummary | [DPA.ProblemSummary](./../DPA/ProblemSummary) | Defined by relationship Orion.DatabaseInstanceProblemSummary (System.Reference) |
| TrendDataDimension | [DPA.TrendDataDimension](./../DPA/TrendDataDimension) | Defined by relationship Orion.DatabaseInstanceTrendDataDimension (System.Reference) |
| DetailDataDimension | [DPA.DetailDataDimension](./../DPA/DetailDataDimension) | Defined by relationship Orion.DatabaseInstanceDetailDataDimension (System.Reference) |
| ResourceDefinition | [DPA.ResourceDefinition](./../DPA/ResourceDefinition) | Defined by relationship Orion.ResourceDefinitionDatabaseInstance (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RelyApplications | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.Rely.DPA.ApplicationsRelyOnDatabaseInstances (System.Reliance) |
| Data | [Orion.DPA.DatabaseInstanceData](./../Orion.DPA/DatabaseInstanceData) | Defined by relationship Orion.DatabaseInstanceDataDatabaseInstance (System.Reference) |
| StatusInfo | [Orion.StatusInfo](./../Orion/StatusInfo) | Defined by relationship Orion.StatusInfoDatabaseInstance (System.Reference) |
| ApplicationReference | [Orion.DPA.DatabaseInstanceApplication](./../Orion.DPA/DatabaseInstanceApplication) | Defined by relationship Orion.DatabaseInstanceApplicationDatabaseInstance (System.Reference) |
| UsedByApplicationReference | [Orion.DPA.DatabaseInstanceClientApplication](./../Orion.DPA/DatabaseInstanceClientApplication) | Defined by relationship Orion.DatabaseInstanceClientApplicationDatabaseInstance (System.Reference) |
| ServerApplication | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.DatabaseInstanceServerApplication (System.Reference) |
| LunReference | [Orion.DPA.DatabaseInstanceLun](./../Orion.DPA/DatabaseInstanceLun) | Defined by relationship Orion.DatabaseInstanceLunDatabaseInstance (System.Reference) |
| Lun | [Orion.SRM.LUNs](./../Orion.SRM/LUNs) | Defined by relationship Orion.DatabaseInstanceLun (System.Reference) |


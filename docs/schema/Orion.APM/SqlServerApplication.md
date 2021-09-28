---
id: SqlServerApplication
slug: SqlServerApplication
---

# Orion.APM.SqlServerApplication

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents AppInsight for SQL application.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.Application](./../Orion.APM/Application)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InstanceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of SQL server instance. | everyone |
| ProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server version. | everyone |
| ProductLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server level. | everyone |
| Edition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server edition. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Databases | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlServerHostsSqlDatabase (System.Hosting) |
| SqlJobInfo | [Orion.APM.SqlJobInfo](./../Orion.APM/SqlJobInfo) | Defined by relationship Orion.APM.SqlServerApplicationHostsSqlJobInfo (System.Hosting) |
| SqlClusterNodes | [Orion.APM.SqlClusterNode](./../Orion.APM/SqlClusterNode) | Defined by relationship Orion.APM.SqlServerHostsSqlClusterNodes (System.Hosting) |
| SqlApplicationAlert | [Orion.APM.SqlServerApplicationAlert](./../Orion.APM/SqlServerApplicationAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertReferencesSqlServerApplication (System.Reference) |


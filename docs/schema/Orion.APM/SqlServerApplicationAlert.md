---
id: SqlServerApplicationAlert
slug: SqlServerApplicationAlert
---

# Orion.APM.SqlServerApplicationAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents AppInsight for SQL application. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| Availability | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The integer value that contains the application availability. | everyone |
| LastTimeUp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time when application has Up status. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for application. | everyone |
| TemplateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the application template description. | everyone |
| InstanceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of SQL server instance. | everyone |
| ProductVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server version. | everyone |
| ProductLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server level. | everyone |
| Edition | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the SQL server edition. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlDatabase | [Orion.APM.SqlDatabase](./../Orion.APM/SqlDatabase) | Defined by relationship Orion.APM.SqlServerApplicationAlertReferencesSqlDatabase (System.Reference) |
| SqlDatabaseAlert | [Orion.APM.SqlDatabaseAlert](./../Orion.APM/SqlDatabaseAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlDatabaseAlert (System.Hosting) |
| SqlDatabaseFileAlert | [Orion.APM.SqlDatabaseFileAlert](./../Orion.APM/SqlDatabaseFileAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlDatabaseFileAlert (System.Hosting) |
| SqlQueryAlert | [Orion.APM.SqlQueryAlert](./../Orion.APM/SqlQueryAlert) | Defined by relationship Orion.APM.SqlServerApplicationAlertHostsSqlQueryAlert (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SqlApplication | [Orion.APM.SqlServerApplication](./../Orion.APM/SqlServerApplication) | Defined by relationship Orion.APM.SqlServerApplicationAlertReferencesSqlServerApplication (System.Reference) |


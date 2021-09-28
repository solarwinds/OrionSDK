---
id: DatabaseAlert
slug: DatabaseAlert
---

# Orion.APM.Exchange.DatabaseAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox database information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of mailbox database. | everyone |
| DatabaseIdentity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string representation of mailbox database. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database status. | everyone |
| PreferredServer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of preferred server. | everyone |
| ServerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of parent node. | everyone |
| IsOnPreferredServer | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The boolean value that specifies if database is on preferred server. | everyone |
| DisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database status. | everyone |
| LastFailoverTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The last fail over date and time. | everyone |
| LastFailoverTimeStampDiff | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The last fail over date and time. | everyone |
| ActiveCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database active copy. | everyone |
| ActiveCopyActivationPreference | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy activation preference. | everyone |
| ActiveApplicationName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application. | everyone |
| FileUsedTotalSpacePercentageMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum number of database file space usage. | everyone |
| LogDirUsedTotalSpacePercentageMax | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains the maximum number of database log space usage. | everyone |
| DaysFromLastFullBackup | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of days passed since last full database backup. | everyone |
| DaysFromLastIncrementalBackup | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of days passed since last incremental database backup. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.Database](./../Orion.APM.Exchange/Database) | Defined by relationship Orion.APM.Exchange.DatabaseAlertReferencesDatabase (System.Reference) |


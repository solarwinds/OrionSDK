---
id: DatabaseCopy
slug: DatabaseCopy
---

# Orion.APM.Exchange.DatabaseCopy

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox database copy information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.ApplicationItem](./../Orion.APM/ApplicationItem)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database copy. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database. | everyone |
| DatabaseName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of mailbox database. | everyone |
| ActiveDatabaseCopy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of active database copy. | everyone |
| IsActive | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if database copy is active. | everyone |
| LastInspectedLogTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The modification time of the last log that was successfully validated by the node hosting the copy. | everyone |
| CopyState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy state. | everyone |
| DisplayCopyState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database copy state. | everyone |
| CopyQueueLength | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Indicates the number of log files waiting to be copied and inspected. | everyone |
| ReplayQueueLength | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Indicates the number of log files waiting to be replayed into this copy of the database. | everyone |
| StatusCopyQueueLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Indicates the number of log files waiting to be copied and inspected. | everyone |
| StatusReplayQueueLength | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Indicates the number of log files waiting to be replayed into this copy of the database. | everyone |
| ContentIndexState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the content index state. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last poll for database copy. | everyone |
| ActivationPreference | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy activation preference. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy status. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database copy status description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to database copy details page. Used in alerting. | everyone |
| WebUri | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the database copy details page URL. It is used by Network Atlas. | everyone |
| ItemType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The type of application item. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.Database](./../Orion.APM.Exchange/Database) | Defined by relationship Orion.APM.Exchange.ActiveDatabaseCopyReferencesDatabase (System.Reference) |
| DatabaseCopyStatistics | [Orion.APM.Exchange.DatabaseCopyStatistics](./../Orion.APM.Exchange/DatabaseCopyStatistics) | Defined by relationship Orion.APM.Exchange.DatabaseCopyHostsDatabaseCopyStatistics (System.Hosting) |
| LogDir | [Orion.APM.Exchange.TransactionLogDir](./../Orion.APM.Exchange/TransactionLogDir) | Defined by relationship Orion.APM.Exchange.TransactionLogDirMailboxDatabaseCopy (System.Hosting) |
| Files | [Orion.APM.Exchange.DatabaseFile](./../Orion.APM.Exchange/DatabaseFile) | Defined by relationship Orion.APM.Exchange.DatabaseFileDatabase (System.Hosting) |
| DatabaseCopyAlert | [Orion.APM.Exchange.DatabaseCopyAlert](./../Orion.APM.Exchange/DatabaseCopyAlert) | Defined by relationship Orion.APM.Exchange.DatabaseCopyAlertReferencesDatabaseCopy (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.Database](./../Orion.APM.Exchange/Database) | Defined by relationship Orion.APM.Exchange.DatabaseReferencesDatabaseCopy (System.Reliance) |
| Application | [Orion.APM.Exchange.Application](./../Orion.APM.Exchange/Application) | Defined by relationship Orion.APM.Exchange.ApplicatinHostsDatabaseCopy (System.Hosting) |


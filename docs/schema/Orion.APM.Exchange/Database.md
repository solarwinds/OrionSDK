---
id: Database
slug: Database
---

# Orion.APM.Exchange.Database

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox database information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database. | everyone |
| Identity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string representation of mailbox database. | everyone |
| Guid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The mailbox database GUID. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains mailbox database status. | everyone |
| ServerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of parent node. | everyone |
| ServerNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| PreferredServer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of preferred server. | everyone |
| PreferredNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of proffered node. | everyone |
| MasterType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer that contains the type of mailbox database master. | everyone |
| DisplayMasterType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the type of mailbox database master. | everyone |
| MasterServerID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of the master server for the mailbox database. | everyone |
| MasterDagID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of the master server database availability group. | everyone |
| LastFullBackup | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last complete backup of the mailbox database. | everyone |
| LastIncrementalBackup | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last incremental backup of the mailbox database. | everyone |
| CircularLoggingEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that contains circular logging enabled value. | everyone |
| IssueWarningQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox database size at which a warning message is sent to the user. | everyone |
| ProhibitSendQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox database size at which users can no longer send messages. | everyone |
| ProhibitSendReceiveQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox database size at which the user is prohibited from sending or receiving email messages. | everyone |
| LastSuccessfulMailboxPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of last successful poll for mailboxes. | everyone |
| ActiveCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database active copy. | everyone |
| TotalMailboxes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the number of mailboxes. | everyone |
| AvgMailBoxSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The integer value that contains the average mailbox size. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox database status description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to mailbox database details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Copies | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.DatabaseReferencesDatabaseCopy (System.Reliance) |
| DatabaseStatistics | [Orion.APM.Exchange.DatabaseStatistics](./../Orion.APM.Exchange/DatabaseStatistics) | Defined by relationship Orion.APM.Exchange.DatabaseHostsDatabaseStatistics (System.Hosting) |
| Mailboxes | [Orion.APM.Exchange.Mailbox](./../Orion.APM.Exchange/Mailbox) | Defined by relationship Orion.APM.Exchange.MailboxHosting (System.Hosting) |
| DatabaseAlert | [Orion.APM.Exchange.DatabaseAlert](./../Orion.APM.Exchange/DatabaseAlert) | Defined by relationship Orion.APM.Exchange.DatabaseAlertReferencesDatabase (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ActiveCopy | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.ActiveDatabaseCopyReferencesDatabase (System.Reference) |


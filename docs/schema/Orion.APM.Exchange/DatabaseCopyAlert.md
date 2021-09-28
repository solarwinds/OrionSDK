---
id: DatabaseCopyAlert
slug: DatabaseCopyAlert
---

# Orion.APM.Exchange.DatabaseCopyAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox database copy information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application. | everyone |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox database copy. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of mailbox database copy. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy status. | everyone |
| DisplayStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The integer value that contains database copy status. | everyone |
| ActivationPreference | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy activation preference. | everyone |
| ActiveCopy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of active database copy. | everyone |
| ActiveCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database active copy. | everyone |
| DatabaseIdentity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string representation of mailbox database. | everyone |
| DatabaseStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains database copy status. | everyone |
| DisplayDatabaseStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database copy status. | everyone |
| ApplicationName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the application. | everyone |
| FileUsedTotalPercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of database file disk space usage. | everyone |
| LogUsedTotalPercentage | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The percentage representation of transaction log disk space usage. | everyone |
| ContentIndexState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the content index state. | everyone |
| DisplayContentIndexState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the content index state. | everyone |
| CopyState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains the database copy state. | everyone |
| DisplayCopyState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the database copy state. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| DatabaseCopy | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.DatabaseCopyAlertReferencesDatabaseCopy (System.Reference) |


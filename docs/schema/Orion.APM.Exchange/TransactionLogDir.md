---
id: TransactionLogDir
slug: TransactionLogDir
---

# Orion.APM.Exchange.TransactionLogDir

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the transaction log directory.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction log directory. | everyone |
| DatabaseCopyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent database copy. | everyone |
| VolumeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of transaction log directory volume. | everyone |
| PhysicalName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that specifies the name of the directory where transaction log files are stored. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for transaction log directory info. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains transaction log directory status. | everyone |
| Size | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies the size of transaction log directory files. | everyone |
| FilesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that specifies the transaction log directory files count. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MailboxDatabaseCopy | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.TransactionLogDirMailboxDatabaseCopy (System.Hosting) |


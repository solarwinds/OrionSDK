---
id: MailboxAlert
slug: MailboxAlert
---

# Orion.APM.Exchange.MailboxAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer of database, where the mailbox resides. | everyone |
| TotalItemSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox items size. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox display name. | everyone |
| PrimarySmtpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox primary SMTP address. | everyone |
| ItemCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that specifies mailbox items count. | everyone |
| PercentUsedQuota | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The double value that contains percent of used quota. | everyone |
| AttachmentsSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox attachments size. | everyone |
| MailboxWarningLimit | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox size at which a warning message is sent to the user. | everyone |
| MailboxProhibitSend | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox size at which users can no longer send messages. | everyone |
| MailboxProhibitSendReceive | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox  size at which the user is prohibited from sending or receiving email messages. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that mailbox status. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Mailbox | [Orion.APM.Exchange.Mailbox](./../Orion.APM.Exchange/Mailbox) | Defined by relationship Orion.APM.Exchange.MailboxAlertReferencesMailbox (System.Reference) |


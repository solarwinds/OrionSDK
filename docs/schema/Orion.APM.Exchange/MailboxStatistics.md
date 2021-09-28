---
id: MailboxStatistics
slug: MailboxStatistics
---

# Orion.APM.Exchange.MailboxStatistics

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox statistics.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

↳ [System.StatisticsEntity](./../System/StatisticsEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MailboxID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date of poll for mailbox data. | everyone |
| TotalItemSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox items size. | everyone |
| ItemCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that specifies mailbox items count. | everyone |
| AttachmentsSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox attachments size. | everyone |
| AttachmentsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that specifies mailbox attachments count. | everyone |
| LastLogonTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last mailbox logon. | everyone |
| LastLogonUserAccount | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the account name last used to log on to the mailbox. | everyone |
| PercentUsedQuota | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | The decimal value that contains percent of used quota. | everyone |


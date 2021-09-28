---
id: Mailbox
slug: Mailbox
---

# Orion.APM.Exchange.Mailbox

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the mailbox information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox. | everyone |
| DatabaseID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent mailbox database. | everyone |
| DatabaseName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains database name. | everyone |
| UserLogonName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains user login name. | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains user name. | everyone |
| UniqueID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The mailbox GUID. | everyone |
| Type | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains mailbox type. | everyone |
| OrganizationalUnit | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox organizational unit. | everyone |
| PrimarySmtpAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox primary SMTP address. | everyone |
| LastModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last mailbox modification. | everyone |
| TotalItemSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox items size. | everyone |
| ItemCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that specifies mailbox items count. | everyone |
| AttachmentsSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that specifies mailbox attachments size. | everyone |
| AttachmentsCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The long value that specifies mailbox attachments count. | everyone |
| LastLogonTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last mailbox logon. | everyone |
| LastLogonUserAccount | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the account name last used to log on to the mailbox. | everyone |
| UseDatabaseQuotaDefaults | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies whether this mailbox uses the database defaults for quota properties. | everyone |
| ProhibitSendQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox size at which users can no longer send messages. | everyone |
| ProhibitSendReceiveQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox  size at which the user is prohibited from sending or receiving email messages. | everyone |
| IssueWarningQuota | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contains the mailbox size at which a warning message is sent to the user. | everyone |
| PercentageOfUsedQuota | [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/system.decimal) | The decimal value that contains percentage of used quota. | everyone |
| MessagesSentInternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent internal emails. | everyone |
| MessagesSentInternalSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the size of sent internal emails. | everyone |
| MessagesSentExternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent external emails. | everyone |
| MessagesSentExternalSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the size of sent external emails. | everyone |
| MessagesSent | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the total number of sent emails. | everyone |
| MessagesSentSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the total size of sent emails. | everyone |
| MessagesReceivedInternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of received internal emails. | everyone |
| MessagesReceivedInternalSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the size of received internal emails. | everyone |
| MessagesReceivedExternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of received external emails. | everyone |
| MessagesReceivedExternalSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the size of received external emails. | everyone |
| MessagesReceived | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the total number of received emails. | everyone |
| MessagesReceivedSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The long value that contain the total size of received emails. | everyone |
| MessagesSentLastSevenDaysInternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent internal emails in last 7 days. | everyone |
| MessagesSentLastSevenDaysExternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent external emails in last 7 days. | everyone |
| MessagesSentLastSevenDays | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the total number of sent emails in last 7 days. | everyone |
| MessagesSentLastThirtyDaysInternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent internal emails in last 30 days. | everyone |
| MessagesSentLastThirtyDaysExternal | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the number of sent external emails in last 30 days. | everyone |
| MessagesSentLastThirtyDays | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contain the total number of sent emails in last 30 days. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that indicates mailbox entity description. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains mailbox status. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains mailbox status description. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to mailbox details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| MailboxAlert | [Orion.APM.Exchange.MailboxAlert](./../Orion.APM.Exchange/MailboxAlert) | Defined by relationship Orion.APM.Exchange.MailboxAlertReferencesMailbox (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Database | [Orion.APM.Exchange.Database](./../Orion.APM.Exchange/Database) | Defined by relationship Orion.APM.Exchange.MailboxHosting (System.Hosting) |


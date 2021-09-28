---
id: SyncedDevices
slug: SyncedDevices
---

# Orion.APM.Exchange.SyncedDevices

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the exchange synced devices.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MailboxID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of mailbox. | everyone |
| ID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The unique integer representation of mailbox synced device. | everyone |
| DeviceType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the device type. | everyone |
| DeviceUserAgent | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the device user agent. | everyone |
| LastSuccessfulSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date and time of the last synchronization. | everyone |


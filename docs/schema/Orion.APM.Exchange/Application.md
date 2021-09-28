---
id: Application
slug: Application
---

# Orion.APM.Exchange.Application

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Exchange application information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.Application](./../Orion.APM/Application)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ServerIdentity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The unique string representation of Exchange server. | everyone |
| ServerGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The Exchange server GUID. | everyone |
| DomainID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of Exchange server domain. | everyone |
| AdminDisplayVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the Exchange server build information. | everyone |
| DatabaseAvailabilityGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of database availability group. | everyone |
| ServerRole | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the Exchange server role. | everyone |
| HasMessageTrackingLog | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The boolean value that specifies if message tracking log is enabled or no. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReplicationStatus | [Orion.APM.Exchange.ReplicationStatus](./../Orion.APM.Exchange/ReplicationStatus) | Defined by relationship Orion.APM.Exchange.ApplicationHostsReplicationStatus (System.Hosting) |
| DatabaseCopies | [Orion.APM.Exchange.DatabaseCopy](./../Orion.APM.Exchange/DatabaseCopy) | Defined by relationship Orion.APM.Exchange.ApplicatinHostsDatabaseCopy (System.Hosting) |
| ExchangeApplicationAlert | [Orion.APM.Exchange.ApplicationAlert](./../Orion.APM.Exchange/ApplicationAlert) | Defined by relationship Orion.APM.Exchange.ApplicationAlertReferencesApplication (System.Reference) |


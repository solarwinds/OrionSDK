---
id: ReplicationStatus
slug: ReplicationStatus
---

# Orion.APM.Exchange.ReplicationStatus

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Exchange server replication status information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of replication status. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SAM application. | everyone |
| CheckName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains replication entity name (ClusterService, ReplayService, ActiveManager...). | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains replication entity status. | everyone |
| StatusName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains replication entity status. | everyone |
| Error | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains replication status error message. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to replication details page. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReplicationStatusAlert | [Orion.APM.Exchange.ReplicationStatusAlert](./../Orion.APM.Exchange/ReplicationStatusAlert) | Defined by relationship Orion.APM.Exchange.ReplicationStatusAlertReferencesReplicationStatus (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ExchangeApplication | [Orion.APM.Exchange.Application](./../Orion.APM.Exchange/Application) | Defined by relationship Orion.APM.Exchange.ApplicationHostsReplicationStatus (System.Hosting) |


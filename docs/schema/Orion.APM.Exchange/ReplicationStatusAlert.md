---
id: ReplicationStatusAlert
slug: ReplicationStatusAlert
---

# Orion.APM.Exchange.ReplicationStatusAlert

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the Exchange server replication status information. Used in alerting.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of replication status. | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent SAM application. | everyone |
| CheckName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains replication entity name (ClusterService, ReplayService, ActiveManager...) | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains replication entity status. | everyone |
| Error | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains error message. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReplicationStatus | [Orion.APM.Exchange.ReplicationStatus](./../Orion.APM.Exchange/ReplicationStatus) | Defined by relationship Orion.APM.Exchange.ReplicationStatusAlertReferencesReplicationStatus (System.Reference) |


---
id: Replication
slug: Replication
---

# Orion.APM.ActiveDirectory.Replication

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Active Directory replication information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique numeric identifier of Replication entity. | everyone |
| SourceNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of source Node. | everyone |
| DestinationNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of destination Node. | everyone |
| SourceDomainControllerFqdn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Fully qualified domain name of source domain controller. | everyone |
| DestinationDomainControllerFqdn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Fully qualified domain name of destination domain controller. | everyone |
| NamingContextID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the Naming Context. | everyone |
| TransportType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Transport type for a Replication (IP, SMTP, RPC) as number. | everyone |
| TransportTypeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Transport type for a Replication (IP, SMTP, RPC). | everyone |
| ConsecutiveSyncFailureCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of consecutive replication failures. | everyone |
| LastFailureTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last time there was a failure detected. | everyone |
| LastSuccessTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last time the replication succeeded. | everyone |
| LastAttemptTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last time there was a replication attempt. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Replication status (Orion Status) as last seen. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains application status description. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SourceNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationSourceNode (System.Reference) |
| DestinationNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationDestinationNode (System.Reference) |
| NamingContext | [Orion.APM.ActiveDirectory.NamingContext](./../Orion.APM.ActiveDirectory/NamingContext) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationNamingContext (System.Reference) |


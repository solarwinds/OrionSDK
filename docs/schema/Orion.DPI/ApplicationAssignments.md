---
id: ApplicationAssignments
slug: ApplicationAssignments
---

# Orion.DPI.ApplicationAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | read: everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ART | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| NRT | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| Ingress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| IngressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| Egress | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| EgressPerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| DataVolume | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| DataVolumePerSec | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Transactions | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| TransactionsPerMin | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | read: everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.DPI.NodeToApplicationAssignment (System.Hosting) |
| Application | [Orion.DPI.Applications](./../Orion.DPI/Applications) | Defined by relationship Orion.DPI.ApplicationsToApplicationAssignments (System.Reference) |


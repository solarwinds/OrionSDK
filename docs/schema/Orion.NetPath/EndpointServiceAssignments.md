---
id: EndpointServiceAssignments
slug: EndpointServiceAssignments
---

# Orion.NetPath.EndpointServiceAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains the assignments between probes and the services they monitor. A probe can monitor multiple services, and a service can be monitored by multiple probes.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EndpointServiceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastProbeTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Threshold | [Orion.NetPath.Thresholds](./../Orion.NetPath/Thresholds) | Defined by relationship Orion.NetPath.EndpointServiceAssignmentsReferencesThresholds (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ProbeBase | [Orion.NetPath.ProbesBase](./../Orion.NetPath/ProbesBase) | Defined by relationship Orion.NetPath.ProbesBaseReferencesEndpointServiceAssignments (System.Reference) |
| EndpointServiceBase | [Orion.NetPath.EndpointServicesBase](./../Orion.NetPath/EndpointServicesBase) | Defined by relationship Orion.NetPath.EndpointServicesBaseReferencesEndpointServiceAssignments (System.Reference) |
| EndpointService | [Orion.NetPath.EndpointServices](./../Orion.NetPath/EndpointServices) | Defined by relationship Orion.NetPath.EndpointServicesReferencesEndpointServiceAssignments (System.Reference) |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NetPath.ProbesReferencesEndpointServiceAssignments (System.Reference) |


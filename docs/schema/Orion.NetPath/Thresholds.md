---
id: Thresholds
slug: Thresholds
---

# Orion.NetPath.Thresholds

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains custom status threshold values for a probe and service assignment.

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
| ThresholdTypeID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| ObjectTypeID | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| Critical | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Warning | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| Benign | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| EndpointServiceAssignment | [Orion.NetPath.EndpointServiceAssignments](./../Orion.NetPath/EndpointServiceAssignments) | Defined by relationship Orion.NetPath.EndpointServiceAssignmentsReferencesThresholds (System.Reference) |
| ThresholdType | [Orion.NetPath.ThresholdTypes](./../Orion.NetPath/ThresholdTypes) | Defined by relationship Orion.NetPath.ThresholdTypesReferencesThresholds (System.Reference) |
| ServiceAssignment | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesThresholds (System.Reference) |


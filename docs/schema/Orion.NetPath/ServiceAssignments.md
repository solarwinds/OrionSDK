---
id: ServiceAssignments
slug: ServiceAssignments
---

# Orion.NetPath.ServiceAssignments

SolarWinds Information Service 2020.2 Schema Documentation Index

Designed to use in Alerting. Contains the assignments between NPM NetPath probes and the NPM NetPath services they monitor. A probe can monitor multiple services, and a service can be monitored by multiple probes.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.NetPath.ServiceAssignmentsBase](./../Orion.NetPath/ServiceAssignmentsBase)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Threshold | [Orion.NetPath.Thresholds](./../Orion.NetPath/Thresholds) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesThresholds (System.Reference) |
| Tests | [Orion.NetPath.Tests](./../Orion.NetPath/Tests) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesTests (System.Reference) |
| Traces | [Orion.NetPath.Traces](./../Orion.NetPath/Traces) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesTraces (System.Reference) |
| Performances | [Orion.NetPath.Performances](./../Orion.NetPath/Performances) | Defined by relationship Orion.NetPath.ServiceAssignmentsReferencesPerformances (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NetPath.ProbesReferencesServiceAssignments (System.Reference) |
| EndpointServices | [Orion.NetPath.EndpointServices](./../Orion.NetPath/EndpointServices) | Defined by relationship Orion.NetPath.EndpointServicesReferencesServiceAssignments (System.Reference) |


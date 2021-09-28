---
id: Probes
slug: Probes
---

# Orion.NetPath.Probes

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains NPM NetPath probe information. The probing is done from probes. A user can install multiple probes at various locations to probe the same service.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServiceAssignments | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.ProbesReferencesServiceAssignments (System.Reference) |
| EndpointServiceProperties | [Orion.NetPath.EndpointServiceProperties](./../Orion.NetPath/EndpointServiceProperties) | Defined by relationship Orion.NPM.NetPath.EndpointServicePropertiesReferencesProbes (System.Reference) |
| EndpointServiceAssignments | [Orion.NetPath.EndpointServiceAssignments](./../Orion.NetPath/EndpointServiceAssignments) | Defined by relationship Orion.NetPath.ProbesReferencesEndpointServiceAssignments (System.Reference) |
| EndpointServiceProperties | [Orion.NetPath.EndpointServiceProperties](./../Orion.NetPath/EndpointServiceProperties) | Defined by relationship Orion.NetPath.EndpointServicePropertiesReferencesProbes (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agent | [Orion.AgentManagement.Agent](./../Orion.AgentManagement/Agent) | Defined by relationship Orion.NPM.NetPath.AgentReferencesProbes (System.Reference) |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.NPM.NetPath.EnginesReferencesProbes (System.Reference) |


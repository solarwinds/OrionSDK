---
id: Applications
slug: Applications
---

# Orion.Netflow.Applications

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TCP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UDP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Multiport | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| MapTo | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| PortName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Flows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.ApplicationReferencesFlows (System.Reference) |
| FlowsByIP | [Orion.Netflow.FlowsByIP](./../Orion.Netflow/FlowsByIP) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByIP (System.Reference) |
| FlowsByHostname | [Orion.Netflow.FlowsByHostname](./../Orion.Netflow/FlowsByHostname) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByHostname (System.Reference) |
| FlowsByAS | [Orion.Netflow.FlowsByAS](./../Orion.Netflow/FlowsByAS) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByAS (System.Reference) |
| FlowsByInterface | [Orion.Netflow.FlowsByInterface](./../Orion.Netflow/FlowsByInterface) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByInterface (System.Reference) |
| FlowsByDomain | [Orion.Netflow.FlowsByDomain](./../Orion.Netflow/FlowsByDomain) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByDomain (System.Reference) |
| FlowsByCountryCode | [Orion.Netflow.FlowsByCountryCode](./../Orion.Netflow/FlowsByCountryCode) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByCountryCode (System.Reference) |
| FlowsByConversation | [Orion.Netflow.FlowsByConversation](./../Orion.Netflow/FlowsByConversation) | Defined by relationship Orion.Netflow.ApplicationReferencesFlowsByConversation (System.Reference) |
| Flows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.ApplicationReferencesFlows (System.Reference) |


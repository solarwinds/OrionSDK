---
id: EndpointServiceProperties
slug: EndpointServiceProperties
---

# Orion.NetPath.EndpointServiceProperties

SolarWinds Information Service 2020.2 Schema Documentation Index

Table holds settings for Probe and particular EndpointService if specified. Values are inherited from less specific (ProbeId only) to concrete (ProbeId and EndpointServiceId)

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
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProbeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EndpointServiceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NPM.NetPath.EndpointServicePropertiesReferencesProbes (System.Reference) |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NetPath.EndpointServicePropertiesReferencesProbes (System.Reference) |


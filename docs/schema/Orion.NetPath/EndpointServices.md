---
id: EndpointServices
slug: EndpointServices
---

# Orion.NetPath.EndpointServices

SolarWinds Information Service 2020.2 Schema Documentation Index

Contains configuration information for NPM NetPath services to monitor.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EndpointServiceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CreationTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HostName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Protocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ProbeIntervalInMinutes | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServiceAssignments | [Orion.NetPath.ServiceAssignments](./../Orion.NetPath/ServiceAssignments) | Defined by relationship Orion.NetPath.EndpointServicesReferencesServiceAssignments (System.Reference) |
| EndpointServiceAssignments | [Orion.NetPath.EndpointServiceAssignments](./../Orion.NetPath/EndpointServiceAssignments) | Defined by relationship Orion.NetPath.EndpointServicesReferencesEndpointServiceAssignments (System.Reference) |


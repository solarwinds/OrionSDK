---
id: RequestDetails
slug: RequestDetails
---

# Cortex.Orion.ApiPoller.RequestDetails

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
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Body | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HttpVerb | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialsId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CredentialsType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VerifySslCertificate | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| RequestDetailsOrder | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UseProxy | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedApiPoller | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RequestHeaders | [Cortex.Orion.ApiPoller.RequestHeader](./../Cortex.Orion.ApiPoller/RequestHeader) | Defined by relationship Cortex.Orion.ApiPoller.RequestDetailsToRequestHeaderRelation (System.Hosting) |
| ValueToMonitors | [Cortex.Orion.ApiPoller.ValueToMonitor](./../Cortex.Orion.ApiPoller/ValueToMonitor) | Defined by relationship Cortex.Orion.ApiPoller.RequestDetailsToValueToMonitorRelation (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApiPoller | [Cortex.Orion.ApiPoller.ApiPoller](./../Cortex.Orion.ApiPoller/ApiPoller) | Defined by relationship Cortex.Orion.ApiPoller.ApiPollerToRequestDetailsRelation (System.Hosting) |


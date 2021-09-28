---
id: RequestHeader
slug: RequestHeader
---

# Cortex.Orion.ApiPoller.RequestHeader

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
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Value | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| RelatedRequestDetails | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RequestDetails | [Cortex.Orion.ApiPoller.RequestDetails](./../Cortex.Orion.ApiPoller/RequestDetails) | Defined by relationship Cortex.Orion.ApiPoller.RequestDetailsToRequestHeaderRelation (System.Hosting) |


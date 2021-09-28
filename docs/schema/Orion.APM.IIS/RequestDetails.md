---
id: RequestDetails
slug: RequestDetails
---

# Orion.APM.IIS.RequestDetails

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents details of the request.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of request details. | everyone |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of request target site. | everyone |
| RequestID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of target request. | everyone |
| Verb | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The requested action, for example, a GET method. | everyone |
| ClientIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The IP address of the client that made the request. | everyone |
| ElapsedTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The time that request took. | everyone |
| URLQuery | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The parameters of the request url. | everyone |
| RequestDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date on which the request occurred. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of request, based on ElapsedTime and some predefined thresholds. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to site details page. Used in alerting. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Display name for request details. Used in alerting. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Request | [Orion.APM.IIS.Request](./../Orion.APM.IIS/Request) | Defined by relationship Orion.APM.IIS.RequestHostsRequestDetails (System.Hosting) |


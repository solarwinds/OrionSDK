---
id: Request
slug: Request
---

# Orion.APM.IIS.Request

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents request to Site.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The unique integer representation of request. | everyone |
| SiteID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of request target site. | everyone |
| URLStem | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The target of the request. | everyone |
| AverageElapsedTime | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | The average time of all requests to site. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The status of request, based on AverageElapsedTime and some predefined thresholds. | everyone |
| RecentRequestDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The most recent date on which the request occurred. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | URL to site details page. Used in alerting. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Display name for request. Used in alerting. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| RequestDetails | [Orion.APM.IIS.RequestDetails](./../Orion.APM.IIS/RequestDetails) | Defined by relationship Orion.APM.IIS.RequestHostsRequestDetails (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.SiteHostsRequest (System.Hosting) |


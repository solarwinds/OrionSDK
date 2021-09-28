---
id: Application
slug: Application
---

# Orion.APM.IIS.Application

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents SAM application.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.APM.Application](./../Orion.APM/Application)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AdditionalJobStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Status of the additional job. | everyone |
| AdditionalJobTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp of the additional job. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Site | [Orion.APM.IIS.Site](./../Orion.APM.IIS/Site) | Defined by relationship Orion.APM.IIS.ApplicationHostsSite (System.Hosting) |
| ApplicationPool | [Orion.APM.IIS.ApplicationPool](./../Orion.APM.IIS/ApplicationPool) | Defined by relationship Orion.APM.IIS.ApplicationHostsApplicationPool (System.Hosting) |
| Organization | [Orion.SamAppOptics.Service.Organization](./../Orion.SamAppOptics.Service/Organization) | Defined by relationship AppOptics.ApplicationToOrganization (System.Reference) |
| TopRequestsPerSecond | [Orion.SamAppOptics.Service.TopRequestsPerSecond](./../Orion.SamAppOptics.Service/TopRequestsPerSecond) | Defined by relationship AppOptics.ApplicationToTopRequestsPerSecond (System.Reference) |
| TopAverageResponseTime | [Orion.SamAppOptics.Service.TopAverageResponseTime](./../Orion.SamAppOptics.Service/TopAverageResponseTime) | Defined by relationship AppOptics.ApplicationToTopAverageResponseTime (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Integration | [Orion.SamAppOptics.Integration](./../Orion.SamAppOptics/Integration) | Defined by relationship Orion.SamAppOptics.ApplicationIntegration (System.Reference) |


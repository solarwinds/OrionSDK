---
id: Organization
slug: Organization
---

# Orion.SamAppOptics.Service.Organization

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| OrganizationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsComplience | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| SubscriptionState | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TrialEndDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IntegrationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Service | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeepLink | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Application | [Orion.APM.IIS.Application](./../Orion.APM.IIS/Application) | Defined by relationship AppOptics.ApplicationToOrganization (System.Reference) |
| Integration | [Orion.SamAppOptics.Integration](./../Orion.SamAppOptics/Integration) | Defined by relationship AppOptics.IntegrationToOrganization (System.Reference) |


---
id: Integration
slug: Integration
---

# Orion.SamAppOptics.Integration

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Id | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| IntegrationType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ApplicationID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ExternalUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ServiceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DeploymentState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| FailureReason | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Organization | [Orion.SamAppOptics.Service.Organization](./../Orion.SamAppOptics.Service/Organization) | Defined by relationship AppOptics.IntegrationToOrganization (System.Reference) |
| Application | [Orion.APM.IIS.Application](./../Orion.APM.IIS/Application) | Defined by relationship Orion.SamAppOptics.ApplicationIntegration (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.SamAppOptics.NodeIntegration (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ApplicationPool | [Orion.SamAppOptics.ApplicationPool](./../Orion.SamAppOptics/ApplicationPool) | Defined by relationship Orion.SamAppOptics.ApplicationPoolIntegration (System.Reference) |


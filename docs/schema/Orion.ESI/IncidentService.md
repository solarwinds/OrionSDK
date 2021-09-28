---
id: IncidentService
slug: IncidentService
---

# Orion.ESI.IncidentService

SolarWinds Information Service 2020.2 Schema Documentation Index

Holds the information about integrated incident management services.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| InstanceID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperationalState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CustomData | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Credentials | [Orion.Credential](./../Orion/Credential) | Defined by relationship IncidentServiceToOrionCredential (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| AlertIncident | [Orion.ESI.AlertIncident](./../Orion.ESI/AlertIncident) | Defined by relationship AlertIncidentToIncidentIntegration (System.Reference) |


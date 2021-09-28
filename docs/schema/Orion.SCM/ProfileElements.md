---
id: ProfileElements
slug: ProfileElements
---

# Orion.SCM.ProfileElements

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents monitored element for SCM profile, which could be set and maintained by a user.
      Monitored element can represent file or registry key which is monitored by superior profile.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ElementID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of this entity. | everyone |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of Profile to which this entity belongs to. | everyone |
| Type | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Type of the element. Options are: 0 (Unknown), 1 (File), 2 (Registry), 4 (ParsedFile), 5 (SwisQuery), 6 (PowerShell), 8 (Script). | everyone |
| DisplayAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Alias assigned to this entity. If provided, it replaces automatically generated name. | everyone |
| Settings | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | All related settings specific for given type (Json). | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Text which helps understand this entity. | everyone |
| CredentialID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Contains credentialID for mapping with credential from Credential store. | everyone |
| PolicyDataSourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PolledElements | [Orion.SCM.Results.PolledElements](./../Orion.SCM.Results/PolledElements) | Defined by relationship Orion.SCM.ProfilesElementsReferencesPolledElements (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Profile | [Orion.SCM.Profiles](./../Orion.SCM/Profiles) | Defined by relationship Orion.SCM.ProfilesReferencesProfileElements (System.Reference) |


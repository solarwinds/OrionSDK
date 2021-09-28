---
id: Profiles
slug: Profiles
---

# Orion.SCM.Profiles

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents profiles, which could be set and maintained by a user.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,delete,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of the profile. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the profile. | everyone |
| BuiltIn | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether profile is built-in. This property is readonly and set to true only for profiles deployed with SCM installation. These can't be modified. | everyone |
| UniqueId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | GUID of the profile, valuable for import/export to identify identical profiles across different environments. | everyone |
| TemplateMappingRules | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Internal configuration storing how to discover profile and rules whether profile is candidate for monitoring (Json). | everyone |
| ProfileOrigin | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numeric value indicating where the profile comes from. Options are: 0 (New), 1 (Copied), 2 (Imported), 3 (ImportedFromThwack). | everyone |
| OriginalProfileUniqueID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Origin GUID of parent profile (when copied). | everyone |
| Modified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of last profile modification. | everyone |
| PolicyID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodesProfiles | [Orion.SCM.NodesProfiles](./../Orion.SCM/NodesProfiles) | Defined by relationship ProfileReferencesOrion.SCM.NodesProfiles (System.Reference) |
| SCMNodes | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.NodeReferencesOrion.SCM.Profiles (System.Reference) |
| Elements | [Orion.SCM.ProfileElements](./../Orion.SCM/ProfileElements) | Defined by relationship Orion.SCM.ProfilesReferencesProfileElements (System.Reference) |

## Verbs

### AssignToNode

Assigns profile to node.

#### Access control

everyone

### UnassignFromNode

Unassigns profile from node.

#### Access control

everyone

### ExportProfile

Exports profile to JSON

#### Access control

everyone

### ImportProfile

Imports profile from JSON

#### Access control

everyone


---
id: PolledElements
slug: PolledElements
---

# Orion.SCM.Results.PolledElements

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents Discovered Elements matching Profile Element settings.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolledElementID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique identifier of the entity. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where element was discovered. | everyone |
| ElementID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique identifier of ProfileElement entity. | everyone |
| DisplayAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Custom alias for this entity. If provided, it replaces automatically generated name. | everyone |
| Settings | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | All related settings specific for given type (Json). | everyone |
| BaselineStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numeric value indicating baseline status. Options are: 0 (No baseline set), 1 (Is baseline), 2 (Matches baseline), 3 (Differs from baseline) | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Details | [Orion.SCM.Results.PolledElementDetails](./../Orion.SCM.Results/PolledElementDetails) | Defined by relationship Orion.SCM.PoledElementHostingDetails (System.Hosting) |
| ElementMetadata | [Orion.SCM.Results.ElementMetadata](./../Orion.SCM.Results/ElementMetadata) | Defined by relationship Orion.SCMPolledElementsReferencesElementMetadata (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ProfileElement | [Orion.SCM.ProfileElements](./../Orion.SCM/ProfileElements) | Defined by relationship Orion.SCM.ProfilesElementsReferencesPolledElements (System.Reference) |


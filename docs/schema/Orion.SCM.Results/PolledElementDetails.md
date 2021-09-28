---
id: PolledElementDetails
slug: PolledElementDetails
---

# Orion.SCM.Results.PolledElementDetails

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents some extending details for PolledElements.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| PolledElementID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Unique identifier of parent PolledElements entity. | everyone |
| DisplayAlias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Custom alias for this entity, replaces automatically generated name, if provided. | everyone |
| DisplayAliasFirstPart | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | First part of the alias (typically contains file name or registry key). | everyone |
| DisplayAliasSecondPart | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Second part of the alias (typically contains path to file or registry key). | everyone |
| Path | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Extracted Path from PolledElements settings. | everyone |
| IsTypePathBased | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether there is Path. | everyone |
| UseProfileDisplayAlias | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether there is custom alias. | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Display name for PolledElements entity | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PolledElement | [Orion.SCM.Results.PolledElements](./../Orion.SCM.Results/PolledElements) | Defined by relationship Orion.SCM.PoledElementHostingDetails (System.Hosting) |


---
id: Constraints
slug: Constraints
---

# Orion.Recommendations.Constraints

SolarWinds Information Service 2020.2 Schema Documentation Index

Entity which provides access to configured constraints.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ConstraintID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Constraint ID | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description | everyone |
| Type | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Type | everyone |
| DateCreated | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Creation date | everyone |
| ExpirationDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Expiration date | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Constraint Enabled | everyone |
| UserID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User which crated the constraint | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Module owning the constraint | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ConstraintObjects | [Orion.Recommendations.ConstraintObjects](./../Orion.Recommendations/ConstraintObjects) | Defined by relationship Orion.Recommendations.ConstraintHostsConstrainObjects (System.Hosting) |
| ConstraintParameters | [Orion.Recommendations.ConstraintParameters](./../Orion.Recommendations/ConstraintParameters) | Defined by relationship Orion.Recommendations.ConstraintHostsConstrainParameters (System.Hosting) |


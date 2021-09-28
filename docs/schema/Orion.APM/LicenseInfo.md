---
id: LicenseInfo
slug: LicenseInfo
---

# Orion.APM.LicenseInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents License Information.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CountedFeatureElementFactor | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Factor for license saturation strategy.1 if is node base license else 0. | everyone |

## Verbs

### GetLicenseLimit

Returns license limit of polled elements.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |

### GetLicensedEntitiesCount

Returns number of licensed entities of specific type on particular engine.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |

### GetLicensedEntityCountFromAllEngines

Returns number of licensed entity on all engines.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |

### RefreshLicenseCache

Trigger refresh license cache.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |


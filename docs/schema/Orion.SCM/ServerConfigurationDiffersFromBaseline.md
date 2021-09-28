---
id: ServerConfigurationDiffersFromBaseline
slug: ServerConfigurationDiffersFromBaseline
---

# Orion.SCM.ServerConfigurationDiffersFromBaseline

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents indication server configuration differs from baseline.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Indication](./../System/Indication)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node which differs from baseline. | everyone |
| BaselineVsCurrentConfigurationUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Url to related compare page. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of the change. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServerConfiguration | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.ServerConfigurationDiffersFromBaselineRel (System.Reference) |


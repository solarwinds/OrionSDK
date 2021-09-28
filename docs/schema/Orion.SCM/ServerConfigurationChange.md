---
id: ServerConfigurationChange
slug: ServerConfigurationChange
---

# Orion.SCM.ServerConfigurationChange

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents indication containing info about configuration change on server.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Indication](./../System/Indication)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node related to the change. | everyone |
| ProfileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of Profile entity. | everyone |
| ElementPath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Path of the ProfileElement entity settings if there is Path. | everyone |
| PolledElementPath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Path of the PolledElement entity settings if there is Path. | everyone |
| ChangeType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Type of the change. Options are: 0 (Unknown), 1 (Add), 2 (Update), 3 (Remove). | everyone |
| ChangeDetectedOn | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime when the change was detected, not when it happened on the monitored system. | everyone |
| CompareUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Url to related compare page. | everyone |
| WhoMadeTheChange | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of the change. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ServerConfiguration | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.ServerConfigurationChangeRel (System.Reference) |


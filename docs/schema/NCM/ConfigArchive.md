---
id: ConfigArchive
slug: ConfigArchive
---

# NCM.ConfigArchive

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [Orion.LogEntity](./../Orion/LogEntity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ConfigID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ConfigTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DownloadTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AttemptedDownloadTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ModifiedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ConfigType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Baseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsIndexed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Config | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsBinary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Hash | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AdditionalCommands | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefConfigArchive (System.Reference) |


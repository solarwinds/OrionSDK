---
id: Tools
slug: Tools
---

# Orion.Toolset.Tools

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ToolId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ResultTypeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ResourceUrlPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ResultType | [Orion.Toolset.ResultTypes](./../Orion.Toolset/ResultTypes) | Defined by relationship Orion.Toolset.ToolReferencesResultType (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ToolSettings | [Orion.Toolset.ToolSettings](./../Orion.Toolset/ToolSettings) | Defined by relationship Orion.Toolset.ToolSettingReferencesTool (System.Reference) |
| ToolLaunches | [Orion.Toolset.ToolLaunchDetail](./../Orion.Toolset/ToolLaunchDetail) | Defined by relationship Orion.Toolset.ToolLaunchDetailReferencesTool (System.Reference) |


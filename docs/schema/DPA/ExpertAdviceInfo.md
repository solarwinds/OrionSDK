---
id: ExpertAdviceInfo
slug: ExpertAdviceInfo
---

# DPA.ExpertAdviceInfo

SolarWinds Information Service 2020.2 Schema Documentation Index

The entity represents advises given on the "Waits" tab in the UI

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| WaitId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the wait type as is displayed in the UI (eg. 'CPU/Memory') | everyone |
| AdviceInfo | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | HTML-formatted text describing the wait time, causes, possible fixes etc. | everyone |


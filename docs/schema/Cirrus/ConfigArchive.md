---
id: ConfigArchive
slug: ConfigArchive
---

# Cirrus.ConfigArchive

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ConfigID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| BaseConfigID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| ConfigTitle | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DownloadTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| AttemptedDownloadTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ModifiedTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ConfigType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Config | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Comments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Baseline | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsIndexed | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IsBinary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Hash | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| TransferResults | [NCM.TransferResults](./../NCM/TransferResults) | Defined by relationship NCM.ConfigArchiveRefTransferResults (System.Reference) |

## Verbs

### Diff

#### Access control

everyone

### CompareConfigs

#### Access control

everyone

### Download

#### Access control

everyone

### GetStatus

#### Access control

everyone

### GetStatusWithLimitations

#### Access control

everyone

### Upload

#### Access control

everyone

### Execute

#### Access control

everyone

### CancelTransfer

#### Access control

everyone

### CancelTransferWithLimitations

#### Access control

everyone

### ClearComplete

#### Access control

everyone

### ClearCompleteWithLimitations

#### Access control

everyone

### ClearErrors

#### Access control

everyone

### ClearErrorsWithLimitations

#### Access control

everyone

### ClearAll

#### Access control

everyone

### ClearAllWithLimitations

#### Access control

everyone

### GetPermissionsByRole

#### Access control

everyone

### DeleteConfigs

#### Access control

everyone

### GetConfigTypes

#### Access control

everyone

### ReportError

#### Access control

everyone

### CancelTransfers

#### Access control

everyone

### ClearTransfers

#### Access control

everyone

### ExecuteScript

#### Access control

everyone

### ExecuteScriptPerNode

#### Access control

everyone

### ReExecute

#### Access control

everyone

### UploadConfig

#### Access control

everyone

### UploadConfigPerNode

#### Access control

everyone

### SaveConfigData

#### Access control

everyone

### DownloadConfig

#### Access control

everyone

### ExecuteScriptOnNodes

#### Access control

everyone

### DownloadConfigOnNodes

#### Access control

everyone

### ConfigSearch

#### Access control

everyone

### RunIndexOptimization

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |

### UpdateConfig

#### Access control

everyone

### CloneConfig

#### Access control

everyone

### ImportConfig

#### Access control

everyone

### SetClearBaseline

#### Access control

everyone

### ValidateBinaryConfigStorage

#### Access control

everyone

### GetInterfaceConfigSnippets

#### Access control

everyone


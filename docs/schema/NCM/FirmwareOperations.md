---
id: FirmwareOperations
slug: FirmwareOperations
---

# NCM.FirmwareOperations

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CreationDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| RunAt | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ErrorMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Log | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EmailSettings | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DefinitionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### PrepareFirmwareUpgrade

#### Access control

everyone

### PrepareRollBack

#### Access control

everyone

### PrepareReExecuteFailed

#### Access control

everyone

### StartUpgrade

#### Access control

everyone

### CancelUpgrade

#### Access control

everyone

### GenerateScriptPreview

#### Access control

everyone

### DeleteFirmwareOperations

#### Access control

everyone


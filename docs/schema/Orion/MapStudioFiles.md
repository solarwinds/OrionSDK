---
id: MapStudioFiles
slug: MapStudioFiles
---

# Orion.MapStudioFiles

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | manageMaps |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| FileId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| FileName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FileData | [System.Binary](./../System/Binary) |  | everyone |
| Timestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UpdateUser | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsDeleted | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LockUser | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FileType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LockDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ComputerName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| WirelessHeatMap | [Orion.Map](./../Orion/Map) | Defined by relationship Orion.MapToMapStudioFiles (System.Reference) |

## Verbs

### InsertFile

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### UpdateFile

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### LockFile

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### LockFileTable

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### UnlockAllFiles

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### DeleteFile

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageMaps |

### GetMapStyle

Get map style of the map

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | everyone |


---
id: CiscoChassis
slug: CiscoChassis
---

# NCM.CiscoChassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChassisType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChassisName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ChassisVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ChassisID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ChassisSerialNumberString | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RomVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RomSysVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ProcessorRAM | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NvRAMSize | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NvRAMUsed | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChassisSlots | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RomID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| WhyReload | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FreeMem | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefCiscoChassis (System.Reference) |
| Node | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodeHostsCiscoChassis (System.Hosting) |


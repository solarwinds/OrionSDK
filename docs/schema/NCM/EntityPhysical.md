---
id: EntityPhysical
slug: EntityPhysical
---

# NCM.EntityPhysical

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ContainedIn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EntityClass | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Position | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| HardwareRevision | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FirmwareRevision | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SoftwareRevision | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Serial | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Manufacturer | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Alias | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AssetID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FieldReplaceable | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| EntPhysicalIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CiscoFruPowerStatus | [NCM.CiscoFruPowerStatus](./../NCM/CiscoFruPowerStatus) | Defined by relationship NCM.EntityPhysicalRefCiscoFruPowerStatus (System.Reference) |
| CiscoFruFanTrayStatus | [NCM.CiscoFruFanTrayStatus](./../NCM/CiscoFruFanTrayStatus) | Defined by relationship NCM.EntityPhysicalRefCiscoFruFanTrayStatus (System.Reference) |
| CiscoFruPowerSupplyGroups | [NCM.CiscoFruPowerSupplyGroups](./../NCM/CiscoFruPowerSupplyGroups) | Defined by relationship NCM.EntityPhysicalRefCiscoFruPowerSupplyGroups (System.Reference) |
| CiscoBootloadImages | [NCM.CiscoBootloadImages](./../NCM/CiscoBootloadImages) | Defined by relationship NCM.EntityPhysicalHostsCiscoBootloadImages (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefEntityPhysical (System.Reference) |
| Node | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodeHostsEntityPhysical (System.Hosting) |


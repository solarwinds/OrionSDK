---
id: CiscoFruPowerSupplyGroups
slug: CiscoFruPowerSupplyGroups
---

# NCM.CiscoFruPowerSupplyGroups

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntityID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| FRUIndex | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| AdminPowerRedundancyMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PowerUnits | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TotalAvailableCurrent | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| TotalDrawnCurrent | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| OperPowerRedundancyMode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| FirstDiscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Missing | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [NCM.Nodes](./../NCM/Nodes) | Defined by relationship NCM.NodesHostsCiscoFruPowerSupplyGroups (System.Hosting) |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefCiscoFruPowerSupplyGroups (System.Reference) |
| EntityPhysical | [NCM.EntityPhysical](./../NCM/EntityPhysical) | Defined by relationship NCM.EntityPhysicalRefCiscoFruPowerSupplyGroups (System.Reference) |


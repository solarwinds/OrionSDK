---
id: Fabrics
slug: Fabrics
---

# Orion.UCS.Fabrics

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) |  | everyone |
| HostNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DistinguishedName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Model | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeIDHostNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| FabricNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| PSUs | [Orion.UCS.PSUsOnFabrics](./../Orion.UCS/PSUsOnFabrics) | Defined by relationship Orion.UCS.FabricsHostsPSUs (System.Hosting) |
| Fans | [Orion.UCS.FansOnFabrics](./../Orion.UCS/FansOnFabrics) | Defined by relationship Orion.UCS.FabricsHostsFans (System.Hosting) |
| UCSChassis | [Orion.UCS.Chassis](./../Orion.UCS/Chassis) | Defined by relationship Orion.UCS.FabricHostsUCSChassis (System.Reliance) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.UCS.FabricReferencesNode (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| HwHBMCController | [Orion.HardwareHealth.BMC.Controllers](./../Orion.HardwareHealth.BMC/Controllers) | Defined by relationship Orion.BMC.ControllerHostsUCSFabrics (System.Hosting) |


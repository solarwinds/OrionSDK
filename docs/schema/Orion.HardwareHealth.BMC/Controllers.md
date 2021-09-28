---
id: Controllers
slug: Controllers
---

# Orion.HardwareHealth.BMC.Controllers

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemUpTime | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Mode | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UseSSL | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CredentialID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.OrionHwhBMCControllersReferencesNodes (System.Reference) |
| UCSEvents | [Orion.UCS.Events](./../Orion.UCS/Events) | Defined by relationship Orion.UCS.ControllerHostsUCSEvents (System.Reference) |
| UCSFabrics | [Orion.UCS.Fabrics](./../Orion.UCS/Fabrics) | Defined by relationship Orion.BMC.ControllerHostsUCSFabrics (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Racks | [Orion.HardwareHealth.BMC.Racks](./../Orion.HardwareHealth.BMC/Racks) | Defined by relationship Orion.HardwareHealth.BMC.RacksReferencesController (System.Reference) |
| Chassis | [Orion.HardwareHealth.BMC.Chassis](./../Orion.HardwareHealth.BMC/Chassis) | Defined by relationship Orion.HardwareHealth.BMC.ChassisReferencesController (System.Reference) |


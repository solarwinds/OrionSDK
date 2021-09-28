---
id: Chassis
slug: Chassis
---

# Orion.UCS.Chassis

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.HardwareHealth.BMC.Chassis](./../Orion.HardwareHealth.BMC/Chassis)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ControllerNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.UCS.ChassisRelianceControllerNode (System.Reliance) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| UCSFabric | [Orion.UCS.Fabrics](./../Orion.UCS/Fabrics) | Defined by relationship Orion.UCS.FabricHostsUCSChassis (System.Reliance) |
| BladeNodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.UCS.BladeNodesRelianceChassis (System.Reliance) |


---
id: FimDisabledNodes
slug: FimDisabledNodes
---

# Orion.SCM.FimDisabledNodes

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains explicit list of nodes where FIM is forcibly disabled.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,delete | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where FIM is forcibly disabled. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesReferenceFimDisabledNodes (System.Reference) |


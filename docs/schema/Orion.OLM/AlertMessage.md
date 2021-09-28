---
id: AlertMessage
slug: AlertMessage
---

# Orion.OLM.AlertMessage

SolarWinds Information Service 2020.2 Schema Documentation Index

Indication sent to Orion alerting when a message meets rule conditions.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Indication](./../System/Indication)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of mapped node. | everyone |
| RuleDefinitionID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Identifier of the rule. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Not used. | everyone |
| HitCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Number of messages from the node, which met the rule. | everyone |
| EventMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Message, which triggered the rule. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Nodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.OLMAlertMessageNode (System.Reference) |


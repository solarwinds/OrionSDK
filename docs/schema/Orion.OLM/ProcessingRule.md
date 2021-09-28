---
id: ProcessingRule
slug: ProcessingRule
---

# Orion.OLM.ProcessingRule

SolarWinds Information Service 2020.2 Schema Documentation Index

Rules used for processing log entries.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RuleDefinitionId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Identifier of the rule. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the rule. | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether rule is enabled or not. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Actions | [Orion.OLM.ProcessingRuleActions](./../Orion.OLM/ProcessingRuleActions) | Defined by relationship Orion.OLMProcessingRuleActions (System.Reference) |


---
id: ProcessingRuleActions
slug: ProcessingRuleActions
---

# Orion.OLM.ProcessingRuleActions

SolarWinds Information Service 2020.2 Schema Documentation Index

Actions triggered when rule conditions are met.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| RuleActionId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Identifier of action defined for the rule. | everyone |
| RuleDefinitionId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | Identifier of processing rule. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the action. | everyone |
| ActionType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numeric value identifying the action type (tag assignment, alerting action, ...) | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Rule | [Orion.OLM.ProcessingRule](./../Orion.OLM/ProcessingRule) | Defined by relationship Orion.OLMProcessingRuleActions (System.Reference) |


---
id: LogProfile
slug: LogProfile
---

# Orion.OLM.LogProfile

SolarWinds Information Service 2020.2 Schema Documentation Index

Profiles used for configuring log file collection.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| LogProfileID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of log profile. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of log profile. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Description of log profile. | everyone |
| Filepath | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Filepath or mask to specify monitored files. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agents | [Orion.AgentManagement.Agent](./../Orion.AgentManagement/Agent) | Defined by relationship Orion.OLMLogProfileAgents (System.Reference) |


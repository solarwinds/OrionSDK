---
id: AgentPlugin
slug: AgentPlugin
---

# Orion.AgentManagement.AgentPlugin

SolarWinds Information Service 2020.2 Schema Documentation Index

A representation of the plugin on a particular agent.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete | admin |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The ID of agent that this plugin is installed on | everyone |
| PluginId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string which indicates the type of this plugin | everyone |
| Version | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string which is the version of this plugin | everyone |
| LastChange | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp when plugin state changed last time | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An integer value indicating the status of the plugin | everyone |
| StatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A human readable string description of the current status of the plugin. | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Agent | [Orion.AgentManagement.Agent](./../Orion.AgentManagement/Agent) | Defined by relationship Orion.AgentManagement.AgentHostsPlugin (System.Hosting) |


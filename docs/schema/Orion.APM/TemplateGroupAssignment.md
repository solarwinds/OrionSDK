---
id: TemplateGroupAssignment
slug: TemplateGroupAssignment
---

# Orion.APM.TemplateGroupAssignment

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents connection between Orion group and application templates.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| GroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of group. | everyone |
| TemplateID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of application template. | everyone |
| AgentWmiCredentialsID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of agent or wmi credentials. | everyone |
| SnmpIcmpCredentialsID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of snmp or icmp credentials. | everyone |
| AutoAssign | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag that indicates if application template should be automatically assigned. | everyone |
| AutoDelete | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag that indicates if application template should be automatically deleted. | everyone |
| ServersOnly | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Flag that indicates if assigned nodes should be server nodes. | everyone |
| CreationTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Time stamp when assignment was created. | everyone |


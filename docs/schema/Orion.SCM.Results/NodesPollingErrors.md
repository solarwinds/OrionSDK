---
id: NodesPollingErrors
slug: NodesPollingErrors
---

# Orion.SCM.Results.NodesPollingErrors

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents polling errors for SCM node / server configuration. Contains only current errors, does not keep records of previous ones.

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
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where error was collected. | everyone |
| Type | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Type of the error. Options are: 0 (Agent not required), 1 (Agent Ok), 2 (Agent missing), 3 (Agent issue), 4 (Scm plugin issue), 5 (Scm plugin not responding), 6 (Scm plugin not applicable), 7 (Asset inventory missing). | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Error message. | everyone |


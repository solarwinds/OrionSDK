---
id: ServiceStateChanged
slug: ServiceStateChanged
---

# Orion.APM.ServiceStateChanged

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity presents the indication information for windows service state.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.Indication](./../System/Indication)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| ServiceName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Windows service name. | everyone |
| Action | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Performed action (stop/start/restart). | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| NodeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains name of the parent node. | everyone |


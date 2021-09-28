---
id: EventTypes
slug: EventTypes
---

# Orion.EventTypes

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EventType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Bold | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| BackColor | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Icon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Sort | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| Notify | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Record | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Sound | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Mute | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| NotifyMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NotifySubject | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionFeatureName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionFeature | [Orion.Features](./../Orion/Features) | Defined by relationship Orion.EventTypesOrionFeatures (System.Reference) |
| Events | [Orion.Events](./../Orion/Events) | Defined by relationship Orion.EventTypeHostsEvents (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionEventTypes | [IPAM.Event](./../IPAM/Event) | Defined by relationship IPAM.EventToOrionEventsRef (System.Reference) |


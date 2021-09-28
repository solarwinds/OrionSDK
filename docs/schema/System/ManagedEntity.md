---
id: ManagedEntity
slug: ManagedEntity
---

# System.ManagedEntity

SolarWinds Information Service 2020.2 Schema Documentation Index

A ManagedEntity is basically "something that has an externally-determined up/down status". These entities represent the things that our monitoring products monitor: servers, network interfaces, applications, etc.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An int value denoting the up/down/warning/etc. status of this entity. The interpretation of this int will be application-dependent, but for Orion.* entities, you can query Orion.StatusInfo to see what the different numbers mean. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Textual information about the status of this entity. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A legacy property. Ignore this. | everyone |
| UnManaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | True, Whether the entity is current unmanaged, otherwise false. | everyone |
| UnManageFrom | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime when this entity became/will become unmanaged | everyone |
| UnManageUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The datetime when this entity will exit the unmanaged state | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A relative url for the "details page" for this entity. This is typically constructed using a string concatenation expression in a defining query storage entity. See OrionSchema.xml for some examples of this technique. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A legacy property. Ignore this. | everyone |
| AncestorDisplayNames | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Returns an array containing the DisplayName properties of this entity, the entity that hosts this entity, and so on, recursively. Generated automatically by SWIS - don't map this property to storage. | everyone |
| AncestorDetailsUrls | [System.String[]](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Returns an array containing the DetailsUrl properties of this entity, the entity that hosts this entity, and so on, recursively. Generated automatically by SWIS - don't map this property to storage. | everyone |
| StatusIconHint | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |


---
id: NotificationItemGrouped
slug: NotificationItemGrouped
---

# Orion.NotificationItemGrouped

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity contains grouped notification item data.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| TypeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| NotificationID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| Timestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| ImageLink | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayAs | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CustomDismissButtonText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| HideDismissButton | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AcknowledgeByItemId | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| DetailsPageLink | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsPageLinkCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Message | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Verbs

### AcknowledgeAll

Sets notification item acknowledgement timestamp and user for all items.

#### Access control

everyone

### AcknowledgeById

Sets notification item acknowledgement timestamp and user for specific item.

#### Access control

everyone

### UnAcknowledgeById

Resets notification item acknowledgement for specific item.

#### Access control

everyone

### AcknowledgeByType

Sets notification item acknowledgement timestamp and user for items of a specific type.

#### Access control

everyone

### UnAcknowledgeByType

Resets notification item acknowledgement for items of a specific type.

#### Access control

everyone


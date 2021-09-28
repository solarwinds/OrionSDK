---
id: CustomPollerAssignmentOnInterface
slug: CustomPollerAssignmentOnInterface
---

# Orion.NPM.CustomPollerAssignmentOnInterface

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

↳ [Orion.NPM.CustomPollerAssignment](./../Orion.NPM/CustomPollerAssignment)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| CustomPollerAssignmentID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| InterfaceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| CustomPollerStatus | [Orion.NPM.CustomPollerStatusOnInterface](./../Orion.NPM/CustomPollerStatusOnInterface) | Defined by relationship Orion.CustomPollerAssignmentOnInterfaceHostsCustomPollerStatusOnInterface (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interface | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.NPM.InterfacesHostsCustomPollerAssignmentOnInterface (System.Hosting) |
| CustomPoller | [Orion.NPM.InterfaceCustomPollers](./../Orion.NPM/InterfaceCustomPollers) | Defined by relationship Orion.InterfaceCustomPollersReferencesCustomPollerAssignmentOnInterface (System.Reference) |


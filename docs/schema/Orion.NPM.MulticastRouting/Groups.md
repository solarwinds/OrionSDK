---
id: Groups
slug: Groups
---

# Orion.NPM.MulticastRouting.Groups

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MulticastGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| GroupIPGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| IPVersion | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| GroupIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| GroupNodes | [Orion.NPM.MulticastRouting.GroupNodes](./../Orion.NPM.MulticastRouting/GroupNodes) | Defined by relationship Orion.NPM.MulticastRouting.GroupReferencesGroupNodes (System.Reference) |
| GroupTranslation | [Orion.NPM.MulticastRouting.GroupTranslation](./../Orion.NPM.MulticastRouting/GroupTranslation) | Defined by relationship Orion.NPM.MulticastRouting.GroupsHostsGroupTranslation (System.Hosting) |
| WebUri | [Orion.NPM.MulticastRouting.GroupWebUri](./../Orion.NPM.MulticastRouting/GroupWebUri) | Defined by relationship Orion.NPM.MulticastRouting.GroupHostsWebUri (System.Hosting) |


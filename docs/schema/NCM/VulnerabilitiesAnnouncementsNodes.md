---
id: VulnerabilitiesAnnouncementsNodes
slug: VulnerabilitiesAnnouncementsNodes
---

# NCM.VulnerabilitiesAnnouncementsNodes

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| EntryId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CoreNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| State | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StateChange | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| Comment | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| VulnerabilitiesAnnouncements | [NCM.VulnerabilitiesAnnouncements](./../NCM/VulnerabilitiesAnnouncements) | Defined by relationship NCM.VulnerabilitiesAnnouncementsNodesRefVulnerabilitiesAnnouncements (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship NCM.NodePropertiesRefVulnerabilitiesAnnouncementsNodes (System.Reference) |


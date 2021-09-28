---
id: IPGroupsBySegments
slug: IPGroupsBySegments
---

# Orion.Netflow.IPGroupsBySegments

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

everyone

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IPGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| SourceIPSegmentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| DestinationIPSegmentID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| IPGroup | [Orion.Netflow.IPAddressGroups](./../Orion.Netflow/IPAddressGroups) | Defined by relationship Orion.Netflow.IpGroupsBySegmentsReferencesIPAddressGroups (System.Reference) |
| IPGroup | [Orion.Netflow.IPAddressGroups](./../Orion.Netflow/IPAddressGroups) | Defined by relationship Orion.Netflow.IpGroupsBySegmentsReferencesIPAddressGroups (System.Reference) |


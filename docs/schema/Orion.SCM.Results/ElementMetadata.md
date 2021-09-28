---
id: ElementMetadata
slug: ElementMetadata
---

# Orion.SCM.Results.ElementMetadata

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents metadata retrieved from remote server, marked with version and timestamp.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of the node where metadata were collected. | everyone |
| PolledElementID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Identifier of PolledElement entity. | everyone |
| VersionID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Current change version starting from 1. | everyone |
| TimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime when the change was spotted. Can change with maintenance. Can round datetime of last successful poll to lower value of hour or day. | everyone |
| LastModified | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime when the entity was changed (for File type it is typically LastWriteTime of the file). | everyone |
| LastModifiedBy | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of the user who did the change. | everyone |
| LastModifiedByState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastModifiedByStateDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ElementContentID | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Identifier of related content change. Defined only when ProfileElement is configured to be downloaded to Orion and was successfully downloaded during poll. | everyone |
| ChangeType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Type of the change. Options are: 0 (Unknown), 1 (Add), 2 (Update), 3 (Remove). | everyone |
| IsInitialPoll | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether it is first initial poll. | everyone |
| ContentCollectionState | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Description whether content was collected. Options are: 0 (Content not present), 1 (Content present), 2 (Content collection disabled), 3 (Size limit exceeded). | everyone |
| OriginalTimeStamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime when the change was spotted. Holds original value of TimeStamp and does not changes. | everyone |
| ChangesCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Count of aggregated changes. Initial poll is not counted as a change. | everyone |
| FileSize | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Size of file. | everyone |
| FileAttributes | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | File attributes (flags). | everyone |
| Owner | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Owner of the file. | everyone |
| UserGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | User group which owns the file. | everyone |
| UnixFileMode | [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/system.int64) | Contains special mode bits of file mode like setuid bit, setgid bit, restricted deletion flag or sticky bit. | everyone |
| UnixPermissionBits | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | File permissions | everyone |
| AggregationFlag | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Flag to get aggregation information of the record. Options are: 0 (Initial Poll), 1 (Detail record), 2 (Aggregated to hourly), 3 (Aggregated to daily), 4 (Archived - last record older than stale period). | everyone |
| PollType | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) | Flag to get poll type information of the record. Options are: 0 (Normal Poll), 1 (Initial Poll), 2 (Upgrade Poll - special poll after upgrade). | everyone |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SCMNode | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.SCM.SCMNodesReferencesElementMetadata (System.Reference) |
| PolledElement | [Orion.SCM.Results.PolledElements](./../Orion.SCM.Results/PolledElements) | Defined by relationship Orion.SCMPolledElementsReferencesElementMetadata (System.Reference) |


---
id: BlockingChain
slug: BlockingChain
---

# DPA.BlockingChain

SolarWinds Information Service 2020.2 Schema Documentation Index

The entity represents trees of blocker-blockee relationship as in the "Blockers" tab in the UI

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ExtensionEntity](./../System/ExtensionEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| DatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Reference to Orion.DPA.DatabaseInstance.Id. | everyone |
| GlobalDatabaseId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Unique ID of database instance in Orion | everyone |
| ChainNumber | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifies rows belonging to the same blocker-blockee tree. This value is generated with each request, so it is not guaranteed that the same blocker/blockee tree will have the same ChainNumber in two SWQL results. | everyone |
| SessionId | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Session Id. | everyone |
| BlockedBySession | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | SessionId of the session that blocked this session. Is NULL if this session is the root blocker of the blocker-blockee tree identified by RootSessionId. | everyone |
| WaitTimeSecs | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) | Number of seconds the session spent waiting in the particular blocking chain because it was (transitively) blocked by the root session. This value is 0 for the root session (it is not blocked by itself). | everyone |
| Time | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Beginning and end of the interval for which we want to know the blockers and blockees (operators &amp;lt;, &amp;lt;=, &amp;gt; and &amp;gt;= can be used in WHERE clauses on this field). End defaults to now. | everyone |


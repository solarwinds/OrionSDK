---
id: MessageSources
slug: MessageSources
---

# Orion.OLM.MessageSources

SolarWinds Information Service 2020.2 Schema Documentation Index

Message sources are IP addresses from which Log Viewer received a message or event.
They can be licensed, unlicensed, unmonitored message sources and so on.

Message sources can be duplicated for various reasons: 
 * message sources per engine,
 * dynamically assigned IP addresses, 
 * ...

If there is more message sources with the same NodeID, they still count as one Orion node, see Orion.OLM.Nodes entity.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| create,read,update,delete,invoke | admin |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| MessageSourceID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of message source. | everyone |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of mapped Orion node. Can be empty if message source was not recognized. Such nodes are treated as Unmonitored. | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of an engine on which the message was received. | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Caption of mapped node copied from node. | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Primary IP address of mapped node. | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Machine type of mapped node copied from node. | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Vendor of mapped node copied from node. | everyone |
| Created | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Date and time when first message was recevied from this IP address. | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | License status of the message source. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| OrionNode | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.OLMMessageSourceOrionNodes (System.Reference) |
| Events | [Orion.OLM.LogEntry](./../Orion.OLM/LogEntry) | Defined by relationship Orion.OLMMessageSourcesLogEntry (System.Reference) |


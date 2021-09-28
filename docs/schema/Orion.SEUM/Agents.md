---
id: Agents
slug: Agents
---

# Orion.SEUM.Agents

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents the Agent information.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | admin |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of agent. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the agent. | everyone |
| Hostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent hostname. | everyone |
| DNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent DNS name. | everyone |
| IP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent IP. | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent OS version. | everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent password. | everyone |
| Url | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent url. | everyone |
| Port | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains port. | everyone |
| UseProxy | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if agent uses proxy. | everyone |
| ProxyUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent proxy url. | everyone |
| UseProxyAuthentication | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if agent uses proxy authentication. | everyone |
| ProxyUserName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent proxy user name. | everyone |
| ProxyPassword | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent proxy password. | everyone |
| PollingEngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains polling engine id. | everyone |
| JobId | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains job id. | everyone |
| ConnectionStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains connection status. | everyone |
| ConnectionStatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent connection status message. | everyone |
| InCloud | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifie if agent runs in cloud. | everyone |
| AgentGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The guid value that contains agent guid identifier. | everyone |
| IsActiveAgent | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if agent is active. | everyone |
| AgentVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent version. | everyone |
| LoadPercentage | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains load percentage. | everyone |
| RDPEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if RDP is enabled. | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains Orion column id. | everyone |
| Unmanaged | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | The bolean value that specifies if agent is unmanaged. | everyone |
| ConnectionStatusTimeStampUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | The date value that contains connection status time stamp. | everyone |
| NumAllTransactions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains number of all transactions. | everyone |
| NumManagedTransactions | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains number of managed transactions. | everyone |
| AvgLoadPercentageLast30min | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average load percentage from last 30 min. | everyone |
| AvgLoadPercentageLast60min | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The integer value that contains average load percentage from last 60 min. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains agent details url. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Transactions | [Orion.SEUM.Transactions](./../Orion.SEUM/Transactions) | Defined by relationship Orion.SEUM.AgentHostsTransactions (System.Hosting) |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.SEUM.AgentReferencesEngine (System.Reference) |
| AgentStatuses | [Orion.SEUM.AgentStatus](./../Orion.SEUM/AgentStatus) | Defined by relationship Orion.SEUM.AgentReferencesAgentStatus (System.Reference) |
| AgentStatusReports | [Orion.SEUM.AgentStatusReport](./../Orion.SEUM/AgentStatusReport) | Defined by relationship Orion.SEUM.AgentReferencesAgentStatusReport (System.Reference) |
| WebUri | [Orion.SEUM.AgentWebUri](./../Orion.SEUM/AgentWebUri) | Defined by relationship Orion.SEUM.AgentHostsWebUri (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ConnectionStatusInfo | [Orion.SEUM.AgentConnectionStatus](./../Orion.SEUM/AgentConnectionStatus) | Defined by relationship Orion.SEUM.AgentReferencesConnectionStatus (System.Reference) |


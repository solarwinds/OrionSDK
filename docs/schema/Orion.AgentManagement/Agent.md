---
id: Agent
slug: Agent
---

# Orion.AgentManagement.Agent

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents an agent.

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete | admin |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| AgentId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of agent | everyone |
| AgentGuid | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) | The globally unique identifier representation of agent | everyone |
| NodeId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | The unique integer representation of parent node. | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The string value that contains the name of the agent. | everyone |
| Hostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Hostname of the server that this agent resides on. | everyone |
| DNSName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Full DNS name of the server that this agent resides on. | everyone |
| IP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | IP Address of the server that this agent resides on. | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Version of the operating system Linux agent binaries were built for; for a Windows Agent same as RuntimeOSVersion. | everyone |
| PollingEngineId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of the polling engine | everyone |
| ConnectionStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An integer value which represents the current connection status of the agent to AMS | everyone |
| ConnectionStatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A human readable string description of the current connection status of the agent to AMS | everyone |
| ConnectionStatusTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last time that the connection status was updated | everyone |
| AgentStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An integer value which represents the current agent status | everyone |
| AgentStatusMessage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A human readable string description of the current agent status | everyone |
| AgentStatusTimestamp | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Last time that the agent status was updated | everyone |
| IsActiveAgent | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | A boolean value indicating if the agent is in active mode (Agent-initiated communication) as opposed to passive (Server-initiated communication) | everyone |
| Mode | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | A integer value with a value of 1 if the agent is in active mode (Agent-initiated communication), with a value of 2 if the agent is in passive (Server-initiated communication) mode or with a value of 0 if agent mode will be automatically detected during installation. | everyone |
| AgentVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Full version of the agent binaries. | everyone |
| AutoUpdateEnabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | A boolean value that indicates if this agent can be updated without user intervention | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Name of column/property with Agent ID. It's used internally by Orion. | everyone |
| PassiveAgentHostname | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The hostname or IP address of the agent which AMS uses to connect to agent in passive mode. | everyone |
| PassiveAgentPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The listening port of the agent which AMS uses to connect to agent in passive mode. | everyone |
| ProxyId | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | ID of the proxy through which Agent to AMS connection takes place through | everyone |
| RegisteredOn | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Timestamp at which the agent was registered with AMS | everyone |
| SID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | The Windows security identifier of the server that the agent is installed on, or a unique-like idendifier of the server in case of Linux system. | everyone |
| Is64Windows | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | A boolean value indicating if the operating system of the agent is 64 bit. | everyone |
| CPUArch | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the architecture of the CPU of the agent server. | everyone |
| OSArch | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the architecture of the operating system of the agent server. | everyone |
| OSType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value which is the type of the operating system | everyone |
| OSDistro | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the Linux type of distribution. | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An integer value indicating in miliseconds how long it takes for a data message to go from AMS to Agent and back | everyone |
| Type | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | An integer value indicating the type. Currently not used and always 0. | everyone |
| RuntimeOSDistro | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the Linux distribution, where the Agent runs. | everyone |
| RuntimeOSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating the OS version, where the Agent runs. | everyone |
| RuntimeOSLabel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value indicating a human readable operating system label, where the Agent runs. | everyone |
| OSLabel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A string value representing a human readable operating system label. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Plugins | [Orion.AgentManagement.AgentPlugin](./../Orion.AgentManagement/AgentPlugin) | Defined by relationship Orion.AgentManagement.AgentHostsPlugin (System.Hosting) |
| Probe | [Orion.NetPath.Probes](./../Orion.NetPath/Probes) | Defined by relationship Orion.NPM.NetPath.AgentReferencesProbes (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.AgentManagement.EngineReferencesAgent (System.Reference) |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.AgentManagement.NodeReferencesAgent (System.Reference) |
| LogProfiles | [Orion.OLM.LogProfile](./../Orion.OLM/LogProfile) | Defined by relationship Orion.OLMLogProfileAgents (System.Reference) |

## Verbs

### Deploy

Deploys an agent to a machine defined by hostname and/or IP address.

#### Access control

everyone

### DeployToNode

Deploys an agent to an existing node using the supplied credentials.

#### Access control

everyone

### DeployPlugin

Deploys the specified plugin to the agent

#### Access control

everyone

### RedeployPlugin

Redeploys the specified plugin to the agent

#### Access control

everyone

### UninstallPlugin

Uninstalls the specified plugin from the agent

#### Access control

everyone

### Uninstall

Uninstalls the agent.

#### Access control

everyone

### Delete

Deletes the agent without uninstalling it.

#### Access control

everyone

### ApproveReboot

Approval for an agent to reboot.

#### Access control

everyone

### ApproveUpdate

Approval for an agent to be updated.

#### Access control

everyone

### TestWithEngine

Tests the connection between the agent and AMS

#### Access control

everyone

### AssignToEngine

Assigns an agent to a polling engine.

#### Access control

everyone

### ValidateDeploymentCredentials

Validates if provided credentials are valid for agent deployment. If credentials pass validation they can be safely used for deployment via Deploy verb.

#### Access control

everyone

### RestartAgent

Initiate Orion Agent service restart.

#### Access control

everyone

### PromoteAgentToRemoteCollector

#### Access control

everyone

### AddAgent

Creates Agent entry.

#### Access control

everyone

### UpdateAgent

Updates Agent entry.

#### Access control

everyone

### AddPassiveAgent

Adds passive agent. This verb exists for usability convenience and uses AddAgent verb internally.

#### Access control

everyone

### TestPassiveAgentConnection

Verifies whether connection to passive agent is possible.

#### Access control

everyone


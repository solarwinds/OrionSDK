---
title: Agents
---

Agents on the Orion Platform are managed through the `Orion.AgentManagement.Agent` entity.
Each instance of `Orion.AgentManagement.Agent` represents one agent.

## Properties

The `Orion.AgentManagement.Agent` entity has a number of properties related to the identity, configuration, and status and status of the agent.
The full list is [here](https://solarwinds.github.io/OrionSDK/schema/Orion.AgentManagement.Agent.html).

The `AgentStatus` property is an integer with the following possible values:

| Value | Definition |
|------:|------------|
| 0 | Unknown |
| 1 | Ok |
| 2 | UpdateAvailable |
| 3 | UpdateInProgress |
| 4 | UpdateFailed |
| 5 | RebootRequired |
| 6 | RebootInProgress |
| 7 | RebootFailed |
| 8 | PluginUpdatePending |

The `AgentStatusMessage` property provides a human-readable version of the same data.

The `ConnectionStatus` property is an integer with the following possible values:

| Value | Definition |
|------:|------------|
| 0 | Unknown |
| 1 | Ok |
| 2 | ServiceNotResponding |
| 3 | DeploymentPending |
| 4 | DeploymentInProgress |
| 5 | DeploymentFailed |
| 6 | InvalidResponse |
| 7 | WaitingForConnection |

The `ConnectionStatusMessage` property provides a human-readable version of the same data.

## Verbs

The `Orion.AgentManagement.Agent` entity provides a number of verbs to deploy and manage agents.
Parameters are listed in C# syntax.

### ApproveReboot

```csharp
public bool ApproveReboot(int agentId);
```

### ApproveUpdate

```csharp
public void ApproveUpdate(int agentId);
```

### AssignToEngine

```csharp
public bool AssignToEngine(int agentId, int pollerId);
```

Changes the polling engine that manages a particular agent.
In the case of an agent that uses server-initiated communication, this changes which Orion server will connect to the agent.
In the case of agent-initiated communication, this changes which Orion server the agent connects to.

### Delete

```csharp
public void Delete(int agentId);
```

Causes the Orion server to abandon and forget about the specified agent.
This does not remove the SolarWinds agent software from the target.
To do remove the agent software from the target, call [Uninstall](#uninstall) instead.

### Deploy

```csharp
public int Deploy(
    int pollingEngineId,
    string agentName,
    string hostname,
    string ipAddress,
    string machineUserName,
    string machinePassword,
    string additionalUsername = null,
    string additionalPassword = null,
    bool passwordIsPrivateKey = false,
    string privateKeyPassword = null,
    int agentMode = (int)AgentMode.Auto,
    string installPackageFallbackId = null);
```

The [DeployAgentViaVerb.ps1](https://github.com/solarwinds/OrionSDK/blob/master/Samples/PowerShell/DeployAgentViaVerb.ps1) sample shows several variations on how to call the `Deploy` verb.
It also includes descriptions of the various parameters.

### DeployPlugin

```csharp
public void DeployPlugin(int agentId, string pluginId);
```

### DeployToNode

```csharp
public int DeployToNode(
    int nodeId,
    string machineUserName = null,
    string machinePassword = null,
    string additionalUsername = null,
    string additionalPassword = null,
    bool passwordIsPrivateKey = false,
    string privateKeyPassword = null,
    int agentMode = (int)AgentMode.Auto,
    string installPackageFallbackId = null);
```

### RedeployPlugin

```csharp
public void RedeployPlugin(int agentId, string pluginId);
```

### TestWithEngine

```csharp
public bool TestWithEngine(int agentId, int pollerId);
```

The purpose of `TestWithEngine` is to check whether an agent can communicate with a different polling engine than the one it is currently assigned to.
If you reassign an agent without testing first and it turns out that a firewall blocks that communication, Orion would have no way to undo the change since it can no longer talk to the agent.

This verb returns `true` immediately if you call it with the ID of the polling engine the agent is already assigned to, regardless of whether the agent is currently connected.
Use the `AgentStatus` and `ConnectionStatus` properties if you just need to check on the status of the agent's normal connection.

### Uninstall

```csharp
public bool Uninstall(int agentId);
```

### UninstallPlugin

```csharp
public void UninstallPlugin(int agentId, string pluginId);
```

### ValidateDeploymentCredentials

Tests a credentials for agent deployment.

```csharp
public Tuple<bool, string, int, int> ValidateDeploymentCredentials(
    int pollingEngineId,                     // ID of engine from which deployment will be performed
    string hostname,                         // Hostname of target machine
    string ipAddress,                        // IP address of target machine
    string machineUserName,                  // Username for deployment
    string machinePassword,                  // Password for deployment
    string additionalUsername = null,        // Optional additional username for privilege elevation (sudo)
    string additionalPassword = null,        // Optional additional password for privilege elevation
    bool passwordIsPrivateKey = false,       // If true then machinePassword contains private key of authentication certificate
    string privateKeyPassword = null,        // Optional password to private key. Used only if passwordIsPrivateKey is true.
    string installPackageFallbackId = null); // If credential test can't automatically detect install package this value can be used to manually define install package for the test.
```

Returns 4-Tuple of bool, string, int, and int.
The boolean tells if credentials are valid.
The string contains an error message if credentials are not valid.
The first int tells if there is an agent on the machine already installed (monitored by either this or another server); the values are defined by the `SolarWinds.AgentManagement.Contract.AgentDetectionInfo` enum.
The second int tells what is the failure code; the values are defined by the `SolarWinds.AgentManagement.Contract.DeploymentFailureReason` enum.

## Update resources on agent nodes in bulk

If you are running NPM 2019.4 or later, you can use the `ScheduleListResources` verb on `Orion.Nodes` when you want to bulk update all resources on agent nodes, such as interfaces or volumes.
The [ImportListResources.ps1](https://github.com/solarwinds/OrionSDK/blob/master/Samples/PowerShell/ImportListResources.ps1) sample script shows how to do this in PowerShell.
It also uses the `GetScheduledListResourcesStatus` verb to check on the status of the job as it progresses, and it invokes `ImportListResourcesResult` to perform the import when it is complete.

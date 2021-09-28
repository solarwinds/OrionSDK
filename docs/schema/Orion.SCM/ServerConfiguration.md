---
id: ServerConfiguration
slug: ServerConfiguration
---

# Orion.SCM.ServerConfiguration

SolarWinds Information Service 2020.2 Schema Documentation Index

This entity represents nodes, which are monitored by SCM product.
      Every SCM node, can be polled for configuration changes.

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | manageNodes |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Identifier of node monitored. | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) | Boolean value indicating whether given server configuration is enabled. | everyone |
| PollingInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Polling interval for given node in minutes (Apply only for SWIS element). | everyone |
| LastPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of last poll - which is basically anytime when some change arrives for processing. | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | String description of status. | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Status LED indicator. | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Url to detail page of server configuration. | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Server configuration description. | everyone |
| Image | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | Image icon indicating server configuration status. | everyone |
| BaselineStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Numeric value indicating baseline status. Options are: 0 (No baseline set), 1 (Is baseline), 2 (Matches baseline), 3 (Differs from baseline) | everyone |
| LastAgentPluginHealthCheck | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of last health check - indicating that change detection is working properly. | everyone |
| LastChangeDetected | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) | Datetime of last detected change, when it was polled. | everyone |
| AssignedProfileList | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) | A comma-delimited list of assigned profiles. | everyone |
| ErrorCount | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) | Count of Issues existing on node (incompatible element errors are grouped per profile. | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| NodesProfiles | [Orion.SCM.NodesProfiles](./../Orion.SCM/NodesProfiles) | Defined by relationship NodeReferencesOrion.SCM.NodesProfiles (System.Reference) |
| Baselines | [Orion.SCM.Baseline](./../Orion.SCM/Baseline) | Defined by relationship Orion.SCM.NodesReferencesBaseline (System.Reference) |
| ElementMetadata | [Orion.SCM.Results.ElementMetadata](./../Orion.SCM.Results/ElementMetadata) | Defined by relationship Orion.SCM.SCMNodesReferencesElementMetadata (System.Reference) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Node | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.NodesHostsServerConfigurations (System.Hosting) |
| Profiles | [Orion.SCM.Profiles](./../Orion.SCM/Profiles) | Defined by relationship Orion.SCM.NodeReferencesOrion.SCM.Profiles (System.Reference) |
| PollEntries | [Orion.SCM.PollEntries](./../Orion.SCM/PollEntries) | Defined by relationship Orion.SCM.SCMPollEntriesReferencesSCMNodes (System.Reference) |
| SCMServerConfigurationChange | [Orion.SCM.ServerConfigurationChange](./../Orion.SCM/ServerConfigurationChange) | Defined by relationship Orion.SCM.ServerConfigurationChangeRel (System.Reference) |
| SCMServerConfigurationDiffersFromBaseline | [Orion.SCM.ServerConfigurationDiffersFromBaseline](./../Orion.SCM/ServerConfigurationDiffersFromBaseline) | Defined by relationship Orion.SCM.ServerConfigurationDiffersFromBaselineRel (System.Reference) |

## Verbs

### PollNow

On target nodes triggers refreshing of watchers and executes jobs for polling SWIS elements.

#### Access control

everyone

### EnableFimDriverWatching

On target node enable polling through FIM driver if it was previously disabled by DisableFimDriverWatching verb.

#### Access control

everyone

### DisableFimDriverWatching

On target node disable polling through FIM driver.

#### Access control

everyone


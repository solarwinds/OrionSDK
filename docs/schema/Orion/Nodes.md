---
id: Nodes
slug: Nodes
---

# Orion.Nodes

SolarWinds Information Service 2020.2 Schema Documentation Index

ToDo

## Inheritance

↳ [System.Entity](./../System/Entity)

↳ [System.ManagedEntity](./../System/ManagedEntity)

## Access control

| Operations | Right |
| ------ | ------ |
| read | everyone |
| create,read,update,delete,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ObjectSubType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddress | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DynamicIP | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Caption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Description | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DNS | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysObjectID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Location | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Contact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Icon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PolledStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| StatusLED | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusDescription | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeStatusRootCause | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeStatusRootCauseWithLinks | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CustomStatus | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| IOSImage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IOSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| GroupStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| StatusIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SystemUpTime | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentLoss | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| AvgResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MaxResponseTime | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| CPUCount | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| CPULoad | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MemoryUsed | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage1 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage5 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| LoadAverage15 | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| MemoryAvailable | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| PercentMemoryUsed | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| PercentMemoryAvailable | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LastSync | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastSystemUpTimePollUtc | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IsServer | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Severity | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| UiSeverity | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| ChildStatus | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Allow64BitCounters | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| AgentPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TotalMemory | [System.Single](https://docs.microsoft.com/en-us/dotnet/api/system.single) |  | everyone |
| CMTS | [System.Char](https://docs.microsoft.com/en-us/dotnet/api/system.char) |  | everyone |
| CustomPollerLastStatisticsPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| CustomPollerLastStatisticsPollSuccess | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SNMPVersion | [System.Int16](https://docs.microsoft.com/en-us/dotnet/api/system.int16) |  | everyone |
| PollInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| RediscoveryInterval | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NextPoll | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| NextRediscovery | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| StatCollection | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| External | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| Community | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| RWCommunity | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IP_Address | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| IPAddressGUID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| NodeName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| BlockUntil | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| BufferNoMemThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferNoMemToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferSmMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferSmMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferMdMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferMdMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferBgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferBgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferLgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferLgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferHgMissThisHour | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| BufferHgMissToday | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| OrionIdPrefix | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OrionIdColumn | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SkippedPollingCycles | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| MinutesSinceLastSync | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EntityType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DetailsUrl | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| DisplayName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Category | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| IsOrionServer | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Inventory | [Orion.ADM.NodeInventory](./../Orion.ADM/NodeInventory) | Defined by relationship Orion.ADM.NodeHostsNodeInventory (System.Hosting) |
| Agent | [Orion.AgentManagement.Agent](./../Orion.AgentManagement/Agent) | Defined by relationship Orion.AgentManagement.NodeReferencesAgent (System.Reference) |
| ChildNodeToNodeLinks | [Orion.APM.NodeToNodeLink](./../Orion.APM/NodeToNodeLink) | Defined by relationship Orion.APM.NodeToNodeLinkReferencesChildNode (System.Reference) |
| ParentNodeToNodeLinks | [Orion.APM.NodeToNodeLink](./../Orion.APM/NodeToNodeLink) | Defined by relationship Orion.APM.NodeToNodeLinkReferencesParentNode (System.Reference) |
| OutApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesClientNode (System.Reference) |
| InApplicationTcpConnections | [Orion.APM.ApplicationTcpConnection](./../Orion.APM/ApplicationTcpConnection) | Defined by relationship Orion.APM.ApplicationTcpConnectionReferencesServerNode (System.Reference) |
| Applications | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.APM.NodeHostsApplication (System.Hosting) |
| ScheduledTasks | [Orion.APM.Wstm.Task](./../Orion.APM.Wstm/Task) | Defined by relationship Orion.APM.NodeReferencesScheduledTasks (System.Reference) |
| ASANode | [Orion.ASA.Node](./../Orion.ASA/Node) | Defined by relationship Orion.NodeHostsASANode (System.Hosting) |
| ConnectionStatistic | [Orion.ASA.ConnectionStatistics](./../Orion.ASA/ConnectionStatistics) | Defined by relationship Orion.NodeHostsASAConnectionStatistics (System.Hosting) |
| ASAFavoriteInterface | [Orion.ASA.FavoriteInterfaces](./../Orion.ASA/FavoriteInterfaces) | Defined by relationship Orion.NodeHostsASAFavoriteInterface (System.Hosting) |
| NodeWarrantyAlert | [Orion.AssetInventory.NodeWarrantyAlert](./../Orion.AssetInventory/NodeWarrantyAlert) | Defined by relationship Orion.AssetInventory.NodeReferencesNodeWarrantyAlert (System.Reference) |
| AssetInventory | [Orion.AssetInventory.Polling](./../Orion.AssetInventory/Polling) | Defined by relationship Orion.AssetInventory.NodesAIPolling (System.Reference) |
| CBQoSPolicyActions | [Orion.Netflow.CBQoSPolicyAction](./../Orion.Netflow/CBQoSPolicyAction) | Defined by relationship Orion.Netflow.NodeReferencesCBQoSPolicyAction (System.Reference) |
| CBQoSPolicies | [Orion.Netflow.CBQoSPolicy](./../Orion.Netflow/CBQoSPolicy) | Defined by relationship Orion.Netflow.NodeReferencesCBQoSPolicy (System.Reference) |
| CBQoSSource | [Orion.Netflow.CBQoSSource](./../Orion.Netflow/CBQoSSource) | Defined by relationship Orion.Netflow.NodeReferencesCBQoSSource (System.Reference) |
| NCMLicenseStatus | [Cirrus.NCMNodeLicenseStatus](./../Cirrus/NCMNodeLicenseStatus) | Defined by relationship Orion.NodeHostLicensedByNCM (System.Hosting) |
| NodeProperties | [NCM.NodeProperties](./../NCM/NodeProperties) | Defined by relationship Orion.NodesHostsNodeProperties (System.Hosting) |
| Containers | [Cortex.Orion.Cman.Container](./../Cortex.Orion.Cman/Container) | Defined by relationship Orion.NodesToCortexContainer (System.Hosting) |
| ContainersRel | [Cortex.Orion.Cman.Container](./../Cortex.Orion.Cman/Container) | Defined by relationship Orion.Rely.NodesToCortexContainer (System.Reliance) |
| Apic | [Cortex.Orion.CiscoAci.Apic](./../Cortex.Orion.CiscoAci/Apic) | Defined by relationship Cortex.Orion.OrionNodeToApic (System.Hosting) |
| Firewall | [Cortex.Orion.NetMan.Firewalls.Firewall](./../Cortex.Orion.NetMan.Firewalls/Firewall) | Defined by relationship Cortex.Orion.OrionNodeToFirewall (System.Hosting) |
| PCUs | [Cortex.Orion.PowerControlUnit](./../Cortex.Orion/PowerControlUnit) | Defined by relationship Cortex.Orion.OrionNodeToPCUs (System.Hosting) |
| DatabaseInstanceData | [Orion.DPA.DatabaseInstanceData](./../Orion.DPA/DatabaseInstanceData) | Defined by relationship Orion.NodesDatabaseInstanceData (System.Reference) |
| DPIApplicationAssignment | [Orion.DPI.ApplicationAssignments](./../Orion.DPI/ApplicationAssignments) | Defined by relationship Orion.DPI.NodeToApplicationAssignment (System.Hosting) |
| DPIProbeAssignment | [Orion.DPI.ProbeAssignments](./../Orion.DPI/ProbeAssignments) | Defined by relationship Orion.DPI.NodeToProbeAssignment (System.Hosting) |
| EnergyWiseDevice | [Orion.NPM.EW.Device](./../Orion.NPM.EW/Device) | Defined by relationship Orion.NodeHostsEWDevice (System.Hosting) |
| DeviceStats | [Orion.NPM.EW.DeviceStats](./../Orion.NPM.EW/DeviceStats) | Defined by relationship Orion.NodeHostsEWDeviceStats (System.Hosting) |
| F5Devices | [Orion.F5.System.Device](./../Orion.F5.System/Device) | Defined by relationship Orion.NodeHostsF5Device (System.Hosting) |
| FCUnits | [Orion.NPM.FCUnits](./../Orion.NPM/FCUnits) | Defined by relationship Orion.NodesHostsFCUnits (System.Hosting) |
| HardwareHealthInfos | [Orion.HardwareHealth.HardwareInfo](./../Orion.HardwareHealth/HardwareInfo) | Defined by relationship Orion.HardwareHealth.NodeHostsHardwareInfo (System.Hosting) |
| HardwareCategoryStatus | [Orion.HardwareHealth.HardwareCategoryStatus](./../Orion.HardwareHealth/HardwareCategoryStatus) | Defined by relationship Orion.HardwareHealth.NodeReferenceHardwareCategoryStatus (System.Reference) |
| HardwareItems | [Orion.HardwareHealth.HardwareItem](./../Orion.HardwareHealth/HardwareItem) | Defined by relationship Orion.HardwareHealth.NodeReferencesHardwareItem (System.Reference) |
| Interfaces | [Orion.NPM.Interfaces](./../Orion.NPM/Interfaces) | Defined by relationship Orion.NodeHostsInterfaces (System.Hosting) |
| GroupReport | [IPAM.GroupReport](./../IPAM/GroupReport) | Defined by relationship IPAM.GroupReportNodes (System.Reference) |
| ScopeOverLapping | [IPAM.DHCPScopeOverlapping](./../IPAM/DHCPScopeOverlapping) | Defined by relationship Orion.NodesReferDHCPScopeOverlapping (System.Reference) |
| CCMMonitoring | [Orion.IpSla.CCMMonitoring](./../Orion.IpSla/CCMMonitoring) | Defined by relationship Orion.NodesHostsCCMMonitoring (System.Hosting) |
| VoIPInfrastructure | [Orion.IpSla.InfrastructureNodes](./../Orion.IpSla/InfrastructureNodes) | Defined by relationship Orion.Ipsla.NodeHostsInfrastructureNodes (System.Hosting) |
| IpSlaOperations | [Orion.IpSla.Operations](./../Orion.IpSla/Operations) | Defined by relationship Orion.IpSla.NodeHostsIpSlaOperations (System.Hosting) |
| IpSlaOperationsAsTarget | [Orion.IpSla.Operations](./../Orion.IpSla/Operations) | Defined by relationship Orion.IpSla.IpSlaOperationsReferencesTargetNode (System.Reference) |
| IpSlaSite | [Orion.IpSla.Sites](./../Orion.IpSla/Sites) | Defined by relationship Orion.NodesHostsSites (System.Hosting) |
| VoipGateways | [Orion.IpSla.VoipGateways](./../Orion.IpSla/VoipGateways) | Defined by relationship Orion.NodesHostsVoipGateways (System.Hosting) |
| GroupNodes | [Orion.NPM.MulticastRouting.GroupNodes](./../Orion.NPM.MulticastRouting/GroupNodes) | Defined by relationship Orion.NPM.MulticastRouting.NodesHostsGroupNodes (System.Hosting) |
| Flows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.NodesReferencesFlows (System.Reference) |
| FlowsWLC | [Orion.Netflow.FlowsWLC](./../Orion.Netflow/FlowsWLC) | Defined by relationship Orion.Netflow.NodesReferencesFlowsWLC (System.Reference) |
| FlowsByIP | [Orion.Netflow.FlowsByIP](./../Orion.Netflow/FlowsByIP) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByIP (System.Reference) |
| FlowsByHostname | [Orion.Netflow.FlowsByHostname](./../Orion.Netflow/FlowsByHostname) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByHostname (System.Reference) |
| FlowsByAS | [Orion.Netflow.FlowsByAS](./../Orion.Netflow/FlowsByAS) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByAS (System.Reference) |
| FlowsByInterface | [Orion.Netflow.FlowsByInterface](./../Orion.Netflow/FlowsByInterface) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByInterface (System.Reference) |
| FlowsByDomain | [Orion.Netflow.FlowsByDomain](./../Orion.Netflow/FlowsByDomain) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByDomain (System.Reference) |
| FlowsByCountryCode | [Orion.Netflow.FlowsByCountryCode](./../Orion.Netflow/FlowsByCountryCode) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByCountryCode (System.Reference) |
| FlowsByConversation | [Orion.Netflow.FlowsByConversation](./../Orion.Netflow/FlowsByConversation) | Defined by relationship Orion.Netflow.NodesReferencesFlowsByConversation (System.Reference) |
| Flows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.NodesReferencesFlows (System.Reference) |
| FlowsWLC | [Orion.Netflow.FlowsWLC](./../Orion.Netflow/FlowsWLC) | Defined by relationship Orion.Netflow.NodesReferencesFlowsWLC (System.Reference) |
| NetflowSources | [Orion.Netflow.Source](./../Orion.Netflow/Source) | Defined by relationship Orion.Netflow.NodeReferencesSource (System.Reference) |
| NetflowNodeSources | [Orion.Netflow.NodeSources](./../Orion.Netflow/NodeSources) | Defined by relationship Orion.Netflow.NodeReferencesNodeSources (System.Reference) |
| VirtualPortChannels | [Orion.Nexus.VirtualPortChannel](./../Orion.Nexus/VirtualPortChannel) | Defined by relationship Orion.NodeHostsVirtualPortChannels (System.Hosting) |
| CustomPollerAssignmentOnNode | [Orion.NPM.CustomPollerAssignmentOnNode](./../Orion.NPM/CustomPollerAssignmentOnNode) | Defined by relationship Orion.NodesHostsCustomPollerAssignmentOnNode (System.Hosting) |
| SwitchStack | [Orion.NPM.SwitchStack](./../Orion.NPM/SwitchStack) | Defined by relationship Orion.NodesHostsSwitchStack (System.Hosting) |
| NPMNode | [Orion.NPM.Nodes](./../Orion.NPM/Nodes) | Defined by relationship Orion.OrionNodeHostsNPMNode (System.Hosting) |
| LogNode | [Orion.OLM.Nodes](./../Orion.OLM/Nodes) | Defined by relationship Orion.OLMNodesOrionNodes (System.Reference) |
| DiscoveryLog | [Orion.DiscoveryLogNodes](./../Orion/DiscoveryLogNodes) | Defined by relationship Orion.NodesHostsDiscoveryLogNodes (System.Reference) |
| OrionHwHBMCRacks | [Orion.HardwareHealth.BMC.Racks](./../Orion.HardwareHealth.BMC/Racks) | Defined by relationship Orion.HardwareHealth.BMC.NodesReferenceOrionHWHBMCRacks (System.Reference) |
| BMCControllerNodeForRack | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.HardwareHealth.BMC.RackNodesRelianceControllerNode (System.Reliance) |
| CpuLoadThreshold | [Orion.CpuLoadThreshold](./../Orion/CpuLoadThreshold) | Defined by relationship Orion.NodesHostsCpuLoadThreshold (System.Hosting) |
| PercentMemoryUsedThreshold | [Orion.PercentMemoryUsedThreshold](./../Orion/PercentMemoryUsedThreshold) | Defined by relationship Orion.NodesHostsPercentMemoryUsedThreshold (System.Hosting) |
| ResponseTimeThreshold | [Orion.ResponseTimeThreshold](./../Orion/ResponseTimeThreshold) | Defined by relationship Orion.NodesHostsResponseTimeThreshold (System.Hosting) |
| PercentLossThreshold | [Orion.PercentLossThreshold](./../Orion/PercentLossThreshold) | Defined by relationship Orion.NodesHostsPercentLossThreshold (System.Hosting) |
| SNMPv3Credentials | [Orion.SNMPv3Credentials](./../Orion/SNMPv3Credentials) | Defined by relationship Orion.NodesHostsSNMPv3Credentials (System.Hosting) |
| WebCommunityString | [Orion.NodesWebCommunityStrings](./../Orion/NodesWebCommunityStrings) | Defined by relationship Orion.NodeHostsWebCommunityStrings (System.Hosting) |
| OrionServer | [Orion.OrionServers](./../Orion/OrionServers) | Defined by relationship Orion.NodeHostsOrionServers (System.Reference) |
| CiscoBuffersHistory | [Orion.CiscoBuffers](./../Orion/CiscoBuffers) | Defined by relationship Orion.NodesHostsCiscoBuffers (System.Hosting) |
| CPULoadHistory | [Orion.CPULoad](./../Orion/CPULoad) | Defined by relationship Orion.NodesHostsCPULoad (System.Hosting) |
| CPUMultiLoadHistory | [Orion.CPUMultiLoad](./../Orion/CPUMultiLoad) | Defined by relationship Orion.NodesHostsCPUMultiLoad (System.Hosting) |
| MemoryMultiLoadHistory | [Orion.MemoryMultiLoad](./../Orion/MemoryMultiLoad) | Defined by relationship Orion.NodesHostsMemoryMultiLoad (System.Hosting) |
| LoadAverageHistory | [Orion.LoadAverage](./../Orion/LoadAverage) | Defined by relationship Orion.NodesHostsLoadAverage (System.Hosting) |
| Events | [Orion.Events](./../Orion/Events) | Defined by relationship Orion.NodesHostsEvents (System.Reference) |
| AlertObjects | [Orion.AlertObjects](./../Orion/AlertObjects) | Defined by relationship Orion.NodesReferencesAlertObjects (System.Reference) |
| ActiveAlerts | [Orion.ActiveAlerts](./../Orion/ActiveAlerts) | Defined by relationship Orion.NodesHostsActiveAlerts (System.Reference) |
| CustomProperties | [Orion.NodesCustomProperties](./../Orion/NodesCustomProperties) | Defined by relationship Orion.NodesHostsCustomProperties (System.Hosting) |
| Stats | [Orion.NodesStats](./../Orion/NodesStats) | Defined by relationship Orion.NodesHostsNodesStats (System.Hosting) |
| WebUri | [Orion.NodeWebUri](./../Orion/NodeWebUri) | Defined by relationship Orion.NodesHostsWebUri (System.Hosting) |
| ResponseTimeHistory | [Orion.ResponseTime](./../Orion/ResponseTime) | Defined by relationship Orion.NodesHostsResponseTime (System.Hosting) |
| Volumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.NodeHostsVolumes (System.Hosting) |
| WorldMapPoint | [Orion.WorldMap.Point](./../Orion.WorldMap/Point) | Defined by relationship Orion.NodesToWorldMapPoint (System.Reference) |
| TechnologyPollingAssignments | [Orion.TechnologyPollingAssignments](./../Orion/TechnologyPollingAssignments) | Defined by relationship Orion.NodesReferenceTechnologyPollingAssignments (System.Reference) |
| NodeDowntimeHistory | [Orion.NetObjectDowntime](./../Orion/NetObjectDowntime) | Defined by relationship Orion.NodesHostsNetObjectDowntime (System.Hosting) |
| ForecastCapacity | [Orion.NodesForecastCapacity](./../Orion/NodesForecastCapacity) | Defined by relationship Orion.NodesHostsForecastCapacity (System.Hosting) |
| NodeIPAddresses | [Orion.NodeIPAddresses](./../Orion/NodeIPAddresses) | Defined by relationship Orion.NodesRefersIPAddresses (System.Reference) |
| UCSChassisViaBlades | [Orion.UCS.Chassis](./../Orion.UCS/Chassis) | Defined by relationship Orion.UCS.BladeNodesRelianceChassis (System.Reliance) |
| OrionUCSFans | [Orion.HardwareHealth.BMC.Fans](./../Orion.HardwareHealth.BMC/Fans) | Defined by relationship Orion.NodeReferencesOrionUCSFans (System.Reference) |
| OrionUCSPSUs | [Orion.HardwareHealth.BMC.PSUs](./../Orion.HardwareHealth.BMC/PSUs) | Defined by relationship Orion.NodeReferencesOrionUCSPSUs (System.Reference) |
| Router | [Orion.Routing.Router](./../Orion.Routing/Router) | Defined by relationship Orion.NodesHostsRouter (System.Hosting) |
| VRFs | [Orion.Routing.VRF](./../Orion.Routing/VRF) | Defined by relationship Orion.NodeHostsVRFs (System.Hosting) |
| SCMFimDisabledNode | [Orion.SCM.FimDisabledNodes](./../Orion.SCM/FimDisabledNodes) | Defined by relationship Orion.NodesReferenceFimDisabledNodes (System.Reference) |
| SCMNode | [Orion.SCM.ServerConfiguration](./../Orion.SCM/ServerConfiguration) | Defined by relationship Orion.NodesHostsServerConfigurations (System.Hosting) |
| AssignedPolicies | [Orion.SCM.AssignedPolicy](./../Orion.SCM/AssignedPolicy) | Defined by relationship Orion.SCM.NodesHostsAssignedPolicies (System.Hosting) |
| AssignedRules | [Orion.SCM.AssignedPolicyRule](./../Orion.SCM/AssignedPolicyRule) | Defined by relationship Orion.SCM.NodesHostsAssignedPolicyRules (System.Hosting) |
| NodeVlans | [Orion.NodeVlans](./../Orion/NodeVlans) | Defined by relationship Orion.NodesHostsNodeVlans (System.Hosting) |
| Syslogs | [Orion.SysLog](./../Orion/SysLog) | Defined by relationship Orion.NodesHostsSyslogs (System.Reference) |
| Traps | [Orion.Traps](./../Orion/Traps) | Defined by relationship Orion.NodesHostsTraps (System.Reference) |
| IPAddresses | [Orion.UDT.IPAddressCurrent](./../Orion.UDT/IPAddressCurrent) | Defined by relationship Orion.NodesReferencesIPAddresses (System.Reference) |
| IPAddressesHistory | [Orion.UDT.IPAddressHistory](./../Orion.UDT/IPAddressHistory) | Defined by relationship Orion.NodesReferencesIPAddressesHistory (System.Reference) |
| MACAddressInfo | [Orion.UDT.MACAddressInfo](./../Orion.UDT/MACAddressInfo) | Defined by relationship Orion.NodesReferencesMACAddressInfo (System.Reference) |
| UDTCapabilities | [Orion.UDT.NodeCapability](./../Orion.UDT/NodeCapability) | Defined by relationship Orion.UDT.NodeHostsCapability (System.Hosting) |
| MACCurrentInfo | [Orion.UDT.MACCurrentInfo](./../Orion.UDT/MACCurrentInfo) | Defined by relationship Orion.NodesReferencesMACCurrentInfo (System.Reference) |
| MACCurrentInformation | [Orion.UDT.MACCurrentInformation](./../Orion.UDT/MACCurrentInformation) | Defined by relationship Orion.NodesReferencesMACCurrentInformation (System.Reference) |
| Ports | [Orion.UDT.Port](./../Orion.UDT/Port) | Defined by relationship Orion.UDT.NodeHostsPorts (System.Hosting) |
| ConnectedMACsAndIPs | [Orion.UDT.ConnectedMACsAndIPs](./../Orion.UDT/ConnectedMACsAndIPs) | Defined by relationship Orion.UDT.NodeConnectedMACsAndIPs (System.Reference) |
| UnusedPorts | [Orion.UDT.UnusedPorts](./../Orion.UDT/UnusedPorts) | Defined by relationship Orion.UDT.NodeUnusedPorts (System.Reference) |
| NodeAllEndpoints | [Orion.UDT.AllEndpoints](./../Orion.UDT/AllEndpoints) | Defined by relationship Orion.UDT.NodeReferencesAllEndpoints (System.Reference) |
| NodeAllWirelessEndpoints | [Orion.UDT.AllWirelessEndpoints](./../Orion.UDT/AllWirelessEndpoints) | Defined by relationship Orion.UDT.NodesReferencesAllWirelessEndpoints (System.Reference) |
| NodeDeviceInventory | [Orion.UDT.DeviceInventory](./../Orion.UDT/DeviceInventory) | Defined by relationship Orion.UDT.NodesReferencesDeviceInventory (System.Reference) |
| CloudInstance | [Orion.Cloud.Instances](./../Orion.Cloud/Instances) | Defined by relationship Orion.Cloud.NodesToInstances (System.Reliance) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.NodesToVCenters (System.Reference) |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.NodesToHosts (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.NodesToVirtualMachines (System.Reference) |
| VCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.VIM.NodesToVCenters (System.Reference) |
| Host | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.VIM.NodesToHosts (System.Reference) |
| VirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.VIM.NodesToVirtualMachines (System.Reference) |
| VPNL2LTunnel | [Orion.VPN.L2LTunnel](./../Orion.VPN/L2LTunnel) | Defined by relationship Orion.NodeReferencesVPNL2LTunnel (System.Reference) |
| ASARemoteAccessDetail | [Orion.ASA.RemoteAccessDetail](./../Orion.ASA/RemoteAccessDetail) | Defined by relationship Orion.NodeReferencesASARemoteAccessDetail (System.Reference) |
| ASARemoteAccessSessions | [Orion.ASA.RemoteAccessSessions](./../Orion.ASA/RemoteAccessSessions) | Defined by relationship Orion.NodeReferencesASARemoteAccessSessions (System.Reference) |
| AccessPointsForWLHM | [Orion.WirelessHeatMap.AccessPoints](./../Orion.WirelessHeatMap/AccessPoints) | Defined by relationship Orion.NodeHostsWirelessHeatMap.AccessPoints (System.Hosting) |
| Controller | [Orion.Packages.Wireless.Controllers](./../Orion.Packages.Wireless/Controllers) | Defined by relationship Orion.NodeHostsWirelessController (System.Hosting) |
| AccessPoints | [Orion.Packages.Wireless.AccessPoints](./../Orion.Packages.Wireless/AccessPoints) | Defined by relationship Orion.NodeHostsWirelessAccessPoints (System.Hosting) |

## Target Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| ReplicationSource | [Orion.APM.ActiveDirectory.Replication](./../Orion.APM.ActiveDirectory/Replication) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationSourceNode (System.Reference) |
| ReplicationDestination | [Orion.APM.ActiveDirectory.Replication](./../Orion.APM.ActiveDirectory/Replication) | Defined by relationship Orion.APM.ActiveDirectory.ReplicationDestinationNode (System.Reference) |
| RelyApplications | [Orion.APM.Application](./../Orion.APM/Application) | Defined by relationship Orion.Rely.APM.ApplicationRelyOnNodes (System.Reliance) |
| RelyVolumes | [Orion.Volumes](./../Orion/Volumes) | Defined by relationship Orion.Rely.Core.VolumesRelyOnNodes (System.Reliance) |
| RelyDatabaseInstances | [Orion.DPA.DatabaseInstance](./../Orion.DPA/DatabaseInstance) | Defined by relationship Orion.Rely.DPA.DatabaseInstanceRelyOnNodes (System.Reliance) |
| SwitchPortEntriesAsSource | [Orion.NPM.OrionSwitchPortMapping](./../Orion.NPM/OrionSwitchPortMapping) | Defined by relationship Orion.SwitchPortMappingReferencesSourceNode (System.Reference) |
| SwitchPortEntriesAsMapped | [Orion.NPM.OrionSwitchPortMapping](./../Orion.NPM/OrionSwitchPortMapping) | Defined by relationship Orion.SwitchPortMappingReferencesMappedNode (System.Reference) |
| LogMessageSource | [Orion.OLM.MessageSources](./../Orion.OLM/MessageSources) | Defined by relationship Orion.OLMMessageSourceOrionNodes (System.Reference) |
| OLMAlertMessage | [Orion.OLM.AlertMessage](./../Orion.OLM/AlertMessage) | Defined by relationship Orion.OLMAlertMessageNode (System.Reference) |
| ApiPollers | [Cortex.Orion.ApiPoller.ApiPoller](./../Cortex.Orion.ApiPoller/ApiPoller) | Defined by relationship Cortex.Orion.ApiPollerToNode (System.Reliance) |
| OrionHwHBMCBlades | [Orion.HardwareHealth.BMC.Blades](./../Orion.HardwareHealth.BMC/Blades) | Defined by relationship Orion.HardwareHealth.BMC.BladeReferenceNode (System.Reference) |
| RackNodes | [Orion.Nodes](./../Orion/Nodes) | Defined by relationship Orion.HardwareHealth.BMC.RackNodesRelianceControllerNode (System.Reliance) |
| HwHBMCControllers | [Orion.HardwareHealth.BMC.Controllers](./../Orion.HardwareHealth.BMC/Controllers) | Defined by relationship Orion.OrionHwhBMCControllersReferencesNodes (System.Reference) |
| Engine | [Orion.Engines](./../Orion/Engines) | Defined by relationship Orion.EngineHostsNodes (System.Reference) |
| VendorInfo | [Orion.Vendors](./../Orion/Vendors) | Defined by relationship Orion.VendorsHostsNodes (System.Reference) |
| UCSChassisViaController | [Orion.UCS.Chassis](./../Orion.UCS/Chassis) | Defined by relationship Orion.UCS.ChassisRelianceControllerNode (System.Reliance) |
| OrionUCSFabric | [Orion.UCS.Fabrics](./../Orion.UCS/Fabrics) | Defined by relationship Orion.UCS.FabricReferencesNode (System.Reference) |
| Integrations | [Orion.SamAppOptics.Integration](./../Orion.SamAppOptics/Integration) | Defined by relationship Orion.SamAppOptics.NodeIntegration (System.Reference) |
| NodeSpecAssignment | [Orion.Stencil.NodeSpecAssignments](./../Orion.Stencil/NodeSpecAssignments) | Defined by relationship Orion.NodeSpecAssignmentsNode (System.Reference) |
| RelyVCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.Rely.VIM.VCenterRelyOnNode (System.Reliance) |
| RelyHost | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostRelyOnNode (System.Reliance) |
| RelyVirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachineRelyOnNode (System.Reliance) |
| RelyVCenter | [Orion.VIM.VCenters](./../Orion.VIM/VCenters) | Defined by relationship Orion.Rely.VIM.VCenterRelyOnNode (System.Reliance) |
| RelyHost | [Orion.VIM.Hosts](./../Orion.VIM/Hosts) | Defined by relationship Orion.Rely.VIM.HostRelyOnNode (System.Reliance) |
| RelyVirtualMachine | [Orion.VIM.VirtualMachines](./../Orion.VIM/VirtualMachines) | Defined by relationship Orion.Rely.VIM.VirtualMachineRelyOnNode (System.Reliance) |

## Verbs

### Unmanage

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### Remanage

ToDo

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | allowUnmanage |

### PollNow

It will poll node instance and update its information

#### Access control

everyone

### GetCountOfElementsPerEngineForLicensing

Returns count of used elements (per engine) for licensing

#### Access control

everyone

### ScheduleListResources

Schedule one time List Resources discovery for given NodeId

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### GetScheduledListResourcesStatus

Get current result of discovery job

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### ImportListResourcesResult

Import all results found during discovery

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |


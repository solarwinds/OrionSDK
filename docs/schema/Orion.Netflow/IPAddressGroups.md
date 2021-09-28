---
id: IPAddressGroups
slug: IPAddressGroups
---

# Orion.Netflow.IPAddressGroups

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| create,read,update,invoke | admin |
| read | everyone |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| IPAddressGroupID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| Name | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Enabled | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| SourceFlows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlows (System.Reference) |
| DestinationFlows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlows (System.Reference) |
| SegmentsCS | [Orion.Netflow.IPGroupSegments](./../Orion.Netflow/IPGroupSegments) | Defined by relationship Orion.Netflow.IpGroupSegmentsReferencesIPAddressGroupsByIDCS (System.Reference) |
| SegmentsPivot | [Orion.Netflow.IPGroupsBySegments](./../Orion.Netflow/IPGroupsBySegments) | Defined by relationship Orion.Netflow.IpGroupsBySegmentsReferencesIPAddressGroups (System.Reference) |
| SourceFlowsByIP | [Orion.Netflow.FlowsByIP](./../Orion.Netflow/FlowsByIP) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByIP (System.Reference) |
| DestinationFlowsByIP | [Orion.Netflow.FlowsByIP](./../Orion.Netflow/FlowsByIP) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByIP (System.Reference) |
| SourceFlowsByHostname | [Orion.Netflow.FlowsByHostname](./../Orion.Netflow/FlowsByHostname) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByHostname (System.Reference) |
| DestinationFlowsByHostname | [Orion.Netflow.FlowsByHostname](./../Orion.Netflow/FlowsByHostname) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByHostname (System.Reference) |
| SourceFlowsByAS | [Orion.Netflow.FlowsByAS](./../Orion.Netflow/FlowsByAS) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByAS (System.Reference) |
| DestinationFlowsByAS | [Orion.Netflow.FlowsByAS](./../Orion.Netflow/FlowsByAS) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByAS (System.Reference) |
| SourceFlowsByInterface | [Orion.Netflow.FlowsByInterface](./../Orion.Netflow/FlowsByInterface) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByInterface (System.Reference) |
| DestinationFlowsByInterface | [Orion.Netflow.FlowsByInterface](./../Orion.Netflow/FlowsByInterface) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByInterface (System.Reference) |
| SourceFlowsByDomain | [Orion.Netflow.FlowsByDomain](./../Orion.Netflow/FlowsByDomain) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByDomain (System.Reference) |
| DestinationFlowsByDomain | [Orion.Netflow.FlowsByDomain](./../Orion.Netflow/FlowsByDomain) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByDomain (System.Reference) |
| SourceFlowsByCountryCode | [Orion.Netflow.FlowsByCountryCode](./../Orion.Netflow/FlowsByCountryCode) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByCountryCode (System.Reference) |
| DestinationFlowsByCountryCode | [Orion.Netflow.FlowsByCountryCode](./../Orion.Netflow/FlowsByCountryCode) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByCountryCode (System.Reference) |
| SourceFlowsByConversation | [Orion.Netflow.FlowsByConversation](./../Orion.Netflow/FlowsByConversation) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlowsByConversation (System.Reference) |
| DestinationFlowsByConversation | [Orion.Netflow.FlowsByConversation](./../Orion.Netflow/FlowsByConversation) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlowsByConversation (System.Reference) |
| FlowsByIP | [Orion.Netflow.FlowsByIP](./../Orion.Netflow/FlowsByIP) | Defined by relationship Orion.Netflow.FlowsByIPReferencesIPGroups (System.Reference) |
| FlowsByHostname | [Orion.Netflow.FlowsByHostname](./../Orion.Netflow/FlowsByHostname) | Defined by relationship Orion.Netflow.FlowsByHostnameReferencesIPGroups (System.Reference) |
| SourceFlows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.SourceIPAddressGroupsReferencesFlows (System.Reference) |
| DestinationFlows | [Orion.Netflow.Flows](./../Orion.Netflow/Flows) | Defined by relationship Orion.Netflow.DestinationIPAddressGroupsReferencesFlows (System.Reference) |
| SegmentsCS | [Orion.Netflow.IPGroupSegments](./../Orion.Netflow/IPGroupSegments) | Defined by relationship Orion.Netflow.IpGroupSegmentsReferencesIPAddressGroupsByIDCS (System.Reference) |
| SegmentsPivot | [Orion.Netflow.IPGroupsBySegments](./../Orion.Netflow/IPGroupsBySegments) | Defined by relationship Orion.Netflow.IpGroupsBySegmentsReferencesIPAddressGroups (System.Reference) |

## Verbs

### SetIPRanges

#### Access control

everyone

### DeleteAllIpGroups

#### Access control

everyone

### DeleteIpGroups

#### Access control

everyone

### SetIpGroupsAsModified

#### Access control

everyone


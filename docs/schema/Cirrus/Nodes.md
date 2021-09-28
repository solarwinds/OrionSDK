---
id: Nodes
slug: Nodes
---

# Cirrus.Nodes

SolarWinds Information Service 2020.2 Schema Documentation Index

## Inheritance

↳ [System.Entity](./../System/Entity)

## Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | everyone |
| read,update,invoke | manageNodes |

## Properties

| Name | Type | Summary | Access Control |
| ------ | ------ | ------ | ------ |
| NodeID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| CoreNodeID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EngineID | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| NodeCaption | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeGroup | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentIP | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AgentIPv6 | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ManagedProtocol | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| AgentIPSort | [System.Double](https://docs.microsoft.com/en-us/dotnet/api/system.double) |  | everyone |
| ReverseDNS | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Status | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| StatusText | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Community | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CommunityReadWrite | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPLevel | [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/system.byte) |  | everyone |
| SysName | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysDescr | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysContact | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SysLocation | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SystemOID | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Vendor | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| VendorIcon | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| MachineType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| LastBoot | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| OSImage | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| OSVersion | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConfigTypes | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| NodeComments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Username | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| Password | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnableLevel | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnablePassword | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ExecProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| CommandProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| TransferProtocol | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EncryptionAlgorithm | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| LoginStatus | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| UseHTTPS | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UseUserDeviceCredentials | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastInventory | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| SNMPContext | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPUsername | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPAuthType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPAuthPass | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPEncryptType | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPEncryptPass | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| AllowIntermediary | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| LastUpdateTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| LastRediscoveryTime | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| TelnetPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SSHPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| SNMPPort | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EnableOrionImport | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| UseKeybInteractiveAuth | [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/system.boolean) |  | everyone |
| ResponseError | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ConnectionProfile | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EndOfSupport | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndOfSales | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EndOfSoftware | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EosEntryID | [System.Guid](https://docs.microsoft.com/en-us/dotnet/api/system.guid) |  | everyone |
| EosType | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EosMatchDate | [System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/system.datetime) |  | everyone |
| EosVersion | [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/system.int32) |  | everyone |
| EosLink | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| EosComments | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |
| ReplacementPartNumber | [System.String](https://docs.microsoft.com/en-us/dotnet/api/system.string) |  | everyone |

## Source Relationships

| Name | Type | Notes |
| ------ | ------ | ------ |
| Interfaces | [Cirrus.Interfaces](./../Cirrus/Interfaces) | Defined by relationship Cirrus.NodeHostsInterfaces (System.Hosting) |

## Verbs

### AddNode

Adds a node to NCM given a complete model. Not recommended - use AddNodeToNCM instead.An NCMNode object to add to NCM.The NCM NodeID (Guid) for the new node.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### AddNodes

A batch version of the Cirrus.Nodes.AddNodeToNCM verb. Enables NCM to monitor and manage the configuration of Orion nodes, assuming appropriate credentials are available.A collection (List&amp;lt;int&amp;gt;) of Orion NodeIDs to add to NCM.true, unless an exception is thrown.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### AddNodeToNCM

Enables NCM to monitor and manage the configuration of an Orion node, assuming appropriate credentials are available.The Orion NodeID (int) for the node to add.The NCM NodeID (Guid) for the node.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### RemoveNode

Removes a node from NCM. Does not remove it from Orion, just NCM.The NCM NodeID (Guid) for the node to remove.true, unless an exception is thrown.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### RemoveNodes

Removes a set of nodes from NCM. Does not remove them from Orion, just NCM. Batch version of the RemoveNode verb.A collection (List&amp;lt;Guid&amp;gt;) of NCM NodeIDs to remove.true, unless an exception is thrown.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateNode

Updates the NCM properties of a node. All properties of the node are overwritten. It does not merge. To use this verb, first call GetNode to fetch the current properties of the node, modify the properties that you want to change on that model object, then call UpdateNode to commit the changes.The NCMNode model object to update.true, unless an exception is thrown.

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### GetNode

Fetches an NCMNode model object for the given node.The NCM NodeID (Guid) for the node to read.The NCMNode model object.

#### Access control

everyone

### CheckAPLicence

#### Access control

everyone

### DeleteOverLicenseNodes

#### Access control

everyone

### ValidateLogin

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### GetConnectionProfile

#### Access control

everyone

### AddConnectionProfile

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### UpdateConnectionProfile

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### DeleteConnectionProfile

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | manageNodes |

### GetAllConnectionProfiles

#### Access control

everyone

### AssignEOSEntry

#### Access control

everyone

### DeleteEOSData

#### Access control

everyone

### ChangeEOSType

#### Access control

everyone

### GetFIPSIncompatibleObjects

#### Access control

| Operations | Right |
| ------ | ------ |
| invoke | system |

### GetPageableEosDataTable

#### Access control

everyone

### GetPageableEosRowCount

#### Access control

everyone

### ChangeVulnerabilityStateForNodes

#### Access control

everyone

### ChangeVulnerabilityStateForAllNodes

#### Access control

everyone

### DeleteAllVulnerabilityData

#### Access control

everyone

### ParseMacros

#### Access control

everyone

### ExecuteConfigChangeReportAction

#### Access control

everyone

### GetCliSettings

#### Access control

| Operations | Right |
| ------ | ------ |
| read,invoke | admin |

